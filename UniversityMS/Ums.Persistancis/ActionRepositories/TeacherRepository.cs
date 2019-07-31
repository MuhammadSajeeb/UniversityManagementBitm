using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ActionRepositories
{
    public class TeacherRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public List<Designations> GetDesignations()
        {
            var _DesignationsList = new List<Designations>();
            string query = ("Select *From Designations");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Designations = new Designations();
                    _Designations.Id = Convert.ToInt32(reader["Id"].ToString());
                    _Designations.DesignationName = reader["DesignationName"].ToString();

                    _DesignationsList.Add(_Designations);
                }
            }
            reader.Close();

            return _DesignationsList;
        }

        public decimal AlreadyExitEmail(Teachers _Teachers)
        {
            string query = "Select Count(*)from Teachers Where TeacherEmail='" + _Teachers.TeacherEmail + "'";
            return _MainRepository.ExecuteScalar(query, _MainRepository.ConnectionString());
        }

        public int Add(Teachers _Teachers)
        {
            string query = "Insert Into Teachers(TeacherName,TeacherAddress,TeacherEmail,TeacherContactNo,DesignationId,DepartmentId,CreditTaken,CreditLeft) Values ('" + _Teachers.TeacherName + "','" + _Teachers.TeacherAddress + "','" + _Teachers.TeacherEmail + "','" + _Teachers.TeacherContactNo + "','" + Convert.ToInt32(_Teachers.DesignationId) + "','" + Convert.ToInt32(_Teachers.DepartmentId) + "','" + _Teachers.CreditTaken + "','" + _Teachers.CreditLeft + "')";
            return _MainRepository.ExecuteNonQuery(query, _MainRepository.ConnectionString());
        }

    }
}
