using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ums.Core.Models;
using Ums.Persistancis.ActionRepositories;
using Ums.Persistancis.ViewRepositories;

namespace Ums.Managers.ViewManagers
{
    public class ViewDepartmentManager
    {
        private ViewDepartmentRepository _ViewDepartmentRepository = new ViewDepartmentRepository();

        public List<Departments> GetAll()
        {
            return _ViewDepartmentRepository.GetAll();
        }

    }
}
