using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoyatyPointSystem.BusinessLogic;
using LoyatyPointSystem.Models;

namespace LoyatyPointSystem.Views
{
    public partial class EmployeeRegister : System.Web.UI.Page
    {
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
                loadEmployeeRole();
                loadEmployeeGender();
                loadClubs();
            }
        }

        public void loadEmployeeRole()
        {
            EmployeeRoleBL business = new EmployeeRoleBL();

            List<EmployeeRole> list = business.LoadRole();
            ddlEmployeeRole.DataSource = list;
            ddlEmployeeRole.DataTextField = "RoleName";
            ddlEmployeeRole.DataValueField = "RoleID";

            ddlEmployeeRole.DataBind();
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

        public void loadClubs()
        {
            ClubsBL business = new ClubsBL();

            List<Club> list = business.loadClubs();
            ddlLoungeName.DataSource = list;
            ddlLoungeName.DataTextField = "ClubName";
            ddlLoungeName.DataValueField = "ID";

            ddlLoungeName.DataBind();
        }
        public string GetEmployeeNo()
        {
            string surname = txtSurname.Text;
            string name = txtName.Text;
            int year = Convert.ToInt16(DateTime.Now.Year);
            string time = Convert.ToString(DateTime.Now.TimeOfDay);

            string result = surname.Substring(0, 2) + name.Substring(0, 2) + year + time;
            
            return result;
        }

        public void SaveEmployee()
        {

            EmployeeBL busEmp = new EmployeeBL();
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                Models.Employee emp = new Models.Employee();

                emp.RoleID = Convert.ToInt16(ddlEmployeeRole.SelectedValue);
                emp.Employee_No = GetEmployeeNo();
                emp.GenderID= Convert.ToInt16(ddlGender.SelectedValue);
                emp.ID_No = txtIDNumber.Text;
                emp.Name = txtName.Text;
                emp.Password = txtPassword.Text;
                emp.Surname = txtSurname.Text;
                emp.Username = txtEmail.Text;
                emp.CellPhone = txtCellPhoneNO.Text;
                emp.Email = txtEmail.Text;
                emp.ClubName = ddlLoungeName.SelectedItem.Text;

                busEmp.CreateEmployee(emp);
            }
        }

        public void btnRegisterEmployee_ServerClick(object sender, EventArgs e)
        {
            try
            {
                SaveEmployee();
                Response.Redirect("~/Views/VieawAllStaff.aspx");
            }

            catch
            {

            } 
    
        }




    }
}