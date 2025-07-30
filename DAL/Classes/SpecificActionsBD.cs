using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class SpecificActionsBD
    {
        private readonly CollegeDBContext _context;
        private readonly IGenericActionsDB<OrderManagement> _OrderDB;
        private readonly IGenericActionsDB<Officer> _OfficerDB;
        public SpecificActionsBD(CollegeDBContext context, IGenericActionsDB<OrderManagement> OrderDB, IGenericActionsDB<Officer> OfficerDB) { 
            _context = context;
            _OrderDB = OrderDB;
            _OfficerDB = OfficerDB;
        }
        public void AssignOrdersToOfficers(UserDetails userDetails)
        {
            var availableOfficer = _context.Officer
                .Select(of => new{
                    OfficerCode = of.OfficerCode,
                    OrderCount = _context.OrderManagement.Count(o => o.OfficerCode == of.OfficerCode),
                    officerName = of.NameE
                })
                .OrderBy(x => x.OrderCount) 
                .FirstOrDefault();
            if (availableOfficer == null)
                throw new ArgumentException($" availableOfficer not found on the DB, make sure you have officers in the system:)");
            _OrderDB.Update<string>(userDetails.OrderCode, "OfficerCode", availableOfficer.OfficerCode);
            userDetails.OfficerName = availableOfficer.officerName;
            userDetails.OfficerCode = availableOfficer.OfficerCode;
        }
        public List<OrderManagement> GetByOfficerCode(string officerCode)
        {
            List<OrderManagement> allOrders = new List<OrderManagement>();
            allOrders = _context.OrderManagement.Where(o => o.OfficerCode.Equals(officerCode)).ToList();
            Console.WriteLine(allOrders.Count());
            return allOrders;
        }
    }
}
