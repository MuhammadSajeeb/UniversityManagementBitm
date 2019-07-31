using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ums.Core.Models
{
    public class CourseAssign
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public decimal CreditTaken { get; set; }
        public decimal CreditLeft { get; set; }
        public int SemesterId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal CourseCredit { get; set; }
        public decimal UpdateCreditLeft { get; set; }
        public decimal UpdateCreditTaken { get; set; }

    }
}
