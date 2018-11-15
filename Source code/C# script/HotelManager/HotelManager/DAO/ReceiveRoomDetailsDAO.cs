using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class ReceiveRoomDetailsDAO
    {
        private static ReceiveRoomDetailsDAO instance;
        private ReceiveRoomDetailsDAO() { }
        public bool InsertReceiveRoomDetails(int idReceiveRoom, int idCustomerOther)
        {
            string query = "InsertReceiveRoomDetails @idReceiveRoom , @idCustomer";
            int count = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idReceiveRoom, idCustomerOther });
            return count > 0;
        }
        public bool DeleteReceiveRoomDetails(int idReceiveRoom, int idCustomerOther)
        {
            string query = "USP_DeleteReceiveRoomDetails @idReceiveRoom , @idCustomer";
            int count = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idReceiveRoom, idCustomerOther });
            return count > 0;
        }
        public static ReceiveRoomDetailsDAO Instance { get { if (instance == null) instance = new ReceiveRoomDetailsDAO();return instance; }
            private set => instance = value; }
    }
}
