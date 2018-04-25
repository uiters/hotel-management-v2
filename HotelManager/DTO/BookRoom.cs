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
        private DateTime dateCheckIn;
        private DateTime dateCheckOut;

        public BookRoom(int id, int idCustomer, int idRoomType, DateTime dateCheckIn, DateTime dateCheckOut)
        {
            this.Id = id;
            this.IdCustomer = idCustomer;
            this.IdRoomType = idRoomType;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
        }
        public BookRoom(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdCustomer = (int)row["IDCustomer"];
            this.idRoomType = (int)row["IDRoomType"];
            dateCheckIn = (DateTime)row["DateCheckIn"];
            dateCheckOut = (DateTime)row["DateCheckOut"];
        }

        public int Id { get => id; set => id = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        public int IdRoomType { get => idRoomType; set => idRoomType = value; }

        public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
    }
}
