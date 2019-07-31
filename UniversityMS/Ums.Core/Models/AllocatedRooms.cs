using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ums.Core.Models
{
    public class AllocatedRooms
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string DeptName { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int DayId { get; set; }
        public string DayName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RoomStatus { get; set; }

    }
}
