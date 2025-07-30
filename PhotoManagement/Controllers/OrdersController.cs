using BLL.Classes;
using BLL.Interfaces;
using DAL.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace PhotoManagement.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICustomersService _customerServices;
        private readonly IOrderManagmentService _orderManagementServices;
        private readonly IEndOrder _endOrder;
        public OrdersController(ICustomersService customerServices, IOrderManagmentService orderManagementServices, IEndOrder endOrder)
        {
            _customerServices = customerServices;
            _orderManagementServices = orderManagementServices;
            _endOrder = endOrder;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewOfficerOrders()
        {
            return View();
        }
        public void ChangeStatus(string orderCode)
        {
            _orderManagementServices.ChangeStatus(orderCode);
            Console.WriteLine("in ChangeStatus function!!!!!");
        }

        public IActionResult GetJSONOfOrders(string officerCode)
        {
            List<OrderManagement> orders = _orderManagementServices.getOrdersByOfficerCode(officerCode);
            return Json(orders);
        }

        public IActionResult printMonitor()
        {
            string jsonData = _orderManagementServices.PrintOrdersDetails();
            JObject jsonObject = JObject.Parse(jsonData);  
            return View(jsonObject);
        }


    }
}
