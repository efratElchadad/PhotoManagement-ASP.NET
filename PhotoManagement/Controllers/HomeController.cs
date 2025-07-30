using Microsoft.AspNetCore.Mvc;
using PhotoManagement.Models;
using System.Diagnostics;
using BLL;
using BLL.Classes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DAL.Classes;
using BLL.Interfaces;

namespace PhotoManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomersService _customerServices;
        private readonly IOrderManagmentService _orderManagementServices;
        public HomeController(ICustomersService customerServices , IOrderManagmentService orderManagementServices)
        {
            _customerServices = customerServices;
            _orderManagementServices = orderManagementServices;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Input()
        {
            return View();
        }


        public IActionResult LoginOfficer(string code)
        {
            return View();
        }
        public IActionResult LoginCustomers() {
            return View();
        }
        public IActionResult EnterOfficerCode()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
