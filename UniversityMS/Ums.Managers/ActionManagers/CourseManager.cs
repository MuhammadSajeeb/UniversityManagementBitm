using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.ActionRepositories;

namespace Ums.Managers.ActionManagers
{
    public class CourseManager
    {
        private CourseRepository _CourseRepository = new CourseRepository();

        public List<Departments> GetDepartment()
        {
            return _CourseRepository.GetDepartments();
        }

        public List<Semesters> GetSemesters()
        {
            return _CourseRepository.GetSemesters();
        }

        public decimal AlreadyExitCode(Courses _Course)
        {
            return _CourseRepository.AlreadyExitCode(_Course);
        }

        public decimal AlreadyExitName(Courses _Course)
        {
            return _CourseRepository.AlreadyExitName(_Course);
        }

        public int Add(Courses _Course)
        {
            return _CourseRepository.Add(_Course);
        }
    }
}
