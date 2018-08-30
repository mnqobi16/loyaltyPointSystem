using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoyatyPointSystem.Models;

namespace LoyatyPointSystem.Views
{
    public partial class ViewAllCustomers : System.Web.UI.Page
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

            if (IsPostBack == false)
            {
                LoadGrid();
            }
            
        }

        public void LoadGrid()
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {

                var list = from f in db.Customers.ToList()

                           

                           //join e in db.Applicants.ToList() on f.ApplicationID equals e.ApplicationID
                           //where (f.DAO_Approval == false && f.DM_Approval == false && f.ApplicationTypeID == 2)

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

                           };
                gvCustomers.DataSource = list;

                gvCustomers.DataBind();



            }

        }

        public void LoadAddPointsDetailView()
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {

                var list = from f in db.Customers.ToList()



                       //join e in db.Applicants.ToList() on f.ApplicationID equals e.ApplicationID
                         where (f.ID== CustomerID)

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
                           };
                AddPointsCustomerDetailsView.DataSource = list;
                AddPointsCustomerDetailsView.DataBind();

            }
        }

        public void btnaddpoint_ServerClick(object sender, EventArgs e)
        {

            LoadAddPointsDetailView();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "openAddModal()", true);
        }
        
        protected void gvCustomers_Commands(object sender, GridViewCommandEventArgs e)
        {

            string commandName = e.CommandName;

            // int index = 0;
            // string Id = GridView1.DataKeys[myRow.RowIndex].Value.ToString();

            if (commandName == "Add")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = gvCustomers.Rows[index];

                 CustomerID = Convert.ToInt16(row.Cells[0].Text);
                Session["ToDo"] = "Add";

                Response.Redirect("AddCustomerPoints.aspx?CustomerID=" + CustomerID);
                
            }
            else if (commandName == "Redeem")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = gvCustomers.Rows[index];

                int CustomerID = Convert.ToInt16(row.Cells[0].Text);

                
                Session["ToDo"] = "Redeem";

                Response.Redirect("AddCustomerPoints.aspx?CustomerID=" + CustomerID);


            }
        }

        
        protected void gvCustomers_PreRender(object sender, EventArgs e)
        {
           // LoadAddPointsDetailView();
            if (gvCustomers.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gvCustomers.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gvCustomers.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gvCustomers.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

    }
}