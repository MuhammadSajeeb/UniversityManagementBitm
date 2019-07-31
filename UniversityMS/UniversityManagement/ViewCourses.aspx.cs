using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ums.Core.Models;
using Ums.Managers.ActionManagers;
using Ums.Managers.ViewManagers;

namespace UniversityManagement
{
    public partial class ViewCourses : System.Web.UI.Page
    {
        private CourseManager _CourseManager = new CourseManager();
        private ViewCourseManager _ViewCourseManager = new ViewCourseManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetDepartment();
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

        protected void DepartmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Courses _Course = new Courses();
            _Course.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            CoursesGridView.DataSource = _ViewCourseManager.GetAll(_Course.DepartmentId);
            DataBind();
        }

        protected void CoursesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Courses _Course = new Courses();
            _Course.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            CoursesGridView.PageIndex = e.NewPageIndex;
            CoursesGridView.DataSource = _ViewCourseManager.GetAll(_Course.DepartmentId);
            DataBind();
        }
    }
}