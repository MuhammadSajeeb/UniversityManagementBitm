using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.ActionRepositories;

namespace Ums.Managers.ActionManagers
{
    public class EnrollCourseManager
    {
        private EnrollCourseRepository _EnrollCourseRepository = new EnrollCourseRepository();

        public List<Departments> GetAllDepartment()
        {
            return _EnrollCourseRepository.GetAllDepartments();
        }
        public List<EnrollCourse> GetAllStudentRegNo(string DeptCode)
        {
            return _EnrollCourseRepository.GetAllStudentRegNo(DeptCode);
        }
        public EnrollCourse GetStudentData(int Id)
        {
            return _EnrollCourseRepository.GetStudentData(Id);
        }
        public List<EnrollCourse> GetAllCourseByStudent(int DepartmentId)
        {
            return _EnrollCourseRepository.GetAllCourseByStudent(DepartmentId);
        }
        public decimal AlreadyCourseAssign(EnrollCourse _enrollCourse)
        {
            return _EnrollCourseRepository.AlreadyCourseAssign(_enrollCourse);
        }

        public int EnrollCourse(EnrollCourse _enrollCourse)
        {
            return _EnrollCourseRepository.EnrollCourse(_enrollCourse);
        }
    }
}
