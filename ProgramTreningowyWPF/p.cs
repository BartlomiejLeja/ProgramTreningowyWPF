//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgramTreningowyWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class p
    {
        public p (DateTime? date, string dieta, double? waga, string suplementacja = "", string ćwiczenia = "", byte[] zdjecie = null)
        {
            Dzień = date;
            Dieta = dieta;
            Waga = waga;
            Suplementacja = suplementacja;
            Zdjecie = zdjecie;

        }

        public p()
        {

            Dieta = "kurwa";
            Waga = 1;
            Suplementacja = "kurwa";
            Zdjecie = null;
        }
        public int Id { get; set; }
        public Nullable<System.DateTime> Dzień { get; set; }
        public string Dieta { get; set; }
        public string Ćwiczenia { get; set; }
        public string Suplementacja { get; set; }
        public Nullable<double> Waga { get; set; }
        public byte[] Zdjecie { get; set; }
    }
}
