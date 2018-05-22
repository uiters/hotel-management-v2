using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class BookRoom
    {
        private int id;
        private int  idCustomer;
        private int idRoomType;
        private DateTime dateBookRoom;
        private DateTime dateCheckIn;
        private DateTime dateCheckOut;

        public BookRoom(int id, int idCustomer, int idRoomType,DateTime dateBookRoom, DateTime dateCheckIn, DateTime dateCheckOut)
        {
            this.Id = id;
            this.IdCustomer = idCustomer;
            this.IdRoomType = idRoomType;
            this.DateBookRoom = dateBookRoom;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
        }
        public BookRoom(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdCustomer = (int)row["IDCustomer"];
            this.IdRoomType = (int)row["IDRoomType"];
            this.DateCheckIn = (DateTime)row["DateCheckIn"];
            this.DateCheckOut = (DateTime)row["DateCheckOut"];
            this.DateBookRoom = (DateTime)row["DateBookRoom"];
        }

        public int Id { get => id; set => id = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        public int IdRoomType { get => idRoomType; set => idRoomType = value; }

        public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public DateTime DateBookRoom { get => dateBookRoom; set => dateBookRoom = value; }
    }
}
