
using System.Net.Mail;
using System.Net;
using DAL.Classes;
using DAL.Interfaces;
using BLL.Interfaces;

namespace BLL.Services
{
    public class EndOrder: IEndOrder
    {
        private readonly IGenericActionsDB<OrderManagement> _orderManagementDB;
        public EndOrder( IGenericActionsDB<OrderManagement> orderManagementDB){
            _orderManagementDB = orderManagementDB;
        }
        public void CloseOrder(UserDetails userDetails)
        {
            sendMessage(userDetails);
            changeStatus(userDetails);
        }
        public void sendMessage(UserDetails userDetails)
        {

            string subject = "photo - order completed";
           
            string text = $"your order was completed\n " +
                           $"you can take your pictures\n " +
                           $"customer:{userDetails.Name}\n" +
                           $"status:message was sented\n" +
                           $"officer:{userDetails.OfficerName}";
            userDetails.ProcessDescription = "message was sented to the customer";

            SendEmail(userDetails.Email,subject,text);
        }
        public void changeStatus(UserDetails userDetails)
        {
            _orderManagementDB.Update<string>( userDetails.OrderCode,"ProcessStatus", 3);
        }
        public void SendEmail(string toEmail, string subject, string body)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new NetworkCredential("racheli9127@gmail.com", "arxcjjcwoagvvpbo")
            };
            try
            {
                using (var message = new MailMessage("racheli9127@gmail.com", toEmail)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
