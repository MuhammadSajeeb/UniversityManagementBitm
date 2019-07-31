using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ums.Core.Models;
using Ums.Managers.ActionManagers;
using Ums.Persistancis.ActionRepositories;

namespace UniversityManagement
{
    public partial class ViewResult : System.Web.UI.Page
    {
        EnrollCourseManager _EnrollCourseManager = new EnrollCourseManager();
        ResultRepository _ResultRepository = new ResultRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Now Opening Student Result');", true);
                GetAllDepartment();
                StudentsRegNoDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Available No Registration", "0"));
            }

             
        }
        public void GetAllDepartment()
        {
            DepartmentsDropDownList.DataSource = _ResultRepository.GetAllDepartments();
            DepartmentsDropDownList.DataTextField = "DeptCode";
            DepartmentsDropDownList.DataValueField = "Id";
            DepartmentsDropDownList.DataBind();
            DepartmentsDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Department", "0"));
        }
        public void GetAllStudentRegNo()
        {
            EnrollCourse _EnrollCourse = new EnrollCourse();
            _EnrollCourse.DeptCode = (DepartmentsDropDownList.SelectedItem).ToString();
            StudentsRegNoDropDownList.DataSource = _EnrollCourseManager.GetAllStudentRegNo(_EnrollCourse.DeptCode);
            StudentsRegNoDropDownList.DataTextField = "StudentRegNo";
            StudentsRegNoDropDownList.DataValueField = "Id";
            StudentsRegNoDropDownList.DataBind();
            StudentsRegNoDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Registration No", "0"));

            _EnrollCourse.StudentRegNo = StudentsRegNoDropDownList.SelectedItem.ToString();
        }
        public void GetAllStudentResult()
        {
            EnrollCourse _EnrollCourse = new EnrollCourse();
            _EnrollCourse.DepartmentId = Convert.ToInt32(DepartmentsDropDownList.SelectedValue);
            _EnrollCourse.StudentRegNo = StudentsRegNoDropDownList.SelectedItem.ToString();
            ResultGridView.DataSource = _ResultRepository.GetAllResult(_EnrollCourse.DepartmentId, _EnrollCourse.StudentRegNo);
            ResultGridView.DataBind();

        }
        protected void DepartmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllStudentRegNo();
            txtStudentName.Text = "";
            txtStudentEmail.Text = "";
        }

        protected void StudentRegNoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnrollCourse _EnrollCourse = new EnrollCourse();
            _EnrollCourse.Id = Convert.ToInt32(StudentsRegNoDropDownList.SelectedValue);
            var StudentData = _EnrollCourseManager.GetStudentData(_EnrollCourse.Id);
            if (StudentData != null)
            {
                txtStudentName.Text = StudentData.StudentName.ToString();
                txtStudentEmail.Text = StudentData.StudentEmail.ToString();
                GetAllStudentResult();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Do Not have Anydata');", true);
            }
        }

        protected void PdfButton_Click(object sender, EventArgs e)
        {
            int columnsCount = ResultGridView.HeaderRow.Cells.Count;
            // Create the PDF Table specifying the number of columns
            PdfPTable pdfTable = new PdfPTable(columnsCount);

            pdfTable.DefaultCell.Padding = 5;
            pdfTable.WidthPercentage = 90;
            pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 0.5f;

            foreach (TableCell gridViewHeaderCell in ResultGridView.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text));
                pdfTable.AddCell(pdfCell);

            }

            foreach (GridViewRow gridViewRow in ResultGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    // Loop thru each cell in GrdiView data row
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text));

                        pdfTable.AddCell(pdfCell);
                    }
                }
            }

            Document pdfDocument = new Document(PageSize.A4, 3f, 3f, 100f, 10f);
            //PdfWriter.GetInstance(pdfDocument, new FileStream(Server.MapPath("~/StorePdf/ResultSheet.pdf"), FileMode.Create));
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            pdfDocument.AddAuthor("Muhammod Sajeeb");
            pdfDocument.AddCreator("Create Stock Management");
            pdfDocument.AddKeywords("Stock Management");
            pdfDocument.AddSubject("Document subject - Describing the steps creating a PDF document");
            pdfDocument.AddTitle("Stocks Report");
            //pdfDocument.Add(new Paragraph(_przelew + "\n"));
            //pdfDocument.Add(new Paragraph(String.Format("Bank {0}: zaprasza\n", nameBank)));
            //pdfDocument.Add(new Paragraph(DateTime.Now.ToString()));
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successefull Result Export To Pdf');", true);

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition",
                "attachment;filename=ResultSheet.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
    
}