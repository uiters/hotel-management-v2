using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class BillDetails
    {
        private int idBill;
        private int idService;
        private int count;
        private int totalPrice;
        public BillDetails(DataRow data)
        {
            IdBill = (int)data["IdBill"];
            IdService = (int)data["idService"];
            Count = (int)data["count"];
            TotalPrice = (int)data["totalPrice"];
        }
        public int IdBill { get => idBill; set => idBill = value; }
        public int IdService { get => idService; set => idService = value; }
        public int Count { get => count; set => count = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
