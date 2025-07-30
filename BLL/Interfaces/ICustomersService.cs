using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICustomersService
    {
        void SetCustomer(string _NameE, string _Phone, string Email);
    }
}
