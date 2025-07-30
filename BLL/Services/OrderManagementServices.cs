using BLL.Interfaces;
using DAL.Classes;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace BLL.Services
{
    public class OrderManagementServices : IOrderManagmentService
    {

        private static UserDetails UserDetails = new UserDetails();
        private readonly IGenericActionsDB<OrderManagement> _orderManagementDB;
        private readonly SpecificActionsBD _SpecificActionsBD;
        private readonly IEndOrder _endOrder;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderManagementServices(IGenericActionsDB<OrderManagement> actionsDB, SpecificActionsBD SpecificActionsBD,IEndOrder endOrder, IHttpContextAccessor httpContextAccessor)
        {
            _orderManagementDB = actionsDB;
            _SpecificActionsBD = SpecificActionsBD;
            _endOrder = endOrder;
            _httpContextAccessor = httpContextAccessor;
        }
        public void AssignOrders(UserDetails userDetails)
        {
            _SpecificActionsBD.AssignOrdersToOfficers(userDetails);
            UserDetails.OfficerCode = userDetails.OfficerCode;
            UserDetails = userDetails;
        }
        public void OpenOrder(UserDetails userDetails)
        {
            OrderManagement o = new OrderManagement(userDetails.OrderCode,"OFF1",userDetails.CustomerCode);
            userDetails.OfficerCode = o.OfficerCode;
            _orderManagementDB.Create(o);
        }
        public List<OrderManagement> getOrdersByOfficerCode(string code)
        {

            List<OrderManagement> Allorders = _SpecificActionsBD.GetByOfficerCode(code);
            List<OrderManagement> orders = new List<OrderManagement>();
            foreach (var i in Allorders){
                if (i.ProcessStatus == 1)
                    orders.Add(i);
            }
            return orders;
        }
        public void ChangeStatus(string orderCode)
        {
            var sessionData = _httpContextAccessor.HttpContext.Session.GetString("UserDetails");

            if (string.IsNullOrEmpty(sessionData))
                throw new Exception("No user details found in session.");
            
            UserDetails userDetails = JsonConvert.DeserializeObject<UserDetails>(sessionData);
            _orderManagementDB.Update<string>(orderCode, "ProcessStatus", 2);
            userDetails.ProcessStatus = 2;
            userDetails.ProcessDescription = "בוצע";
            _endOrder.CloseOrder(userDetails);
            _httpContextAccessor.HttpContext.Session.SetString("UserDetails", JsonConvert.SerializeObject(userDetails));
        }
        public string PrintOrdersDetails()
        {
            var sessionData = _httpContextAccessor.HttpContext.Session.GetString("UserDetails");

            if (string.IsNullOrEmpty(sessionData))
            {
                throw new Exception("No user details found in session.");
            }
            return sessionData;
        }

    }
}

