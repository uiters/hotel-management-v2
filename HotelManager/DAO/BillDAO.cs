using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public int GetIdBillMax()
        {
            string query = "USP_GetIdBillMax";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }
        public int GetIdBillFromIdRoom(int idRoom)
        {
            string query = "USP_GetIdBillFromIdRoom @idRoom";
            DataRow dataRow= DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom }).Rows[0];
            Bill bill = new Bill(dataRow);
            return bill.Id;
        }
        
        public bool IsExistsBill(int idRoom)// > 0 Tồn tại Bill
        {
            string query = "USP_IsExistBillOfRoom @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom }).Rows.Count > 0;
        }
        public bool InsertBill(int idReceiveRoom, string staffSetUp)
        {
            string query = "USP_InsertBill @idReceiveRoom , @staffSetUp";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idReceiveRoom, staffSetUp }) > 0;
        }
        public DataTable ShowBill(int idRoom)
        {
            string query = "USP_ShowBill @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom });
        }
        public DataTable ShowBillPreView(int idBill)
        {
            string query = "USP_ShowBillPreView @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idBill });
        }
        public DataRow ShowBillRoom(int idRoom)
        {
            string query = "USP_ShowBillRoom @getToday , @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { DateTime.Now.Date, idRoom }).Rows[0];
        }
        public bool UpdateRoomPrice(int idBill)
        {
            string query = "USP_UpdateBill_RoomPrice @idBill";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill }) > 0;
        }
        public bool UpdateServicePrice(int idBill)
        {
            string query = "USP_UpdateBill_ServicePrice @idBill";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill }) > 0;
        }
        public bool UpdateOther(int idBill,int discount)
        {
            string query = "USP_UpdateBill_Other @idBill , @discount";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill,discount }) > 0;
        }
        public static BillDAO Instance { get { if (instance == null) instance = new BillDAO();return instance; }
            private set => instance = value; }
    }
}
