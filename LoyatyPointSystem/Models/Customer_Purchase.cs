//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoyatyPointSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer_Purchase
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<decimal> LoyaltyPoints { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string RecieptNo { get; set; }
        public Nullable<System.DateTime> RecieptDate { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
