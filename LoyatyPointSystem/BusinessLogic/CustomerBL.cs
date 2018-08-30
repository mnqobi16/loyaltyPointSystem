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
    public class CustomerBL
    {
        public void CreateCustomer(Models.Customer model)
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {

                Models.Customer cus = new Models.Customer();

                cus.Cell_No = model.Cell_No;
                cus.DateCreated = model.DateCreated;
                cus.Email = model.Email;
                cus.GenderID = model.GenderID;
                cus.ID_No = model.ID_No;
                cus.Loyalty_Points = model.Loyalty_Points;
                cus.Name = model.Name;
                cus.Surname = model.Surname;
                
                db.Customers.Add(cus);
                db.SaveChanges();

            }
        }

        public void UpdateCustomer(Models.Customer model)
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                var cus = db.Customers.ToList().FirstOrDefault(x => x.ID == model.ID);

                cus.ID = model.ID;
                cus.Loyalty_Points = model.Loyalty_Points;

                db.SaveChanges();
            }
        }
    }
}