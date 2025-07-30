using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class OrderManagement
    {
        [Key]
        public string OrderCode { get; set; }
        public int ProcessStatus { get; set; }

        public string OfficerCode { get; set; }
        public string CustomerCode { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderManagement() { }
        public OrderManagement(string orderCode, string officerCode, string customerCode)
        {
            ProcessStatus = 1;
            OfficerCode = officerCode;
            CustomerCode = customerCode;
            OrderCode = orderCode;
            OrderDate = DateTime.Now;
        }



    }
}
