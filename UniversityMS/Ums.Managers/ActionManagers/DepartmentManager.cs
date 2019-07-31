using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.ActionRepositories;

namespace Ums.Managers.ActionManagers
{
    public class DepartmentManager
    {
        private DepartmentRepository _DepartmentRepository = new DepartmentRepository();

        public decimal AlreadyExitCode(Departments _Department)
        {
            return _DepartmentRepository.AlreadyExitCode(_Department);
        }

        public decimal AlreadyExitName(Departments _Department)
        {
            return _DepartmentRepository.AlreadyExitName(_Department);
        }

        public int Add(Departments _Department)
        {
            return _DepartmentRepository.AddDepartment(_Department);
        }

    }
}
