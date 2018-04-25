using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance;

        public static RoomTypeDAO Instance { get { if (instance == null) instance = new RoomTypeDAO();return instance; }
            private set => instance = value; }
        public RoomTypeDAO() { }
        public List<RoomType> LoadRoomType()
        {
            string query = "select * from RoomType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<RoomType> listRoomType = new List<RoomType>();
            foreach (DataRow item in data.Rows)
            {
                RoomType roomType = new RoomType(item);
                listRoomType.Add(roomType);
            }
            return listRoomType;
        }
    }
}
