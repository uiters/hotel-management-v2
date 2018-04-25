using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class Room
    {
        private int id;
        private string roomName;
        private int idroomType;
        private int idstatusRoom;

        public Room(int id, string roomName, int idroomType, int idstatusRoom)
        {
            this.Id = id;
            this.RoomName = roomName;
            this.IdroomType = idroomType;
            this.IdstatusRoom = idstatusRoom;
        }
        public Room(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.RoomName = row["RoomName"].ToString();
            this.IdroomType = (int)row["IDRoomType"];
            this.IdstatusRoom = (int)row["IDStatusRoom"];
        }

        public int Id { get => id; set => id = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public int IdroomType { get => idroomType; set => idroomType = value; }
        public int IdstatusRoom { get => idstatusRoom; set => idstatusRoom = value; }
    }
}
