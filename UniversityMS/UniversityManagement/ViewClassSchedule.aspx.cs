using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ums.Core.Models;
using Ums.Managers.ViewManagers;

namespace UniversityManagement
{
    public partial class ViewClassSchedule : System.Web.UI.Page
    {
        private ViewClassScheduleManager _ViewClassScheduleManager = new ViewClassScheduleManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDepartment();
            }
        }
        public void GetAllDepartment()
        {
            DepartmentDropDownList.DataSource = _ViewClassScheduleManager.GetAllDepartment();
            DepartmentDropDownList.DataTextField = "DeptCode";
            DepartmentDropDownList.DataValueField = "Id";
            DepartmentDropDownList.DataBind();
            DepartmentDropDownList.Items.Insert(0, new ListItem("Select Department", "0"));
        }
        public void LoadGridView()
        {
            EnrollCourse _EnrollCourse = new EnrollCourse();
            _EnrollCourse.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            ClassSheduleGridView.DataSource = _ViewClassScheduleManager.GetAllCourseByDepartment(_EnrollCourse.DepartmentId);
            ClassSheduleGridView.DataBind();
        }
        protected void DepartmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridView();
        }

        protected void ClassSheduleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClassSheduleGridView.PageIndex = e.NewPageIndex;
            LoadGridView();
        }
    }
}