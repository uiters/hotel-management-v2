using HotelManager.DTO;
using System.Data;

namespace HotelManager.DAO
{
    public class RoomDAO
    {
        #region Method

        internal object GetIDRoomFromBookRoom(int idBookRoom)
        {
            object data = DataProvider.Instance.ExecuteScalar("exec USP_GetIDRoomFromBookRoom @idBookRoom", new object[] { idBookRoom });
            return data;
        }
        internal DataTable LoadFullRoom()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullRoom");
        }
        internal bool InsertRoom(Room roomNow)
        {
            return InsertRoom(roomNow.RoomName, roomNow.IdRoomType, roomNow.IdStatusRoom);
        }
        internal bool InsertRoom(string roomName, int idRoomType, int idStatusRoom)
        {
            string query = "USP_InsertRoom @nameRoom , @idRoomType , @idStatusRoom";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { roomName, idRoomType, idStatusRoom }) > 0;
        }
        internal bool UpdateCustomer(Room roomNow)
        {
            string query = "USP_UpdateRoom  @id , @nameRoom , @idRoomType , @idStatusRoom";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { roomNow.Id, roomNow.RoomName, roomNow.IdRoomType, roomNow.IdStatusRoom }) > 0;
        }
        internal DataTable Search(string text, int id)
        {
            string query = "USP_SearchRoom @string , @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text, id });
        }
        #endregion

        #region Properties & contructor
        private static RoomDAO instance;
        private RoomDAO() { }
        internal static RoomDAO Instance
        {
            get { if (instance == null) instance = new RoomDAO(); return instance; }
            private set => instance = value;
        }
        #endregion


    }
}
