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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Customer_Purchase = new HashSet<Customer_Purchase>();
        }
    
        public int ID { get; set; }
        public string Employee_No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<int> GenderID { get; set; }
        public string ID_No { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string ClubName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer_Purchase> Customer_Purchase { get; set; }
        public virtual EmployeeRole EmployeeRole { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
