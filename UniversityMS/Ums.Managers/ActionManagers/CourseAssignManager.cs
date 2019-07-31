using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.ActionRepositories;

namespace Ums.Managers.ActionManagers
{
    public class CourseAssignManager
    {
        private CourseRepository _CourseRepository = new CourseRepository();

        private CourseAssignRepository _CourseAssignRepository = new CourseAssignRepository();

        public List<Departments> GetAllDepartment()
        {
            return _CourseRepository.GetDepartments();
        }
        public List<Teachers> GetAllTeacherByDepartment(int DepartmentId)
        {
            return _CourseAssignRepository.GetAllTeacherByDepartment(DepartmentId);
        }
        public List<Courses> GetAllCourseCodeByDepartment(int DepartmentId)
        {
            return _CourseAssignRepository.GetAllCourseCodeByDepartment(DepartmentId);
        }
        public Teachers GetTeacherData(int TeachersId)
        {
            return _CourseAssignRepository.GetTeacherData(TeachersId);
        }
        public Courses GetAllCourseDataByCourseCode(int CourseId)
        {
            return _CourseAssignRepository.GetAllCourseDataByCourseCode(CourseId);
        }
        public decimal AlreadyExitCode(CourseAssign _courseAssign)
        {
            return _CourseAssignRepository.AlreadyExitCode(_courseAssign);
        }

        public decimal TotalAssignCredit(int department,int TeachersId)
        {
            return _CourseAssignRepository.TotalAssignCredit(department,TeachersId);
        }
        public int AssigneCourse(CourseAssign _CourseAssign)
        {

            return _CourseAssignRepository.AssigneCourse(_CourseAssign);
        }
        public int UpdateAssigneTeacher(Courses _Course)
        {
            return _CourseAssignRepository.UpdateAssigneTeacher(_Course);
        }
        public int UpdateExtraCredit(CourseAssign _courseAssign)
        {
            return _CourseAssignRepository.UpdateExtraCredit(_courseAssign);
        }
    }
}
