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
    public partial class EnrollCourses : System.Web.UI.Page
    {
        EnrollCourseManager _EnrollCourseManager = new EnrollCourseManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Now Opening Enroll Courses');", true);
                GetAllDepartment();
                StudentRegNoDropDownList.Items.Insert(0, new ListItem("Available No Registration", "0"));
                CoursesDropDownList.Items.Insert(0, new ListItem("Available No Courses", "0"));
            }
        }
        public void GetAllDepartment()
        {
            DepartmentDropDownList.DataSource = _EnrollCourseManager.GetAllDepartment();
            DepartmentDropDownList.DataTextField = "DeptCode";
            DepartmentDropDownList.DataValueField = "Id";
            DepartmentDropDownList.DataBind();
            DepartmentDropDownList.Items.Insert(0, new ListItem("Select Department", "0"));
        }
        public void GetAllStudentRegNo()
        {
            EnrollCourse _EnrollCourse = new EnrollCourse();
            _EnrollCourse.DeptCode = (DepartmentDropDownList.SelectedItem).ToString();
            StudentRegNoDropDownList.DataSource = _EnrollCourseManager.GetAllStudentRegNo(_EnrollCourse.DeptCode);
            StudentRegNoDropDownList.DataTextField = "StudentRegNo";
            StudentRegNoDropDownList.DataValueField = "Id";
            StudentRegNoDropDownList.DataBind();
            StudentRegNoDropDownList.Items.Insert(0, new ListItem("Select Registration No", "0"));
        }
        public void GetAllCourseByStudent()
        {
            EnrollCourse _EnrollCourse = new EnrollCourse();
            _EnrollCourse.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            CoursesDropDownList.DataSource = _EnrollCourseManager.GetAllCourseByStudent(_EnrollCourse.DepartmentId);
            CoursesDropDownList.DataTextField = "CourseName";
            CoursesDropDownList.DataValueField = "CourseCode";
            CoursesDropDownList.DataBind();
            CoursesDropDownList.Items.Insert(0, new ListItem("Select Courses", "0"));
        }
        protected void StudentRegNoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnrollCourse _EnrollCourse = new EnrollCourse();
            _EnrollCourse.Id = Convert.ToInt32(StudentRegNoDropDownList.SelectedValue);
            var StudentData = _EnrollCourseManager.GetStudentData(_EnrollCourse.Id);
            if (StudentData != null)
            {
                txtStudentName.Text = StudentData.StudentName.ToString();
                txtStudentEmail.Text = StudentData.StudentEmail.ToString();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Do Not have Anydata');", true);
            }
        }

        protected void EnrollCoursesButton_Click(object sender, EventArgs e)
        {
            EnrollCourse _EnrollCourse = new EnrollCourse();
            _EnrollCourse.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            _EnrollCourse.DeptCode = DepartmentDropDownList.SelectedItem.ToString();
            _EnrollCourse.StudentRegNo = StudentRegNoDropDownList.SelectedItem.ToString();
            _EnrollCourse.EnrollDate = DateTime.Now.ToShortDateString();
            _EnrollCourse.CourseCode = CoursesDropDownList.SelectedValue.ToString();
            _EnrollCourse.CourseName = CoursesDropDownList.SelectedItem.ToString();
            _EnrollCourse.StudentId = Convert.ToInt32(StudentRegNoDropDownList.SelectedValue);
            decimal AlreadyCourseAssign = _EnrollCourseManager.AlreadyCourseAssign(_EnrollCourse);
            if (AlreadyCourseAssign >= 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Code Already Enroll');", true);
            }
            else
            {
                int success = _EnrollCourseManager.EnrollCourse(_EnrollCourse);
                if (success > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Succssefully Enroll Course');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Enroll ');", true);
                }
            }
        }

        protected void DepartmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllStudentRegNo();
            GetAllCourseByStudent();
        }
    }
}