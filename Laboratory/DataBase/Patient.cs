//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        public int Id { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public long InsurancePolicyNumber { get; set; }
        public int TypeOfPolicy { get; set; }
        public int InsuranceCompany { get; set; }
    
        public virtual InsuranceCompany InsuranceCompany1 { get; set; }
        public virtual TypeOfInsurancePolicy TypeOfInsurancePolicy { get; set; }
        public virtual User User { get; set; }
    }
}
