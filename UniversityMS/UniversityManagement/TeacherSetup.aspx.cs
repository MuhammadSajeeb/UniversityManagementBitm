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
    public partial class TeacherSetup : System.Web.UI.Page
    {
        private TeacherManager _TeachersManager = new TeacherManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Now Opening Teacher Setup');", true);
                GetDesignations();
                GetDepartment();
            }
        }
        public void GetDesignations()
        {
            DesignationDropDownList.DataSource = _TeachersManager.GetDesignations();
            DesignationDropDownList.DataTextField = "DesignationName";
            DesignationDropDownList.DataValueField = "Id";
            DesignationDropDownList.DataBind();
            DesignationDropDownList.Items.Insert(0, new ListItem("Select Designation", "0"));
            Teachers _Teachers = new Teachers();
            _Teachers.DesignationId = Convert.ToInt32(DesignationDropDownList.SelectedValue);
        }

        public void GetDepartment()
        {
            DepartmentDropDownList.DataSource = _TeachersManager.GetDepartment();
            DepartmentDropDownList.DataTextField = "DeptName";
            DepartmentDropDownList.DataValueField = "Id";
            DepartmentDropDownList.DataBind();
            DepartmentDropDownList.Items.Insert(0, new ListItem("Select Department", "0"));
            Teachers _Teachers = new Teachers();
            _Teachers.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
        }

        public void Refresh()
        {
            txtTeacherName.Text = "";
            txtTeacherAddress.Text = "";
            txtTeacherEmail.Text = "";
            txtContactNo.Text = "";
            txtCreditTaken.Text = "";
            DepartmentDropDownList.ClearSelection();
            DesignationDropDownList.ClearSelection();
        }
        protected void TeacherSaveButton_Click(object sender, EventArgs e)
        {
            Teachers _Teachers = new Teachers();
            _Teachers.TeacherName = txtTeacherName.Text;
            _Teachers.TeacherAddress = txtTeacherAddress.Text;
            _Teachers.TeacherEmail = txtTeacherEmail.Text;
            _Teachers.TeacherContactNo = txtContactNo.Text;
            _Teachers.DesignationId = Convert.ToInt32(DesignationDropDownList.SelectedValue);
            _Teachers.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            _Teachers.CreditTaken = Convert.ToDecimal(txtCreditTaken.Text);
            _Teachers.CreditLeft = Convert.ToDecimal(txtCreditTaken.Text);

            decimal countcode = _TeachersManager.AlreadyExitEmail(_Teachers);
            if (countcode >= 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Mail Aready Exist ! Should be Unique');", true);

            }
            else
            {
                int success = _TeachersManager.Add(_Teachers);
                if (success > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successefully Save Teacher');", true);
                    Refresh();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Saved Teacher);", true);
                }
            }
        }
    }
}