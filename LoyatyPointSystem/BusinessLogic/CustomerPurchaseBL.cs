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
    public class CustomerPurchaseBL
    {
        public void CreateCustomerPurchase(Models.Customer_Purchase model)
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                Models.Customer_Purchase CusPur = new Models.Customer_Purchase();

                CusPur.Date = model.Date;
                CusPur.CustomerID = model.CustomerID;
                CusPur.EmployeeID = model.EmployeeID;
                CusPur.LoyaltyPoints = model.LoyaltyPoints;
                CusPur.TotalPrice = model.TotalPrice;
                CusPur.RecieptDate = model.RecieptDate;
                CusPur.RecieptNo = model.RecieptNo;

                db.Customer_Purchase.Add(CusPur);
            }
        }
    }
}