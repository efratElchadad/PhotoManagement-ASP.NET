using BLL.Interfaces;
using DAL.Classes;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace BLL.Services
{

    public class ImageService : IimageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericActionsDB<SavingImages> _SavingImagesDB;
        private readonly IOrderManagmentService _OrderManagmentService;
        private readonly IGenericActionsDB<OrderManagement> _orderManagementDB;
        public ImageService(IGenericActionsDB<SavingImages> SavingImagesDB, IOrderManagmentService orderManagmentService, IGenericActionsDB<OrderManagement> orderManagementDB, IHttpContextAccessor httpContextAccessor)
        {
            _SavingImagesDB = SavingImagesDB;
            _OrderManagmentService = orderManagmentService;
            _orderManagementDB = orderManagementDB;
            _httpContextAccessor = httpContextAccessor;
        }

        private readonly string filePath = @"C:\Users\USER\Desktop\MISC\AUTPRINT.MRK";

        public void GetImageBase64(UserDetails userDetails)
        {
            SavingImages sav = new SavingImages(userDetails.OrderCode, new byte[1], "1");
            _SavingImagesDB.Create(sav);
            userDetails.ImageId = sav.Id;
            userDetails.ProcessDescription = "ההזמנה נקלטה במערכת והועברה להמשך ביצוע.";
            _httpContextAccessor.HttpContext.Session.SetString("UserDetails", JsonConvert.SerializeObject(userDetails));
        }

        public string GetMimeType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream"
            };
        }


        public void SelectSize(string imageSize)
        {
            var sessionData = _httpContextAccessor.HttpContext.Session.GetString("UserDetails");

            if (string.IsNullOrEmpty(sessionData))
            {
                throw new Exception("No user details found in session.");
            }

            UserDetails userDetails = JsonConvert.DeserializeObject<UserDetails>(sessionData);

            if (imageSize.Equals("15*18"))
                _SavingImagesDB.Update<int>(userDetails.ImageId, "Size", "15*18");
            else if (imageSize.Equals("23*31"))
                _SavingImagesDB.Update<int>(userDetails.ImageId, "Size", "23*31");
            else
                _SavingImagesDB.Update<int>(userDetails.ImageId, "Size", "45*60");

            userDetails.ImageSize = imageSize;
            _OrderManagmentService.AssignOrders(userDetails);
            _httpContextAccessor.HttpContext.Session.SetString("UserDetails", JsonConvert.SerializeObject(userDetails));

        }
    }
}