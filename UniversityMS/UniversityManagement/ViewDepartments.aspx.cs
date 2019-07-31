using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ums.Managers.ActionManagers;
using Ums.Managers.ViewManagers;

namespace UniversityManagement
{
    public partial class ViewDepartments : System.Web.UI.Page
    {
        private ViewDepartmentManager _ViewDepartmentManager = new ViewDepartmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DepartmentGridView.DataSource = _ViewDepartmentManager.GetAll();
                DataBind();
            }
        }

        protected void DepartmentGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        protected void DepartmentGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DepartmentGridView.PageIndex = e.NewPageIndex;
            DepartmentGridView.DataSource = _ViewDepartmentManager.GetAll();
            DataBind();
        }
    }
}