using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ActionRepositories
{
    public class ResultRepository
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
        public List<Grades> GetAllGrades()
        {
            var _GradeList = new List<Grades>();
            string query = ("Select *From Grades");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Grades = new Grades();

                    _Grades.Id = Convert.ToInt32(reader["Id"]);
                    _Grades.GradeName = reader["GradeName"].ToString();

                    _GradeList.Add(_Grades);
                }
            }
            reader.Close();

            return _GradeList;
        }
        public List<EnrollCourse> GetAllCourseByStudent(int DepartmentId,string StudentReg)
        {
            var _CourseByStudentList = new List<EnrollCourse>();
            string query = ("Select *From CoursesEnroll Where DepartmentId='" + DepartmentId + "' And StudentRegNo='"+StudentReg+"'");
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
        public List<EnrollCourse> GetAllResult(int DepartmentId, string StudentReg)
        {
            var _CourseByStudentList = new List<EnrollCourse>();
            string query = ("Select Students.StudentRegNo,Students.StudentName,Results.CourseCode,Results.CourseName,Results.GradeName from Results join Students on Students.StudentRegNo = Results.RegNo where Results.DepartmentId = '"+DepartmentId+"' and Results.RegNo = '"+StudentReg+"'");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _EnrollCourse = new EnrollCourse();
                    _EnrollCourse.StudentRegNo= (reader["StudentRegNo"].ToString());
                    _EnrollCourse.StudentName = (reader["StudentName"].ToString());
                    _EnrollCourse.CourseCode = (reader["CourseCode"].ToString());
                    _EnrollCourse.CourseName = reader["CourseName"].ToString();
                    _EnrollCourse.GradeName = reader["GradeName"].ToString();

                    _CourseByStudentList.Add(_EnrollCourse);
                }
            }
            reader.Close();

            return _CourseByStudentList;
        }
        public decimal AlreadySaveResult(Results _Results)
        {
            string query = "Select Count(*)from Results where DepartmentId='" + _Results.DepartmentId + "' And RegNo='" + _Results.RegNo + "' And CourseCode='" + _Results.CourseCode + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int ResultSsave(Results _Results)
        {
            string query = "Insert Into Results(CourseCode,CourseName,GradeName,RegNo,DepartmentId) Values ('" + _Results.CourseCode + "','" + _Results.CourseName + "','"+ _Results.GradeName+"','" + _Results.RegNo + "','" + _Results.DepartmentId + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
    }
}
