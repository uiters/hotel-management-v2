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
        public DataTable LoadFullRoom()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullRoom");
        }
        public bool InsertRoom(Room roomNow)
        {
            return InsertRoom(roomNow.RoomName, roomNow.IdRoomType, roomNow.IdStatusRoom);
        }
        public bool InsertRoom(string roomName, int idRoomType, int idStatusRoom)
        {
            string query = "USP_InsertRoom @nameRoom , @idRoomType , @idStatusRoom";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { roomName, idRoomType, idStatusRoom }) > 0;
        }
        public bool UpdateCustomer(Room roomNow, Room roomPre)
        {
            string query = "USP_UpdateRoom  @id , @nameRoom , @idRoomType , @idStatusRoom";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { roomNow.Id, roomNow.RoomName, roomNow.IdRoomType, roomNow.IdStatusRoom }) > 0;
        }
        public static RoomDAO Instance { get {if(instance==null) instance=new RoomDAO();return instance; }
            private set => instance = value; }
        private RoomDAO() { }
    }
}
