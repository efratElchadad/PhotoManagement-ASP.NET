using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IimageService
    {
         string GetMimeType(string filePath);
        void GetImageBase64(UserDetails userDetails);
        void SelectSize(string imageSize);


    }
}
