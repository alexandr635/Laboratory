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
    
    public partial class AnalyzerService
    {
        public int Id { get; set; }
        public int AnalyzerId { get; set; }
        public int ServiceId { get; set; }
    
        public virtual Analyzer Analyzer { get; set; }
        public virtual Service Service { get; set; }
    }
}
