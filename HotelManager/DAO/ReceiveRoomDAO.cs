using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class ReceiveRoomDAO
    {
        private static ReceiveRoomDAO instance;
        private ReceiveRoomDAO() { }
        public bool InsertReceiveRoom(int idBookRoom, int idCustomer, DateTime dateOfReceive, DateTime dateOfPay)
        {
            string query = "exec USP_InsertReceiveRoom  @idBookRoom , @idCustomer , @DateOfReceive , @DateOfPay";
            int count = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBookRoom, idCustomer, dateOfReceive, dateOfPay });
            return count > 0;
        }
        public int GetIDReceiveRoom(int idBookRoom, int idCustomer)
        {
            string query = "exec USP_GetIDReceiveRoom @idBookRoom , @idCustomer";
            object id = DataProvider.Instance.ExecuteScalar(query, new object[] { idBookRoom, idCustomer });
            return (int)id;

        }
        public DataTable ShowReceiveInfo()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_ShowReceiveRoomInfo");
            return data;
        }
        public static ReceiveRoomDAO Instance { get { if (instance == null) instance = new ReceiveRoomDAO(); return instance; }
            private set => instance = value; }
    }
}
