using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ActionRepositories
{
    public class EnrollCourseRepository
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
        public List<EnrollCourse> GetAllStudentRegNo(string DeptCode)
        {
            var _StudentRegNoList = new List<EnrollCourse>();
            string query = ("Select *From Students Where DeptCode='" + DeptCode + "'");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _EnrollCourse = new EnrollCourse();
                    _EnrollCourse.Id = Convert.ToInt32(reader["Id"].ToString());
                    _EnrollCourse.StudentRegNo = reader["StudentRegNo"].ToString();

                    _StudentRegNoList.Add(_EnrollCourse);
                }
            }
            reader.Close();

            return _StudentRegNoList;
        }
        public EnrollCourse GetStudentData(int Id)
        {
            EnrollCourse _EnrollCourse = null;

            string query = "select *From Students Where Id='" + Id + "'";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _EnrollCourse = new EnrollCourse();
                _EnrollCourse.StudentName = reader["StudentName"].ToString();
                _EnrollCourse.StudentEmail = reader["StudentEmail"].ToString();
            }
            reader.Close();

            return _EnrollCourse;
        }
        public List<EnrollCourse> GetAllCourseByStudent(int DepartmentId)
        {
            var _CourseByStudentList = new List<EnrollCourse>();
            string query = ("Select *From Courses Where DepartmentId='" + DepartmentId + "'");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _EnrollCourse = new EnrollCourse();
                    _EnrollCourse.CourseCode = (reader["CourseCode"].ToString());
                    _EnrollCourse.CourseName = reader["CourseName"].ToString();

                    _CourseByStudentList.Add(_EnrollCourse);
                }
            }
            reader.Close();

            return _CourseByStudentList;
        }
        public decimal AlreadyCourseAssign(EnrollCourse _enrollCourse)
        {
            string query = "Select Count(*)from CoursesEnroll where DepartmentId='" + _enrollCourse.DepartmentId + "' And StudentRegNo='" + _enrollCourse.StudentRegNo + "' And CourseName='" + _enrollCourse.CourseName + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int EnrollCourse(EnrollCourse _enrollCourse)
        {
            string query = "Insert Into CoursesEnroll(DepartmentId,DeptCode,StudentRegNo,EnrollDate,CourseCode,CourseName,StudentId,ScheduleInfo) Values ('" + _enrollCourse.DepartmentId + "','" + _enrollCourse.DeptCode + "','" + _enrollCourse.StudentRegNo + "','" + _enrollCourse.EnrollDate + "','" + _enrollCourse.CourseCode + "','" + _enrollCourse.CourseName + "','" + _enrollCourse.StudentId + "','Not Schedule Yet')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }

    }
}
