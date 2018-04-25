using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance;
        public List<Room> LoadEmptyListRoomByRoomType(int id)
        {
            List<Room> listRoom = new List<Room>();
            DataTable data= DataProvider.Instance.ExecuteQuery("exec USP_LoadEmptyListRoomByRoomType @idRoomType", new object[] { id});
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                listRoom.Add(room);
            }
            return listRoom;
        }
        public Room ShowRoomInfo(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("exec USP_ShowRoomInfo @ID", new object[] { id });
            Room room = new Room(data.Rows[0]);
            return room;
        }
        public object GetIDRoomFromBookRoom(int idBookRoom)
        {
            object data = DataProvider.Instance.ExecuteScalar("exec USP_GetIDRoomFromBookRoom @idBookRoom", new object[] { idBookRoom });
            return data;
        }
        public static RoomDAO Instance { get {if(instance==null) instance=new RoomDAO();return instance; }
            private set => instance = value; }
        private RoomDAO() { }
    }
}
