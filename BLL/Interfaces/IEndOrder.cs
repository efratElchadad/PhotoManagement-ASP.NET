using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEndOrder
    {
         void SendEmail(string toEmail, string subject, string body);
        void sendMessage(UserDetails userDetails);
        void CloseOrder(UserDetails userDetails);
        void changeStatus(UserDetails userDetails);
    }
}
