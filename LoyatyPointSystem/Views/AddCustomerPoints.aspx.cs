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
using LoyatyPointSystem.Views;
using System.Drawing;
using System.IO;
using QRCoder;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Globalization;

namespace LoyatyPointSystem.Views
{
    public partial class AddCustormerPoints : System.Web.UI.Page
    {
        public static int CustomerID;

        protected void Page_Load(object sender, EventArgs e)
        {

           // string tttt = txtTotalAmount.Text;

            if (Session["UserName"] == null || string.IsNullOrEmpty(Session["UserName"].ToString()))
            {
                Response.Redirect("DashBoard.aspx?ShowDialog=yes");
            }
            else
            {
               
            }

            CustomerID = Convert.ToInt32(Request.QueryString["CustomerID"].ToString());
            if (!Page.IsPostBack)
            {
                LoadAddPointsDetailView();

                if (Session["ToDo"].ToString()== "Redeem")
                {
                    divtxtRecieptNo.Visible = false;
                    divAddpoints.Visible = false;
                    divtxtTotalAmount.Visible = false;
                    divtxtAmountToBeDeducted.Visible = true;
                }
                else
                {
                    divtxtRecieptNo.Visible = true;
                    divAddpoints.Visible = true;
                    divtxtTotalAmount.Visible = true;
                    divtxtAmountToBeDeducted.Visible = false;
                }
            }

            GenerateQrScan();
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
           //string www= labbbbb.Text;
            CustomerPurchaseBL busEmp = new CustomerPurchaseBL();
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                Models.Customer_Purchase cusP = new Models.Customer_Purchase();

                string s = txtTotalAmount.Text;

                cusP.Date = DateTime.Now;
                cusP.CustomerID = CustomerID;
                cusP.RecieptNo = txtRecieptNo.Text;


                double fee = double.Parse(txtTotalAmount.Text, CultureInfo.InvariantCulture);

                cusP.TotalPrice = (decimal)fee;
                cusP.RecieptDate = DateTime.Now;
                //cusP.RecieptDate = Convert.ToDateTime(txtReieptDate.Text.ToString("dd/m/yyyy"));
                double points = 0;

                if (Convert.ToDecimal(txtTotalAmount.Text) == 100)
                {
                    points = double.Parse("10", CultureInfo.InvariantCulture);

                    cusP.LoyaltyPoints = (decimal)points;
                }
                else if (Convert.ToDecimal(txtTotalAmount.Text) == 1000)
                {
                    points = double.Parse("100", CultureInfo.InvariantCulture);
                    cusP.LoyaltyPoints = (decimal)points;
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

            Custb.ID = data.ID;

            double points = 0;
            if (data.Loyalty_Points >= 0)
            {
                if (Convert.ToDecimal(txtTotalAmount.Text) == 100)
                {
                    points = double.Parse("10", CultureInfo.InvariantCulture);

                    Custb.Loyalty_Points = (decimal)points + data.Loyalty_Points;
                }
                else if (Convert.ToDecimal(txtTotalAmount.Text) == 1000)
                {
                    points = double.Parse("100", CultureInfo.InvariantCulture);
                    Custb.Loyalty_Points = (decimal)points +data.Loyalty_Points;
                }
                else if (Convert.ToDecimal(txtTotalAmount.Text) < 100)
                {
                    points = double.Parse("1", CultureInfo.InvariantCulture);
                    Custb.Loyalty_Points = (decimal)points + data.Loyalty_Points;
                }
                else if (Convert.ToDecimal(txtTotalAmount.Text) > 1000)
                {
                    points = double.Parse("150", CultureInfo.InvariantCulture);
                    Custb.Loyalty_Points = (decimal)points + data.Loyalty_Points;
                }

            }
            else
            {
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
            }
            Cusbl.UpdateCustomer(Custb);

        }

        public void UpdateRedeemPointsCustomer()
        {
            LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities();

            CustomerBL Cusbl = new CustomerBL();

            Models.Customer Custb = new Models.Customer();
            var data = db.Customers.ToList().FirstOrDefault(x => x.ID == CustomerID);

            Custb.ID = data.ID;
            double points = 0;

            if (data.Loyalty_Points > 0)
            {
                if (Convert.ToDecimal(txtAmountToBeDeducted.Text) == 100)
                {
                    if(data.Loyalty_Points>=10)
                    {
                        points = double.Parse("10", CultureInfo.InvariantCulture);
                        Custb.Loyalty_Points = data.Loyalty_Points - (decimal)points;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insufficient Points')", true);
                    }

                    
                }
                else if (Convert.ToDecimal(txtAmountToBeDeducted.Text) == 1000)
                {
                    if (data.Loyalty_Points >= 100)
                    {
                        points = double.Parse("100", CultureInfo.InvariantCulture);
                        Custb.Loyalty_Points = data.Loyalty_Points - (decimal)points;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insufficient Points')", true);
                    }
                    
                }
                else if (Convert.ToDecimal(txtAmountToBeDeducted.Text) < 100)
                {
                    if (data.Loyalty_Points >= 1)
                    {
                        points = double.Parse("1", CultureInfo.InvariantCulture);
                        Custb.Loyalty_Points = data.Loyalty_Points - (decimal)points;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insufficient Points')", true);
                    }
                    
                }
                else if (Convert.ToDecimal(txtAmountToBeDeducted.Text) > 1000)
                {
                    if (data.Loyalty_Points >= 150)
                    {
                        points = double.Parse("150", CultureInfo.InvariantCulture);
                        Custb.Loyalty_Points = data.Loyalty_Points - (decimal)points;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insufficient Points')", true);
                    }
                    
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You don't have points to Redeem')", true);
            }


            Cusbl.UpdateCustomer(Custb);

        }

        protected void btnAddCustomerPoints_ServerClick(object sender, EventArgs e)
        {

            if (Session["ToDo"].ToString() == "Redeem")
            {
                UpdateRedeemPointsCustomer();
            }
            else
            {
                SaveCustomerPurchase();
                UpdateCustomer();
            }
            
            LoadAddPointsDetailView();
        }

        public void btnOpenModal_ServerClick(object sender, EventArgs e)
        {

        }


        protected void GenerateQrScan()
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                var data = db.Customers.ToList().FirstOrDefault(x => x.ID == CustomerID);

                string code = data.ID_No + data.Name + data.Surname;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }

                PlaceHolder1.Controls.Add(imgBarCode);



                
                    //EmailBL EML = new EmailBL();

                    //EML.Email("You have successfully Registered for Loyalty Points: " + data.Name + " " + data.Surname, "Dear" + data.Name

                    //                + "<br/> <br/>"

                    //                + "This is your QrScan :" + "< img src = " + imgBarCode + " >" + "<br/>" +
                    //               "Your application has been Approve. " + "<br/>" +


                    //               "<br/>" + "This is an automatically generated email. Please do not reply. " +

                    //           "<br/> <br/>" + "For more details feel free to call us on 031 455 4576." + "<br/> <br/>" +
                    //           "Regards" + "<br/>" +
                    //           "Loyalty Point", data.Email, "Loyalty Point", "menziwa1662@gmail.com");

                }
            }

        }
    }
}