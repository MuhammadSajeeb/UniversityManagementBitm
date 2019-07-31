using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.ActionRepositories;

namespace Ums.Managers.ActionManagers
{
    public class StudentManager
    {
        private StudentRepository _StudentRepository = new StudentRepository();

        public List<Departments> GetAllDepartment()
        {
            return _StudentRepository.GetAllDepartments();
        }

        public decimal AlreadyExitEmail(Students _students)
        {
            return _StudentRepository.AlreadyExitEmail(_students);
        }

        public decimal AlreadyExitBatch(Students _students)
        {
            return _StudentRepository.AlreadyExitBatch(_students);
        }

        public Students LastStudentRoll(string DeptCode, string CurrentYear)
        {
            return _StudentRepository.LastStudentRoll(DeptCode, CurrentYear);
        }

        public int RegisterStudent(Students _students)
        {
            return _StudentRepository.RegisterStudent(_students);
        }
    }
}
