using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.ViewRepositories
{
    public class ViewCourseRepository
    {
        private MainRepository _MainRepository = new MainRepository();

        public List<Courses> GetAll(int DepartmentId)
        {
            var _CoursetList = new List<Courses>();
            string query = ("select Courses.CourseCode,Courses.CourseName,Semesters.SemesterName,Courses.CourseAssigneTo from Courses join Semesters on Semesters.Id=Courses.SemesterId where Courses.DepartmentId='"+DepartmentId+"'");
            var reader = _MainRepository.Reader(query, _MainRepository.ConnectionString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var _Course = new Courses();
                    _Course.CourseCode = (reader["CourseCode"].ToString());
                    _Course.CourseName = reader["CourseName"].ToString();
                    _Course.SemesterName= reader["SemesterName"].ToString();
                    _Course.CourseAssigneTo = reader["CourseAssigneTo"].ToString();

                    _CoursetList.Add(_Course);
                }
            }
            reader.Close();

            return _CoursetList;
        }
    }
}
