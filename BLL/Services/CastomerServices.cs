using BLL.Interfaces;
using DAL.Classes;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace BLL.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IGenericActionsDB<Customers> _customerDB;
        private readonly IimageService _imageService;
        private readonly IOrderManagmentService _orderManagmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomersService(IGenericActionsDB<Customers> customerDB, IimageService imageService, IOrderManagmentService orderManagmentService, IHttpContextAccessor httpContextAccessor)
        {
            _customerDB = customerDB;
            _imageService = imageService;
            _orderManagmentService = orderManagmentService;
            _httpContextAccessor = httpContextAccessor;
        }
        public void SetCustomer(string _NameE, string _Phone, string Email)
        {
            string cusCode = UniqCode.GenerateNewRandom();
            string ordCode = UniqCode.GenerateNewRandom();

            Customers newCustomer = new Customers(cusCode, _NameE, _Phone, Email);
            _customerDB.Create(newCustomer);

            UserDetails userDetails = new UserDetails
            {
                Email = Email,
                CustomerCode = cusCode,
                OrderCode = ordCode,
                Name = _NameE,
                Phone = _Phone
            };

            _orderManagmentService.OpenOrder(userDetails);
            _imageService.GetImageBase64(userDetails);
            _httpContextAccessor.HttpContext.Session.SetString("UserDetails", JsonConvert.SerializeObject(userDetails));
        }
    }



 }
