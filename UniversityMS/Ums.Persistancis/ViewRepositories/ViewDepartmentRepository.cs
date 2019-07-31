using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ViewRepositories
{
    public class ViewDepartmentRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public List<Departments> GetAll()
        {
            var _DepartmentList = new List<Departments>();
            string query = ("Select *From Departments");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Departments = new Departments();
                    _Departments.DeptCode = (reader["DeptCode"].ToString());
                    _Departments.DeptName = reader["DeptName"].ToString();

                    _DepartmentList.Add(_Departments);
                }
            }
            reader.Close();

            return _DepartmentList;
        }
    }
}
