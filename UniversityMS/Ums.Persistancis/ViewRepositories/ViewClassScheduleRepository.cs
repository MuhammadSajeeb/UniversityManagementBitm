using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ViewRepositories
{
    public class ViewClassScheduleRepository
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
            string query = ("Select *From CoursesEnroll Where DepartmentId='" + DepartmentId + "'");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _EnrollCourse = new EnrollCourse();
                    _EnrollCourse.CourseCode = (reader["CourseCode"].ToString());
                    _EnrollCourse.CourseName = reader["CourseName"].ToString();
                    _EnrollCourse.ScheduleInfo = reader["ScheduleInfo"].ToString();

                    _CourseByDepartmentList.Add(_EnrollCourse);
                }
            }
            reader.Close();

            return _CourseByDepartmentList;
        }
    }
}
