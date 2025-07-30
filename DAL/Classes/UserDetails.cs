
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class UserDetails
    {
        public UserDetails() { }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CustomerCode { get; set; }
        public string OrderCode { get; set; }
        public int ImageId { get; set; }
        public string ImageSize { get; set; }
        public string OfficerName { get; set; }
        public string OfficerCode { get; set; }
        public int ProcessStatus { get; set; }
        public string ProcessDescription { get; set; } 

    }
}
