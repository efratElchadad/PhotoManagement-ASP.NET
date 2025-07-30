using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class Customers
    {
        [Key]
        public string CustomerCode { get; set; }//מפתח ראשי
        public string NameE { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public Customers(string CustomerCode, string NameE, string Phone,string Email)
        {
            this.CustomerCode = CustomerCode;
            this.NameE = NameE;
            this.Phone = Phone;
            this.Email = Email;
        }
    }
}
