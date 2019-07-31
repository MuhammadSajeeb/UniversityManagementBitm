using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.ActionRepositories;
using Ums.Persistancis.ViewRepositories;

namespace Ums.Managers.ViewManagers
{
    public class ViewCourseManager
    {
        private CourseRepository _CourseRepository = new CourseRepository();
        private ViewCourseRepository _ViewCourseRepository = new ViewCourseRepository();

        public List<Departments> GetDepartment()
        {
            return _CourseRepository.GetDepartments();
        }

        public List<Courses> GetAll(int DepartmentId)
        {
            return _ViewCourseRepository.GetAll(DepartmentId);
        }
    }
}
