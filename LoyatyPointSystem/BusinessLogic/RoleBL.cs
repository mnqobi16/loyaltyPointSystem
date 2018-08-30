using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoyatyPointSystem.Models;

namespace LoyatyPointSystem.BusinessLogic
{
    public class RoleBL
    {
        public void CreateRole(Models.EmployeeRole model)
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                Models.EmployeeRole role = new Models.EmployeeRole();


                role.RoleName = model.RoleName;
                db.EmployeeRoles.Add(role);
                db.SaveChanges();

            }
        }

        
    }
}