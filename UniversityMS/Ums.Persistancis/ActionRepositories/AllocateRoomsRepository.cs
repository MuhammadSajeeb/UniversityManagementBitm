using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ActionRepositories
{
    public class AllocateRoomsRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public List<Departments> GetAllDepartments()
        {
            var _DepartmentList = new List<Departments>();
            string query = ("Select *From Departments");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Department = new Departments();

                    _Department.Id = Convert.ToInt32(reader["Id"]);
                    _Department.DeptCode = reader["DeptCode"].ToString();

                    _DepartmentList.Add(_Department);
                }
            }
            reader.Close();

            return _DepartmentList;
        }
        public List<EnrollCourse> GetAllCourseByDepartment(int DepartmentId)
        {
            var _CourseByDepartmentList = new List<EnrollCourse>();
            string query = ("Select *From Courses Where DepartmentId='" + DepartmentId + "'");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _EnrollCourse = new EnrollCourse();
                    _EnrollCourse.CourseCode = (reader["CourseCode"].ToString());
                    _EnrollCourse.CourseName = reader["CourseName"].ToString();

                    _CourseByDepartmentList.Add(_EnrollCourse);
                }
            }
            reader.Close();

            return _CourseByDepartmentList;
        }
        public List<AllocatedRooms> GetAllRooms()
        {
            var _AllocateRoomstList = new List<AllocatedRooms>();
            string query = ("Select *From Rooms");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _AllocateRooms = new AllocatedRooms();

                    _AllocateRooms.RoomId = Convert.ToInt32(reader["RoomId"]);
                    _AllocateRooms.RoomName = reader["RoomName"].ToString();

                    _AllocateRoomstList.Add(_AllocateRooms);
                }
            }
            reader.Close();

            return _AllocateRoomstList;
        }
        public List<AllocatedRooms> GetAllDays()
        {
            var _AllocateDaystList = new List<AllocatedRooms>();
            string query = ("Select *From Days");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _AllocateRooms = new AllocatedRooms();

                    _AllocateRooms.DayId = Convert.ToInt32(reader["DayId"]);
                    _AllocateRooms.DayName = reader["DayName"].ToString();

                    _AllocateDaystList.Add(_AllocateRooms);
                }
            }
            reader.Close();

            return _AllocateDaystList;
        }
        public decimal AlreadyCourseAllocate(AllocatedRooms _AllocateRooms)
        {
            string query = "Select Count(*)from AllocateClass where DepartmentId='" + _AllocateRooms.DepartmentId + "' And CourseCode='" + _AllocateRooms.CourseCode + "' And RoomId='" + _AllocateRooms.RoomId + "' And DayId='" + _AllocateRooms.DayId + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public decimal AlreadyReservedRoom(AllocatedRooms _AllocateRooms)
        {
            string query = "Select Count(*)from AllocateClass where RoomId='" + _AllocateRooms.RoomId + "' And DayId='" + _AllocateRooms.DayId + "' And StartTime='" + _AllocateRooms.StartTime + "' And EndTime='" + _AllocateRooms.EndTime + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int AllocateRooms(AllocatedRooms _AllocateRooms)
        {
            string query = "Insert Into AllocateClass(DepartmentId,CourseCode,RoomId,DayId,StartTime,EndTime,RoomStatus) Values ('" + _AllocateRooms.DepartmentId + "','" + _AllocateRooms.CourseCode + "','" + _AllocateRooms.RoomId + "','" + _AllocateRooms.DayId + "','" + _AllocateRooms.StartTime + "','" + _AllocateRooms.EndTime + "','Active')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }

        public int UpdateClassScheduleInfo(EnrollCourse _enrollCourse)
        {
            string query = "Update CoursesEnroll Set ScheduleInfo='" + _enrollCourse.ScheduleInfo + "' Where DepartmentId='" + _enrollCourse.DepartmentId + "' And CourseCode='" + _enrollCourse.CourseCode + "'";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
    }
}
