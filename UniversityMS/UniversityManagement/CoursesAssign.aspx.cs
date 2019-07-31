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
    public partial class CoursesAssign : System.Web.UI.Page
    {
        CourseAssignManager _CourseAssigneManager = new CourseAssignManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Now Opening Courses Assigned');", true);
                GetAllDepartment();
                TeacherDropDownList.Items.Insert(0, new ListItem("Available No Teachers", "0"));
                CourseDropDownList.Items.Insert(0, new ListItem("Available No Course", "0"));
            }
        }
        public void GetAllDepartment()
        {
            DepartmentDropDownList.DataSource = _CourseAssigneManager.GetAllDepartment();
            DepartmentDropDownList.DataTextField = "DeptName";
            DepartmentDropDownList.DataValueField = "Id";
            DepartmentDropDownList.DataBind();
            DepartmentDropDownList.Items.Insert(0, new ListItem("Select Department", "0"));
            Courses _Course = new Courses();
            _Course.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
        }

        public void GetAllTeacherByDepartment()
        {
            Teachers _Teachers = new Teachers();
            _Teachers.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            TeacherDropDownList.DataSource = _CourseAssigneManager.GetAllTeacherByDepartment(_Teachers.DepartmentId);
            TeacherDropDownList.DataTextField = "TeacherName";
            TeacherDropDownList.DataValueField = "Id";
            TeacherDropDownList.DataBind();
            TeacherDropDownList.Items.Insert(0, new ListItem("Select Teachers", "0"));

        }

        public void GetAllCourseCodeByDepartment()
        {
            Courses _Course = new Courses();
            _Course.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            CourseDropDownList.DataSource = _CourseAssigneManager.GetAllCourseCodeByDepartment(_Course.DepartmentId);
            CourseDropDownList.DataTextField = "CourseCode";
            CourseDropDownList.DataValueField = "Id";
            CourseDropDownList.DataBind();
            CourseDropDownList.Items.Insert(0, new ListItem("Select Course Code", "0"));

        }
        public void RemainingCredit()
        {
            int departmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            int teacherId = Convert.ToInt32(TeacherDropDownList.SelectedValue);
            decimal CreditTaken = Convert.ToDecimal(txtCreditTaken.Text);
            decimal TotalAssignCredit = _CourseAssigneManager.TotalAssignCredit(departmentId,teacherId);
            decimal RemainingCredit = CreditTaken - TotalAssignCredit;
            txtRemainingCredit.Text = RemainingCredit.ToString("0");
        }
        public void Refresh()
        {
            txtCourseCredit.Text = "";
            txtCourseName.Text = "";
            txtCreditTaken.Text = "";
            txtRemainingCredit.Text = "";
            DepartmentDropDownList.ClearSelection();
            TeacherDropDownList.ClearSelection();
            CourseDropDownList.ClearSelection();
            
        }
        protected void DepartmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllTeacherByDepartment();
            GetAllCourseCodeByDepartment();
        }

        protected void TeacherDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int TeachersId = Convert.ToInt32(TeacherDropDownList.SelectedValue);
            var successe = _CourseAssigneManager.GetTeacherData(TeachersId);
            if (successe != null)
            {
                txtCreditTaken.Text = Convert.ToDecimal(successe.CreditTaken).ToString("0");
                RemainingCredit();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Check Teacher Id');", true);
            }
            
        }

        protected void CourseDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Courses _Course = new Courses();
            _Course.Id = Convert.ToInt32(CourseDropDownList.SelectedValue);
            var successe = _CourseAssigneManager.GetAllCourseDataByCourseCode(_Course.Id);
            if (successe != null)
            {
                txtCourseName.Text = successe.CourseName.ToString();
                txtCourseCredit.Text = Convert.ToDecimal(successe.CourseCredit).ToString("0");
            }
        }
        protected void CourseAssignButton_Click(object sender, EventArgs e)
        {
            CourseAssign _CourseAssign = new CourseAssign();
            _CourseAssign.CourseId = Convert.ToInt32(CourseDropDownList.SelectedValue);
            decimal CheckId = _CourseAssigneManager.AlreadyExitCode(_CourseAssign);
            if (CheckId >= 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Code Already Here');", true);
            }
            else
            {
                decimal RemainingCredit = Convert.ToDecimal(txtRemainingCredit.Text);
                if (RemainingCredit >= 1)
                {

                    _CourseAssign.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
                    _CourseAssign.TeacherId = Convert.ToInt32(TeacherDropDownList.SelectedValue);
                    _CourseAssign.CourseId = Convert.ToInt32(CourseDropDownList.SelectedValue);
                    _CourseAssign.CourseName = txtCourseName.Text;
                    _CourseAssign.CourseCredit = Convert.ToDecimal(txtCourseCredit.Text);
                    int successe = _CourseAssigneManager.AssigneCourse(_CourseAssign);
                    if (successe > 0)
                    {
                        Courses _Course = new Courses();
                        _Course.Id = Convert.ToInt32(CourseDropDownList.SelectedValue);
                        _Course.CourseAssigneTo = TeacherDropDownList.SelectedItem.ToString();
                        _CourseAssigneManager.UpdateAssigneTeacher(_Course);
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Succssefully Assign Course');", true);
                        Refresh();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Course Assign');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert ('Are You Sure You Want To Assign More Credit');", true);

                    int successe = _CourseAssigneManager.AssigneCourse(_CourseAssign);
                    if (successe > 0)
                    {
                        Courses _Course = new Courses();
                        _Course.Id = Convert.ToInt32(CourseDropDownList.SelectedValue);
                        _Course.CourseAssigneTo = TeacherDropDownList.SelectedItem.ToString();
                        _CourseAssigneManager.UpdateAssigneTeacher(_Course);

                        _CourseAssigneManager.UpdateExtraCredit(_CourseAssign);

                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Succssefully Assign Course');", true);
                        Refresh();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Course Assign');", true);
                    }
                }
            }
        }

    }
}