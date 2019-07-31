using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ums.Core.Models;
using Ums.Managers.ActionManagers;
using Ums.Managers.ViewManagers;

namespace UniversityManagement
{
    public partial class DepartmentSetup : System.Web.UI.Page
    {
        private DepartmentManager _DepartmentManager = new DepartmentManager();
        private ViewDepartmentManager _ViewDepartmentManager = new ViewDepartmentManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Now Opening Department Setup');", true);
                IdHiddenField.Value = "";
               

            }
        }

        protected void DepartmentSaveButton_Click(object sender, EventArgs e)
        {
            if(IdHiddenField.Value=="")
            {
                Departments _Department = new Departments();
                _Department.DeptCode = txtDepartmentCode.Text;
                decimal countcode = _DepartmentManager.AlreadyExitCode(_Department);
                if (countcode >= 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Code Already Exist');", true);

                }
                else
                {
                    _Department.DeptName = txtDepartmentName.Text;
                    decimal countname = _DepartmentManager.AlreadyExitName(_Department);
                    if (countname >= 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Name Already Exist');", true);

                    }
                    else
                    {
                        int success = _DepartmentManager.Add(_Department);
                        if (success > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successefully Save Department');", true);
                            txtDepartmentCode.Text = "";
                            txtDepartmentName.Text = "";
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Department Saved');", true);
                        }
                    }
                }
            }
        }

        protected void DepartmentDeleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}