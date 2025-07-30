
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PhotoManagement.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _customerServices;
        public CustomersController(ICustomersService customerServices){
            _customerServices = customerServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetNewCustomer(string name, string phone, string email){
            _customerServices.SetCustomer(name, phone, email);
            return RedirectToAction("HandleButtonClick","Images");
        }
    }
}
