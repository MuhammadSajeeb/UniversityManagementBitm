using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ActionRepositories
{
    public class StudentRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public decimal AlreadyExitEmail(Students _students)
        {
            string query = "Select Count(*)from Students where StudentEmail='" + _students.StudentEmail + "' And DeptCode='" + _students.DeptCode + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }

        public decimal AlreadyExitBatch(Students _students)
        {
            string query = "Select * from Students Where DeptCode='" + _students.DeptCode + "' and Year(CurrentDate)='" + _students.CurrentYear + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public Students LastStudentRoll(string DeptCode, string CurrentYear)
        {
            Students _Students = null;

            string query = "select top 1 StudentRoll from Students Where DeptCode='" + DeptCode + "' and Year(CurrentDate)='" + CurrentYear + "' order by StudentRoll desc";
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                reader.Read();
                _Students = new Students();
                _Students.StudentRoll = Convert.ToDecimal(reader["StudentRoll"]);
            }
            reader.Close();

            return _Students;
        }
        public int RegisterStudent(Students _students)
        {
            string query = "Insert Into Students(StudentName,StudentEmail,StudentContactNo,CurrentDate,StudentAddress,DeptCode,StudentRoll,StudentRegNo) Values ('" + _students.StudentName + "','" + _students.StudentEmail + "','" + _students.StudentContactNo + "','" + _students.CurrentDate + "','" + _students.StudentAddress + "','" + _students.DeptCode + "','" + Convert.ToDecimal(_students.StudentRoll) + "','" + _students.StudentRegNo + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
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
                    _Department.DeptCode = reader["DeptCode"].ToString();
                    _Department.DeptName = reader["DeptName"].ToString();

                    _DepartmentList.Add(_Department);
                }
            }
            reader.Close();

            return _DepartmentList;
        }
    }
}
