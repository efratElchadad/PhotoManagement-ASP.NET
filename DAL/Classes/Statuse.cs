using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class Statuse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // מספור אוטומטי
        public int id { get; set; }
        public int ProcessStatus { get; set; } 
        public string StatusDescription { get; set; }
        public Statuse() { }
        public Statuse(int proesessStatus,string statusDscription) { 
            ProcessStatus = proesessStatus;
            StatusDescription = statusDscription;
        }

    }

}
