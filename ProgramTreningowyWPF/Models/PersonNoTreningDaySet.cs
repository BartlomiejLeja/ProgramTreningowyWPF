//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgramTreningowyWPF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonNoTreningDaySet
    {
        public PersonNoTreningDaySet()
        {

        }

        public PersonNoTreningDaySet(DateTime? date, string diet, int personSetId, double? weight)
        {
            Date = date;
            Diet = diet;
            PersonSetId = personSetId;
            Weight = weight;
        }
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<double> Weight { get; set; }
        public string Diet { get; set; }
        public int PersonSetId { get; set; }
    
        public virtual PersonSet PersonSet { get; set; }
    }
}
