using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace aostv_dotnet_core.Models
{
    public class ChennelList
    {
        public int Id {get;set;}
        public string ChennelName {get;set;}
        public string LogoLink {get;set;}
        public DateTime Time {get;set;}

        
        public int ChennelCategoryId {get;set;}
        public virtual ChennelCategory ChennelCategory {get;set;}

        
        public ChennelList()
        {
            Time = DateTime.Now;
        }

        
        public virtual ICollection<Link> Links {get;set;}
    }
}