using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoyatyPointSystem.Models;
using LoyatyPointSystem.BusinessLogic;

namespace LoyatyPointSystem
{
    public partial class Login : System.Web.UI.Page
    {
        private EmployeeBL business = new EmployeeBL();
        protected void Page_Load(object sender, EventArgs e)
        {
              
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {

                string username = txtUsername.Text;
                string password = txtPassword.Text;

                var user = db.Employees.ToList().FirstOrDefault(x => x.Username == username && x.Password == txtPassword.Text.Trim());

                if (user != null)
                {
                    Session["UserId"] = user.ID;

                    //Decrypt password

                    Session["UserName"] = user.Username;
                    Session["UserRole"] = user.RoleID;
                    Session["Name"] = user.Name;
                    //Session["UserId"] = user.UserId;

                    

                   // string dencryptedPassword = business.Decrypt(user.Password);

                    var pass = db.Employees.ToList().FirstOrDefault(x => x.Username == username && x.Password == txtPassword.Text.Trim());

                    if (password == pass.Password)
                    {
                        //Store user login details in Session 

                        Session["UserName"] = user.Username;
                        //Session["UserRole"] = user.RoleID;
                        Session["UserId"] = user.ID;
                        Session["Name"] = user.Name;




                        if (user.RoleID == 1)
                        {
                            Session["UserRole"] = "General Employee";
                            Response.Redirect("~/Views/ViewAllCustomers.aspx?");

                        }
                        else if (user.RoleID == 2)
                        {
                            Session["UserRole"] = "Administrator";
                            Response.Redirect("~/Views/ViewAllCustomers.aspx?");
                        }


                        else if (user.RoleID == 3)
                        {
                            Session["UserRole"] = "Supervisor";
                            Response.Redirect("~/Views/ViewAllCustomers.aspx?");
                        }
                        else
                        {
                            lblErrorMessage.Visible = true;
                            lblErrorMessage.Text = "The password provided is incorrect.";

                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Correct UserName and Password!')", true);

                        }
                    }

                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Correct UserName and Password!')", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Correct UserName and Password!')", true);

                }
            }
        }
    }
}