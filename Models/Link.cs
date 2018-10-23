using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace aostv_dotnet_core.Models
{
    public class Link
    {
        public int Id {get;set;}
        public string LinkName {get;set;}
        public string LinkString {get;set;}
        public string Type {get;set;}
        public string Quality {get;set;}
        public DateTime Time {get;set;}

        public int ChennelListId {get;set;}
        public virtual ChennelList ChennelList {get;set;}
        public Link()
        {
            Time = DateTime.Now;
        }

        
    }
}