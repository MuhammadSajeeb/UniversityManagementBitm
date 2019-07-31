using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.ActionRepositories;

namespace Ums.Managers.ActionManagers
{
    public class TeacherManager
    {
        private TeacherRepository _TeacherRepository = new TeacherRepository();

        private CourseRepository _CourseRepository = new CourseRepository();

        public List<Designations> GetDesignations()
        {
            return _TeacherRepository.GetDesignations();
        }
        public List<Departments> GetDepartment()
        {
            return _CourseRepository.GetDepartments();
        }
        public decimal AlreadyExitEmail(Teachers _Teachers)
        {
            return _TeacherRepository.AlreadyExitEmail(_Teachers);
        }
        public int Add(Teachers _Teachers)
        {
            return _TeacherRepository.Add(_Teachers);
        }
    }
}
