using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HotelManager.DAO
{
    public class StatusRoomDAO
    {
        private StatusRoomDAO instance;
        public bool InsertStatusRoom(string name)
        {
            string query = "Exec USP_InsertStatusRoom @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new Object[] { name }) > 0;
        }
        public bool UpdateStatusRoom(int id, string name)
        {
            string query = "exec USP_UpdateStatusRoom @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name }) > 0;
        }
        public bool UpdateStatusRoom(StatusRoom statusRoom)
        {
            return UpdateStatusRoom(statusRoom.Id, statusRoom.Name);
        }
        public bool DeleteStatusRoom(int id)
        {
            string query = "USP_DeleteStatusRoom @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id }) > 0;
        }
        
        private StatusRoomDAO() { }
        internal StatusRoomDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatusRoomDAO();
                return instance;
            }
            private set => instance = value;
        }
    }
}
