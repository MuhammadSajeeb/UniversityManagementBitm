using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ums.Core.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }

        public string TeacherAddress { get; set; }

        public string TeacherEmail { get; set; }

        public string TeacherContactNo { get; set; }

        public int DesignationId { get; set; }

        public int DepartmentId { get; set; }

        public decimal CreditTaken { get; set; }

        public decimal CreditLeft { get; set; }

    }
}
