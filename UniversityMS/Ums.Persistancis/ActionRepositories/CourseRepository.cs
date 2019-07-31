using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ActionRepositories
{
    public class CourseRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExitCode(Courses _Course)
        {
            string query = "Select Count(*)from Courses where CourseCode='" + _Course.CourseCode + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }

        public decimal AlreadyExitName(Courses _Course)
        {
            string query = "Select Count(*)from Courses where CourseName='" + _Course.CourseName + "' And Dept_Code='" + Convert.ToInt32(_Course.DepartmentId) + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int Add(Courses _Course)
        {
            string query = "Insert Into Courses(CourseCode,CourseName,CourseCredit,CourseDescription,DepartmentId,SemesterId,CourseAssigneTo,Assigne_Status) Values ('" + _Course.CourseCode + "','" + _Course.CourseName + "','" + Convert.ToDecimal(_Course.CourseCredit) + "','" + _Course.CourseDescription + "','" + Convert.ToInt32(_Course.DepartmentId) + "','" + Convert.ToInt32(_Course.SemesterId) + "','Not Assigned Yet','Not Assigned')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }

        public List<Departments> GetDepartments()
        {
            var _DepartmentList = new List<Departments>();
            string query = ("Select *From Departments");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Department = new Departments();
                    _Department.Id = Convert.ToInt32(reader["Id"].ToString());
                    _Department.DeptName = reader["DeptName"].ToString();

                    _DepartmentList.Add(_Department);
                }
            }
            reader.Close();

            return _DepartmentList;
        }
        public List<Semesters> GetSemesters()
        {
            var _SemesterList = new List<Semesters>();
            string query = ("Select *From Semesters");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Semesters = new Semesters();
                    _Semesters.Id = Convert.ToInt32(reader["Id"].ToString());
                    _Semesters.SemesterName = reader["SemesterName"].ToString();

                    _SemesterList.Add(_Semesters);
                }
            }
            reader.Close();

            return _SemesterList;
        }
    }
}
