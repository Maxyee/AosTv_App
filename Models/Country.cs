using System;
using System.Collections.Generic;

namespace aostv_dotnet_core.Models
{
    public class Country
    {
        public int Id {get;set;}
        public string CountryName {get;set;}
        public string LogoLink {get;set;}
        public DateTime Time {get;set;}

        public Country(){
            Time = DateTime.Now;
        }

        public virtual ICollection<ChennelCategory> ChennelCategorys {get;set;}
    }
}