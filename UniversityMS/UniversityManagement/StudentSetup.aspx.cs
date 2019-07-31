using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ums.Core.Models;
using Ums.Managers.ActionManagers;

namespace UniversityManagement
{
    public partial class StudentSetup : System.Web.UI.Page
    {
        StudentManager _StudentsManager = new StudentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Now Opening Student Registration');", true);
                GetAllDepartment();
            }
        }
        public void GetAllDepartment()
        {
            DepartmentDropDownList.DataSource = _StudentsManager.GetAllDepartment();
            DepartmentDropDownList.DataTextField = "DeptName";
            DepartmentDropDownList.DataValueField = "DeptCode";
            DepartmentDropDownList.DataBind();
            DepartmentDropDownList.Items.Insert(0, new ListItem("Select Department", "0"));
            Courses _Course = new Courses();
            _Course.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
        }
        public void Refresh()
        {
            txtStudentName.Text = "";
            txtStudentEmail.Text = "";
            txtContactNo.Text = "";
            txtAddress.Text = "";
            DepartmentDropDownList.ClearSelection();
        }
        protected void StudentRegisterButton_Click(object sender, EventArgs e)
        {
            Students _Students = new Students();
            _Students.StudentEmail = txtStudentEmail.Text;
            _Students.DeptCode = (DepartmentDropDownList.SelectedValue).ToString();
            decimal CheckEmail = _StudentsManager.AlreadyExitEmail(_Students);
            if (CheckEmail >= 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Email Already Exist');", true);
            }
            else
            {
                _Students.CurrentYear = DateTime.Now.Year.ToString();
                _Students.DeptCode = (DepartmentDropDownList.SelectedValue).ToString();
                decimal CheckBatchExit = _StudentsManager.AlreadyExitBatch(_Students);
                if (CheckBatchExit >= 1)
                {
                    _Students.StudentName = txtStudentName.Text;
                    _Students.StudentEmail = txtStudentEmail.Text;
                    _Students.StudentContactNo = txtContactNo.Text;
                    _Students.CurrentDate = DateTime.Now.ToShortDateString();
                    _Students.StudentAddress = txtAddress.Text;
                    _Students.DeptCode = (DepartmentDropDownList.SelectedValue).ToString();
                    _Students.CurrentYear = DateTime.Now.Year.ToString();
                    var success = _StudentsManager.LastStudentRoll(_Students.DeptCode, _Students.CurrentYear);
                    decimal ReadRoll = 000;
                    if (success != null)
                    {
                        ReadRoll = Convert.ToInt32(success.StudentRoll);
                        ReadRoll++;
                    }

                    _Students.StudentRoll = ReadRoll;
                    _Students.StudentRegNo = _Students.DeptCode + "-" + DateTime.Now.Year.ToString() + "-" + ReadRoll.ToString("000");

                    int success2 = _StudentsManager.RegisterStudent(_Students);
                    if (success2 > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successefully Register!');", true);
                        Refresh();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Registration');", true);
                    }
                }
                else
                {
                    _Students.StudentName = txtStudentName.Text;
                    _Students.StudentEmail = txtStudentEmail.Text;
                    _Students.StudentContactNo = txtContactNo.Text;
                    _Students.CurrentDate = DateTime.Now.ToShortDateString();
                    _Students.StudentAddress = txtAddress.Text;
                    _Students.DeptCode = (DepartmentDropDownList.SelectedValue).ToString();
                    _Students.StudentRoll = 001;
                    _Students.StudentRegNo = _Students.DeptCode + "-" + DateTime.Now.Year.ToString() + "-" + _Students.StudentRoll.ToString("000");

                    int success1 = _StudentsManager.RegisterStudent(_Students);
                    if (success1 > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successefully Register!');", true);
                        Refresh();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Registration');", true);
                    }
                }

            }
        }
    }
}