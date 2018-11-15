using HotelManager.DTO;
using System.Data;
namespace HotelManager.DAO
{
    public class StatusRoomDAO
    {
        #region Properties & Constructor
        private static StatusRoomDAO instance;
        private StatusRoomDAO() { }
        public static StatusRoomDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatusRoomDAO();
                return instance;
            }
            private set => instance = value;
        }

        #endregion

        #region Method
        internal bool UpdateStatusRoom(int id, string name)
        {
            string query = "exec USP_UpdateStatusRoom @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name }) > 0;
        }
        internal bool UpdateStatusRoom(StatusRoom statusRoomNow)
        {
            return UpdateStatusRoom(statusRoomNow.Id, statusRoomNow.Name);
        }
        internal DataTable LoadFullStatusRoom()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullStatusRoom");
        }
        #endregion
    }
}
