using HotelManager.DTO;
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
        public bool InsertReceiveRoom(int idBookRoom, int idRoom)
        {
            string query = "InsertReceiveRoom @idBookRoom , @idRoom";
            int count = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBookRoom, idRoom });
            return count > 0;
        }
        public int GetIDCurrent()
        {
            string query = "GetIDReceiveRoomCurrent";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }
        public DataTable LoadReceiveRoomInfo()
        {
            string query = "USP_LoadReceiveRoomsByDate @date";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { DateTime.Now.Date });
        }
        public int GetIdReceiveRoomFromIdRoom(int idRoom)
        {
            string query = "USP_GetIdReceiRoomFromIdRoom @idRoom";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom });
            ReceiveRoom receiveRoom = new ReceiveRoom(dataTable.Rows[0]);
            return receiveRoom.Id;
        }
        public DataTable ShowReceiveRoom(int id)
        {
            string query = "USP_ShowReceiveRoom @idReceiveRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }
        public DataTable ShowCusomers(int id)
        {
            string query = "USP_ShowCustomerFromReceiveRoom @idReceiveRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }
        public bool UpdateReceiveRoom(int id, int idRoom)
        {
            string query = "USP_UpdateReceiveRoom @id , @idRoom";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[]{ id, idRoom }) > 0;
        }
        public static ReceiveRoomDAO Instance { get { if (instance == null) instance = new ReceiveRoomDAO(); return instance; }
            private set => instance = value; }
    }
}
