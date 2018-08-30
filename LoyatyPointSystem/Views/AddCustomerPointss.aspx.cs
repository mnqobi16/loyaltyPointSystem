using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoyatyPointSystem.Models;
using LoyatyPointSystem.BusinessLogic;
using System.Drawing;
using System.IO;
using QRCoder;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Globalization;

namespace LoyatyPointSystem.Views
{
    public partial class AddCustomerPoints : System.Web.UI.Page
    {
        public static int CustomerID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || string.IsNullOrEmpty(Session["UserName"].ToString()))
            {
                Response.Redirect("DashBoard.aspx?ShowDialog=yes");
            }
            else
            {
                //string type = Session["UserRole"].ToString();

                //if (type != "Admin" && type != "User" && type != "Supervisor")
                //{
                //    Response.Redirect("~/PL/Error.aspx");
                //}
            }

            CustomerID = Convert.ToInt32(Request.QueryString["CustomerID"].ToString());
            if (!IsPostBack)
            {
                LoadAddPointsDetailView();
            }

            
            // LoadAddPointsDetailView();
        }

        public void LoadAddPointsDetailView()
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {

                var list = from f in db.Customers.ToList()

                               //join e in db.Applicants.ToList() on f.ApplicationID equals e.ApplicationID
                           where (f.ID == CustomerID)

                           select new
                           {
                               f.Name,
                               f.Surname,
                               f.ID_No,
                               f.Gender.GenderName,
                               f.Email,
                               f.DateCreated,
                               f.Cell_No,
                               f.ID,
                               f.Loyalty_Points
                           };
                AddPointsCustomerDetailsView.DataSource = list;
                AddPointsCustomerDetailsView.DataBind();

            }
        }
        
        public void SaveCustomerPurchase()
        {
            CustomerPurchaseBL busEmp = new CustomerPurchaseBL();
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                Models.Customer_Purchase cusP = new Models.Customer_Purchase();
                
                cusP.Date = DateTime.Now;
                cusP.CustomerID = CustomerID;
                cusP.RecieptNo = txtRecieptNo.Text;
                

                double fee= double.Parse(txtTotalAmount.Text,CultureInfo.InvariantCulture);

                cusP.TotalPrice = (decimal)fee;

                cusP.RecieptDate = Convert.ToDateTime(txtReieptDate.Text);
                double points = 0;

                if (Convert.ToDecimal(txtTotalAmount.Text) == 100)
                {
                     points = double.Parse("10", CultureInfo.InvariantCulture);

                    cusP.LoyaltyPoints = (decimal)points;
                }
                else if (Convert.ToDecimal(txtTotalAmount.Text) == 1000)
                {
                    points = double.Parse("100", CultureInfo.InvariantCulture);
                    cusP.LoyaltyPoints =  (decimal)points;
                }
                else if (Convert.ToDecimal(txtTotalAmount.Text) < 100)
                {
                    points = double.Parse("1", CultureInfo.InvariantCulture);
                    cusP.LoyaltyPoints = (decimal)points;
                }
                else if (Convert.ToDecimal(txtTotalAmount.Text) > 1000)
                {
                    points = double.Parse("150", CultureInfo.InvariantCulture);
                    cusP.LoyaltyPoints = (decimal)points;
                }
                
                busEmp.CreateCustomerPurchase(cusP);
            }
        }

        public void UpdateCustomer()
        {
            LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities();

            CustomerBL Cusbl = new CustomerBL();

            Models.Customer Custb = new Models.Customer();
            var data = db.Customers.ToList().FirstOrDefault(x => x.ID == CustomerID);

            double points = 0;

            if (Convert.ToDecimal(txtTotalAmount.Text) == 100)
            {
                points = double.Parse("10", CultureInfo.InvariantCulture);

                Custb.Loyalty_Points = (decimal)points;
            }
            else if (Convert.ToDecimal(txtTotalAmount.Text) == 1000)
            {
                points = double.Parse("100", CultureInfo.InvariantCulture);
                Custb.Loyalty_Points = (decimal)points;
            }
            else if (Convert.ToDecimal(txtTotalAmount.Text) < 100)
            {
                points = double.Parse("1", CultureInfo.InvariantCulture);
                Custb.Loyalty_Points = (decimal)points;
            }
            else if (Convert.ToDecimal(txtTotalAmount.Text) > 1000)
            {
                points = double.Parse("150", CultureInfo.InvariantCulture);
                Custb.Loyalty_Points = (decimal)points;
            }

            Cusbl.UpdateCustomer(Custb);

        }

        public void btnAddCustomerPoints_ServerClick(object sender, EventArgs e)
        {
          
            SaveCustomerPurchase();
            UpdateCustomer();
        }
        
        public void btnOpenModal_ServerClick(object sender, EventArgs e)
        {
          
        }
        
    }
}