using DAL.Classes;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;



namespace BLL.Services
{
    public static class SessionHelper
    {

        public static void SetUserDetails(this ISession session, UserDetails userDetails)
        {
            session.SetString("UserDetails", JsonConvert.SerializeObject(userDetails));
        }

        public static UserDetails GetUserDetails(this ISession session)
        {
            var data = session.GetString("UserDetails");
            return string.IsNullOrEmpty(data) ? new UserDetails() : JsonConvert.DeserializeObject<UserDetails>(data);
        }
    }
}
