using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class ReceiveRoomInfoDAO
    {
        private static ReceiveRoomInfoDAO instance;
        private ReceiveRoomInfoDAO() { }
        public bool InsertReceiveRoomInfo(int idReceiveRoom, int idCustomer)
        {
            string query = "exec USP_InsertReceiveRoomInfo @idReceiveRoom , @idCustomer";
            int count = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idReceiveRoom, idCustomer });
            return count > 0;
        }
        public static ReceiveRoomInfoDAO Instance { get { if (instance == null) instance = new ReceiveRoomInfoDAO();return instance; }
            private set => instance = value; }
    }
}
