using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ums.Core.Models
{
    public class Courses
    {
        public int Id { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public decimal CourseCredit { get; set; }

        public string CourseDescription { get; set; }

        public int DepartmentId { get; set; }

        public string CourseAssigneTo { get; set; }
        public string Assigne_Status { get; set; }

        public int SemesterId { get; set; }

        public string SemesterName { get; set; }

    }
}
