using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ActionRepositories
{
    public class DepartmentRepository
    {
        private MainRepository _MainRepository = new MainRepository();
        public decimal AlreadyExitCode(Departments _Department)
        {
            string query = "Select Count(*)from Departments where DeptCode='" + _Department.DeptCode + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }

        public decimal AlreadyExitName(Departments _Department)
        {
            string query = "Select Count(*)from Departments where DeptName='" + _Department.DeptName + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }
        public int AddDepartment(Departments _Department)
        {
            string query = "Insert Into Departments(DeptCode,DeptName) Values ('" + _Department.DeptCode + "','" + _Department.DeptName + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }
    }
}
