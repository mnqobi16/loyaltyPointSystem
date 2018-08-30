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
    public class ClubsBL
    {
        public List<Club> loadClubs()
        {
            // this is the load method, its returns everything from the Register table where IsDeleted = false
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                return db.Clubs.ToList();
            }
        }
    }
}