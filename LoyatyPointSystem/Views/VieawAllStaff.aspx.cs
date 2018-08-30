using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoyatyPointSystem.Models;

namespace LoyatyPointSystem.Views
{
    public partial class VieawAllStaff : System.Web.UI.Page
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

            if (IsPostBack == false)
            {
                LoadGrid();
            }
        }

        public void LoadGrid()
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {

                var list = from f in db.Employees.ToList()



                               //join e in db.Applicants.ToList() on f.ApplicationID equals e.ApplicationID
                               //where (f.DAO_Approval == false && f.DM_Approval == false && f.ApplicationTypeID == 2)

                           select new
                           {
                               f.Name,
                               f.Surname,
                               f.ID_No,
                               f.Gender.GenderName,
                               f.Email,
                               f.CellPhone,
                               f.EmployeeRole.RoleName,
                               f.Employee_No,
                               f.Username,
                               f.ID,

                           };
                gvStaff.DataSource = list;
                gvStaff.DataBind();
            }

        }

        protected void AssessmentOfficerQueeGrid_Commands(object sender, GridViewCommandEventArgs e)
        {

            string commandName = e.CommandName;
            // int index = 0;
            // string Id = GridView1.DataKeys[myRow.RowIndex].Value.ToString();
            if (commandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = gvStaff.Rows[index];

                Session["page"] = "AO";

                Response.Redirect("~/ApplicationDetails.aspx?ApplicationID=" + row.Cells[0].Text);

            }

            //  ee= e;
        }

        protected void gvStaff_PreRender(object sender, EventArgs e)
        {
            //LoadGrid();
            if (gvStaff.Rows.Count > 0)
            {
                //Replace the <td> with <th> and adds the scope attribute
                gvStaff.UseAccessibleHeader = true;

                //Adds the <thead> and <tbody> elements required for DataTables to work
                gvStaff.HeaderRow.TableSection = TableRowSection.TableHeader;

                //Adds the <tfoot> element required for DataTables to work
                gvStaff.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}