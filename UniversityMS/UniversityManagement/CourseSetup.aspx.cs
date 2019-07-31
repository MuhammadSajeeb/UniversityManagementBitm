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
    public partial class CourseSetup : System.Web.UI.Page
    {
        private CourseManager _CourseManager = new CourseManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Now Opening Courses Setup');", true);
                GetDepartment();
                GetSemesters();
            }
        }
        public void GetDepartment()
        {
            DepartmentDropDownList.DataSource = _CourseManager.GetDepartment();
            DepartmentDropDownList.DataTextField = "DeptName";
            DepartmentDropDownList.DataValueField = "Id";
            DepartmentDropDownList.DataBind();
            DepartmentDropDownList.Items.Insert(0, new ListItem("Select Department", "0"));
            Courses _Course = new Courses();
            _Course.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
        }

        public void GetSemesters()
        {
            SemestersDropDownList.DataSource = _CourseManager.GetSemesters();
            SemestersDropDownList.DataTextField = "SemesterName";
            SemestersDropDownList.DataValueField = "Id";
            SemestersDropDownList.DataBind();
            SemestersDropDownList.Items.Insert(0, new ListItem("Select Semesters", "0"));
            Courses _Course = new Courses();
            _Course.SemesterId = Convert.ToInt32(SemestersDropDownList.SelectedValue);
        }
        
        public void Refresh()
        {
            txtCourseCode.Text = "";
            txtCourseName.Text = "";
            txtCredit.Text = "";
            txtDescription.Text = "";
            DepartmentDropDownList.ClearSelection();
            SemestersDropDownList.ClearSelection();
        }
        protected void CourseSaveButton_Click(object sender, EventArgs e)
        {
            Courses _Course = new Courses();
            _Course.CourseCode = txtCourseCode.Text;
            decimal countcode = _CourseManager.AlreadyExitCode(_Course);
            if (countcode >= 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Code Already Exist');", true);

            }
            else
            {
                _Course.CourseName = txtCourseName.Text;
                _Course.CourseCredit = Convert.ToDecimal(txtCredit.Text);
                _Course.CourseDescription = txtDescription.Text;
                _Course.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
                _Course.SemesterId = Convert.ToInt32(SemestersDropDownList.SelectedValue);
                decimal countname = _CourseManager.AlreadyExitName(_Course);
                if (countname >= 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Name Already Exist');", true);

                }
                else
                {

                    int success = _CourseManager.Add(_Course);
                    if (success > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Succssefully Save Course');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Saved Course');", true);
                    }
                }
            }
        }
    }
}