using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ums.Core.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string DeptCode { get; set; }
        public int DepartmentId { get; set; }
        public string StudentRegNo { get; set; }
        public string RegNo { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string EnrollDate { get; set; }
        public int StudentId { get; set; }
        public string ScheduleInfo { get; set; }
        public string GradeName { get; set; }

    }
}
