using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoyatyPointSystem.Models;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;

namespace LoyatyPointSystem.BusinessLogic
{
    public class EmployeeRoleBL
    {
        public void CreateEmployeeRole(Models.EmployeeRole model)
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                Models.EmployeeRole role = new Models.EmployeeRole();

                role.RoleName = model.RoleName;

                db.EmployeeRoles.Add(role);
            }
        }


        public List<EmployeeRole> LoadRole()
        {
            // this is the load method, its returns everything from the Register table where IsDeleted = false
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                return db.EmployeeRoles.ToList();
            }
        }
    }
}