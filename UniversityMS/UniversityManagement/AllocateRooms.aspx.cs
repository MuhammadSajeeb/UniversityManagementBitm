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
    public partial class AllocateRooms : System.Web.UI.Page
    {
        AllocateRoomsManager _AllocateRoomManager = new AllocateRoomsManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDepartment();
                GetAllRooms();
                GetAllDays();
                CoursesDropDownList.Items.Insert(0, new ListItem("Available No Courses", "0"));
            }
        }
        public void GetAllDepartment()
        {
            DepartmentDropDownList.DataSource = _AllocateRoomManager.GetAllDepartment();
            DepartmentDropDownList.DataTextField = "DeptCode";
            DepartmentDropDownList.DataValueField = "Id";
            DepartmentDropDownList.DataBind();
            DepartmentDropDownList.Items.Insert(0, new ListItem("Select Department", "0"));
        }
        public void GetAllCourseByDepartment()
        {
            EnrollCourse _EnrollCourse = new EnrollCourse();
            _EnrollCourse.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);

            CoursesDropDownList.DataSource = _AllocateRoomManager.GetAllCourseByDepartment(_EnrollCourse.DepartmentId);
            CoursesDropDownList.DataTextField = "CourseName";
            CoursesDropDownList.DataValueField = "CourseCode";
            CoursesDropDownList.DataBind();
            CoursesDropDownList.Items.Insert(0, new ListItem("Select Courses", "0"));
        }
        public void GetAllRooms()
        {
            RoomsDropDownList.DataSource = _AllocateRoomManager.GetAllRooms();
            RoomsDropDownList.DataTextField = "RoomName";
            RoomsDropDownList.DataValueField = "RoomId";
            RoomsDropDownList.DataBind();
            RoomsDropDownList.Items.Insert(0, new ListItem("Select Rooms", "0"));
        }
        public void GetAllDays()
        {
            DayDropDownList.DataSource = _AllocateRoomManager.GetAllDays();
            DayDropDownList.DataTextField = "DayName";
            DayDropDownList.DataValueField = "DayId";
            DayDropDownList.DataBind();
            DayDropDownList.Items.Insert(0, new ListItem("Select Days", "0"));
        }
        protected void DepartmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllCourseByDepartment();
        }
       
        protected void AllocateRoomsButton_Click(object sender, EventArgs e)
        {
            AllocatedRooms _AllocateRooms = new AllocatedRooms();
            _AllocateRooms.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
            _AllocateRooms.CourseCode = CoursesDropDownList.SelectedValue;
            _AllocateRooms.RoomId = Convert.ToInt32(RoomsDropDownList.SelectedValue);
            _AllocateRooms.DayId = Convert.ToInt32(DayDropDownList.SelectedValue);
            _AllocateRooms.StartTime = Convert.ToDateTime(txtDateFrom.Text);
            _AllocateRooms.EndTime = Convert.ToDateTime(txtDateTo.Text);

            decimal CheckExitCourse = _AllocateRoomManager.AlreadyCourseAllocate(_AllocateRooms);
            if (CheckExitCourse >= 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Course Already Allocated');", true);
            }
            else
            {
                decimal CheckExitRoom = _AllocateRoomManager.AlreadyReservedRoom(_AllocateRooms);
                if (CheckExitRoom >= 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Time Allocated Same Room');", true);
                }
                else
                {
                    int AllocateClass = _AllocateRoomManager.AllocateRooms(_AllocateRooms);
                    if (AllocateClass > 0)
                    {
                        EnrollCourse _EnrollCourse = new EnrollCourse();
                        _EnrollCourse.DepartmentId = Convert.ToInt32(DepartmentDropDownList.SelectedValue);
                        _EnrollCourse.CourseCode = CoursesDropDownList.SelectedValue;
                        _EnrollCourse.ScheduleInfo = RoomsDropDownList.SelectedItem.ToString() + ", " +
                                                     DayDropDownList.SelectedItem.ToString() + ", " + Convert.ToDateTime(_AllocateRooms.StartTime).ToString("HH : mm tt") +
                                                     "-" + Convert.ToDateTime(_AllocateRooms.EndTime).ToString("HH : mm tt");
                        int UpdateClassSchedule = _AllocateRoomManager.UpdateClassScheduleInfo(_EnrollCourse);
                        if (UpdateClassSchedule > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Succssefully Allocate Class Room');", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Room Allocate Update');", true);
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Room Allocate');", true);
                    }
                }
            }
        }
    }
}