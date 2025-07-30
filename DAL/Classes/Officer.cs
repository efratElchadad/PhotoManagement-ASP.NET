using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class Officer
    {
        [Key]
        public string OfficerCode { get; set; }//מפתח ראשי
        public string NameE { get; set; }
        public string Phone { get; set; }
        public Officer() { }    
        public Officer(string OfficerCode, string NameE, string Phone)
        {
            this.OfficerCode = OfficerCode;
            this.NameE = NameE;
            this.Phone = Phone;
        }

    }
}
