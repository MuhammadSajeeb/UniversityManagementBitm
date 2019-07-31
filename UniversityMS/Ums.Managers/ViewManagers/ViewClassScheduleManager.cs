using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.ViewRepositories;

namespace Ums.Managers.ViewManagers
{
    public class ViewClassScheduleManager
    {
        private ViewClassScheduleRepository _ViewClassScheduleRepository = new ViewClassScheduleRepository();

        public List<Departments> GetAllDepartment()
        {
            return _ViewClassScheduleRepository.GetAllDepartments();
        }
        public List<EnrollCourse> GetAllCourseByDepartment(int DepartmentId)
        {
            return _ViewClassScheduleRepository.GetAllCourseByDepartment(DepartmentId);
        }
    }
}
