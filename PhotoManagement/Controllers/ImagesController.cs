using Microsoft.AspNetCore.Mvc;

using BLL.Interfaces;
namespace PhotoManagement.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IimageService _imageService;
        private readonly IOrderManagmentService _orderManagmentService;
        public ImagesController(IimageService imageService, IOrderManagmentService orderManagmentService)
        {
            _imageService = imageService;
            _orderManagmentService = orderManagmentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendButtonClick(string buttonValue)
        {
            _imageService.SelectSize(buttonValue);
            return RedirectToAction("printMonitor", "Orders");
        }

        [HttpGet]
        public IActionResult HandleButtonClick()
        {
            return View();
        }
    }
}
