using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoyatyPointSystem.BusinessLogic;
using LoyatyPointSystem.Models;
using System.Drawing;
using System.IO;
using QRCoder;
using AForge;
using System.Drawing.Imaging;
namespace LoyatyPointSystem.Views
{
    public partial class CustomerRegister : System.Web.UI.Page
    {

       //public static Image img;

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

            if (!Page.IsPostBack)
            {
                loadEmployeeGender();
            }
        }
        
        public void loadEmployeeGender()
        {
            GenderBL business = new GenderBL();

            List<Gender> list = business.LoadGender();
            ddlGender.DataSource = list;
            ddlGender.DataTextField = "GenderName";
            ddlGender.DataValueField = "ID";

            ddlGender.DataBind();
        }
        public void SaveCustomer()
        {
            CustomerBL busEmp = new CustomerBL();
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                Models.Customer emp = new Models.Customer();
                
                emp.GenderID = Convert.ToInt16(ddlGender.SelectedValue);
                emp.ID_No = txtIDNumber.Text;
                emp.Name = txtName.Text;
                emp.Surname = txtSurname.Text;
                emp.Cell_No = txtCellPhoneNO.Text;
                emp.Email = txtEmail.Text;

                busEmp.CreateCustomer(emp);
            }
        }

        public void btnRegisterCustomer_ServerClick(object sender, EventArgs e)
        {
            try
            {
                SaveCustomer();
                GenerateQrScan();

                ddlGender.SelectedIndex = 0;
                txtIDNumber.Text=string.Empty;
                txtName.Text=string.Empty; 
                txtSurname.Text= string.Empty; 
                txtCellPhoneNO.Text= string.Empty; 
                txtEmail.Text=string.Empty; 

                Response.Redirect("~/Views/ViewAllCustomers.aspx");
            }
            catch
            {

            }
        }

        protected void GenerateQrScan()
        {
            string code = txtIDNumber.Text+ txtName.Text+ txtSurname.Text;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData= qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
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



                using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
                {
                    EmailBL EML = new EmailBL();

                    EML.Email("You have successfully Registered for Loyalty Points: " +txtName.Text+" "+txtSurname.Text, "Dear"+ txtName.Text

                                    + "<br/> <br/>"

                                    + "This is your QrScan :" + "< img src = "+ imgBarCode + " >" + "<br/>" +
                                   "Your application has been Approve. " + "<br/>" +


                                   "<br/>" + "This is an automatically generated email. Please do not reply. " +

                               "<br/> <br/>" + "For more details feel free to call us on 031 455 4576." + "<br/> <br/>" +
                               "Regards" + "<br/>" +
                               "Loyalty Point", txtEmail.Text, "Loyalty Point", "menziwa1662@gmail.com");

                }
            }
            
        }

        public void sendEmail()
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                EmailBL EML = new EmailBL();

                EML.Email("Status Notification for Reference No: " + "refNo", "Dear Applicant"

                                + "<br/> <br/>"

                                + "Your Reference is :" + "refNo" + "<br/>" +
                               "Your application has been Approve. " + "<br/>" +


                               "<br/>" + "This is an automatically generated email. Please do not reply. " +

                           "<br/> <br/>" + "For more details feel free to call us on 031 455 4576." + "<br/> <br/>" +
                           "Regards" + "<br/>" +
                           "Ethekwini Municipality", "menziwa1662@gmail.com", "Ethekwini Municipality", "menziwa1662@gmail.com");

            }
        }

    }
}