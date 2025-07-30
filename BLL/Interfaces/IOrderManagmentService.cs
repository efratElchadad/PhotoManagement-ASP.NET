using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderManagmentService
    {
        void AssignOrders(UserDetails userDetails);
        void OpenOrder(UserDetails userDetails);
        List<OrderManagement> getOrdersByOfficerCode(string code);
        string PrintOrdersDetails();
        void ChangeStatus(string orderCode);

    }
}
