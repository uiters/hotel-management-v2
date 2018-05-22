using HotelManager.DTO;
using System.Data;

namespace HotelManager.DAO
{
    public class RoomTypeDAO
    {
        #region Properties & Constructor
        private static RoomTypeDAO instance;
        internal static RoomTypeDAO Instance
        {
            get { if (instance == null) instance = new RoomTypeDAO(); return instance; }
            private set => instance = value;
        }
        public RoomTypeDAO() { }
        #endregion

        #region Method
        internal DataTable LoadFullRoomType()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullRoomType");
        }
        internal bool InsertRoomType(string name, int price, int limitPerson)
        {
            string query = "USP_InsertRoomType @name , @price , @limitPerson";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name, price, limitPerson }) > 0;

        }
        internal bool InsertRoomType(RoomType roomTypeNow)
        {
            return InsertRoomType(roomTypeNow.Name, roomTypeNow.Price, roomTypeNow.LimitPerson);
        }
        internal bool UpdateRoomType(RoomType roomNow, RoomType roomPre)
        {
            string query = "USP_UpdateRoomType @id , @name , @price , @limitPerson";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { roomNow.Id, roomNow.Name, roomNow.Price, roomNow.LimitPerson }) > 0;
        }
        internal DataTable Search(string text, int id)
        {
            string query = "USP_SearchRoomType @string , @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text, id });
        }
        #endregion
    }
}
