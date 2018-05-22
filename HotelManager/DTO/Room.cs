using System.Data;

namespace HotelManager.DTO
{
    public class Room
    {
        private int id;
        private string roomName;
        private int idRoomType;
        private int idStatusRoom;

        public Room() { }
        public Room(int id, string roomName, int idroomType, int idstatusRoom)
        {
            this.Id = id;
            this.RoomName = roomName;
            this.IdRoomType = idroomType;
            this.IdStatusRoom = idstatusRoom;
        }
        public Room(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.RoomName = row["Name"].ToString();
            this.IdRoomType = (int)row["IDRoomType"];
            this.IdStatusRoom = (int)row["IDStatusRoom"];
        }

        public bool Equals(Room roomPre)
        {
            if (roomPre == null) return false;
            if (roomPre.id != this.id) return false;
            if (roomPre.roomName != this.roomName) return false;
            if (roomPre.idRoomType != this.idRoomType) return false;
            if (roomPre.idStatusRoom != this.idStatusRoom) return false;
            return true;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Room);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int Id { get => id; set => id = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public int IdRoomType { get => idRoomType; set => idRoomType = value; }
        public int IdStatusRoom { get => idStatusRoom; set => idStatusRoom = value; }
    }
}
