﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoyatyPointSystem.Models;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;

namespace LoyatyPointSystem.BusinessLogic
{
    public class GenderBL
    {
        public void CreateGender(Models.Gender model)
        {
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                Models.Gender ger = new Models.Gender();

                ger.GenderName = model.GenderName;

                db.Genders.Add(ger);
            }
        }

        public List<Gender> LoadGender()
        {
            // this is the load method, its returns everything from the Register table where IsDeleted = false
            using (LoyaltyPointSystemEntities db = new LoyaltyPointSystemEntities())
            {
                return db.Genders.ToList();
            }
        }
    }
}