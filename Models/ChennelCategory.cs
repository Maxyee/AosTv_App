using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace aostv_dotnet_core.Models
{
    public class ChennelCategory
    {
        public int Id {get;set;}
        public string CategoryType {get;set;}
        public string LogoLink {get;set;}
        public DateTime Time {get;set;}

        
        public int CountryId {get;set;}

        public ChennelCategory()
        {
            Time = DateTime.Now;
        }

        public virtual Country Country {get;set;}
    }
}