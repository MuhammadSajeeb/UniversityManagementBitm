using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ums.Core.Models;
using Ums.Managers.ActionManagers;
using Ums.Persistancis.ActionRepositories;

namespace UniversityManagement
{
    public partial class ResultSetup : System.Web.UI.Page
    {
        EnrollCourseManager _EnrollCourseManager = new EnrollCourseManager();
        ResultRepository _ResultRepository = new ResultRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Now Opening Student Result');", true);
                GetAllDepartment();
                GetAllGrades();
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
        public void GetAllGrades()
        {
            GradesDropDownList.DataSource = _ResultRepository.GetAllGrades();
            GradesDropDownList.DataTextField = "GradeName";
            GradesDropDownList.DataValueField = "Id";
            GradesDropDownList.DataBind();
            GradesDropDownList.Items.Insert(0, new ListItem("Select Grades", "0"));
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
             
            _EnrollCourse.StudentRegNo = StudentRegNoDropDownList.SelectedItem.ToString();
        }
        public void GetAllCourseByStudent()
        {
            EnrollCourse _EnrollCourse = new EnrollCourse();
            _EnrollCourse.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            _EnrollCourse.StudentRegNo = StudentRegNoDropDownList.SelectedItem.ToString();
            CoursesDropDownList.DataSource = _ResultRepository.GetAllCourseByStudent(_EnrollCourse.DepartmentId,_EnrollCourse.StudentRegNo);
            CoursesDropDownList.DataTextField = "CourseName";
            CoursesDropDownList.DataValueField = "CourseCode";
            CoursesDropDownList.DataBind();
            CoursesDropDownList.Items.Insert(0, new ListItem("Select Courses", "0"));
        }

        protected void DepartmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllStudentRegNo();
            
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
                GetAllCourseByStudent();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Do Not have Anydata');", true);
            }

        }

        protected void ResultSaveButton_Click(object sender, EventArgs e)
        {
            Results _Results = new Results();
            _Results.CourseCode = CoursesDropDownList.SelectedValue.ToString();
            _Results.CourseName = CoursesDropDownList.SelectedItem.ToString();
            _Results.GradeName = GradesDropDownList.SelectedItem.ToString();
            _Results.RegNo = StudentRegNoDropDownList.SelectedItem.ToString();
            _Results.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            decimal AlreadyHere = _ResultRepository.AlreadySaveResult(_Results);

            if (AlreadyHere >= 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Result Already Saved');", true);
            }
            else
            {
                int success = _ResultRepository.ResultSsave(_Results);
                if (success > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Succssefully Save Result');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Result Saved ');", true);
                }
            }
        }
    }
}