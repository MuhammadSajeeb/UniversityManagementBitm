using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ActionRepositories
{
    public class CourseAssignRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public List<Teachers> GetAllTeacherByDepartment(int DepartmentId)
        {
            var _TeachersList = new List<Teachers>();
            string query = ("Select *From Teachers where DepartmentId='" + DepartmentId + "'");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Teachers = new Teachers();
                    _Teachers.TeacherName = reader["TeacherName"].ToString();
                    _Teachers.Id = Convert.ToInt32(reader["Id"]);

                    _TeachersList.Add(_Teachers);
                }
            }
            reader.Close();

            return _TeachersList;
        }
        public Teachers GetTeacherData(int TeachersId)
        {
            Teachers _Teachers = null;

            string query = "select *from Teachers where Id ='" + TeachersId + "' ";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Teachers = new Teachers();

                _Teachers.CreditTaken = Convert.ToDecimal(reader["CreditTaken"]);
            }
            reader.Close();

            return _Teachers;
        }
        public List<Courses> GetAllCourseCodeByDepartment(int DepartmentId)
        {
            var _CourseList = new List<Courses>();
            string query = ("Select *From Courses where DepartmentId='" + DepartmentId + "'");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Course = new Courses();
                    _Course.CourseCode = reader["CourseCode"].ToString();
                    _Course.Id = Convert.ToInt32(reader["Id"]);

                    _CourseList.Add(_Course);
                }
            }
            reader.Close();

            return _CourseList;
        }
        public Courses GetAllCourseDataByCourseCode(int CourseId)
        {
            Courses _Course = null;

            string query = "select *from Courses where Id ='" + CourseId + "' ";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Course = new Courses();
                _Course.CourseName = reader["CourseName"].ToString();
                _Course.CourseCredit = Convert.ToDecimal(reader["CourseCredit"]);
            }
            reader.Close();

            return _Course;
        }
        public decimal AlreadyExitCode(CourseAssign _courseAssign)
        {
            string query = "Select Count(*)from CourseAssigne where CourseId='" + _courseAssign.CourseId + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public decimal TotalAssignCredit(int departmentId,int TeachersId)
        {
            string query = "Select Sum(CourseCredit)from CourseAssigne where DepartmentId='"+departmentId+"'And TeacherId ='" + TeachersId + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int AssigneCourse(CourseAssign _CourseAssign)
        {
            string query = "Insert Into CourseAssigne(DepartmentId,TeacherId,CourseId,CourseName,CourseCredit) Values ('" + Convert.ToInt32(_CourseAssign.DepartmentId) + "','" + Convert.ToInt32(_CourseAssign.TeacherId) + "','" + Convert.ToInt32(_CourseAssign.CourseId) + "','" + _CourseAssign.CourseName + "','" + Convert.ToDecimal(_CourseAssign.CourseCredit) + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public int UpdateAssigneTeacher(Courses _Course)
        {
            string query = "Update Courses Set CourseAssigneTo='" + _Course.CourseAssigneTo + "', Assigne_Status='Assigned' Where Id='" + _Course.Id + "'";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
        public int UpdateExtraCredit(CourseAssign _courseAssigneM)
        {
            string query = "Update Teachers Set CreditTaken='" + _courseAssigneM.CreditTaken + "' Where Id='" + _courseAssigneM.TeacherId + "'";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
    }
}
