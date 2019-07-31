using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.ActionRepositories;

namespace Ums.Managers.ActionManagers
{
    public class AllocateRoomsManager
    {
        private AllocateRoomsRepository _AllocateRoomsRepository = new AllocateRoomsRepository();

        public List<Departments> GetAllDepartment()
        {
            return _AllocateRoomsRepository.GetAllDepartments();
        }
        public List<EnrollCourse> GetAllCourseByDepartment(int DepartmentId)
        {
            return _AllocateRoomsRepository.GetAllCourseByDepartment(DepartmentId);
        }
        public List<AllocatedRooms> GetAllRooms()
        {
            return _AllocateRoomsRepository.GetAllRooms();
        }
        public List<AllocatedRooms> GetAllDays()
        {
            return _AllocateRoomsRepository.GetAllDays();
        }
        public decimal AlreadyCourseAllocate(AllocatedRooms _AllocateRooms)
        {
            return _AllocateRoomsRepository.AlreadyCourseAllocate(_AllocateRooms);
        }
        public decimal AlreadyReservedRoom(AllocatedRooms _AllocateRooms)
        {
            return _AllocateRoomsRepository.AlreadyReservedRoom(_AllocateRooms);
        }
        public int AllocateRooms(AllocatedRooms _AllocateRooms)
        {
            return _AllocateRoomsRepository.AllocateRooms(_AllocateRooms);
        }
        public int UpdateClassScheduleInfo(EnrollCourse _enrollCourse)
        {
            return _AllocateRoomsRepository.UpdateClassScheduleInfo(_enrollCourse);
        }
    }
}
