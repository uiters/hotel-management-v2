using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    class BillInfo
    {
        private int idService;
        private int idBill;
        private int count;
        public BillInfo(int idService, int idBill, int count)
        {
            this.IdService = idService;
            this.IdBill = idBill;
            this.Count = count;
        }
        public BillInfo(DataRow row)
        {
            this.IdService = (int)row["IDService"];
            this.IdBill = (int)row["IDBill"];
            this.Count = (int)row["Count"];
        }
        public int IdService { get => idService; set => idService = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int Count { get => count; set => count = value; }
    }
}
