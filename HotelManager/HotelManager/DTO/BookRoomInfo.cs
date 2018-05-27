using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class BookRoomInfo
    {
        private int idBookRoom;
        private int idRoom;
        private int countPeople;
        private DateTime dateOfSignUp;
        private DateTime dateOfReceive;
        public BookRoomInfo(int idBookRoom, int idRoom,int countPeople, DateTime dateOfSignUp, DateTime dateOfReceive)
        {
            IdBookRoom = idBookRoom;
            IdRoom = idRoom;
            CountPeople = countPeople;
            DateOfSignUp = dateOfSignUp;
            DateOfReceive = dateOfReceive;
        }
        public BookRoomInfo(DataRow row)
        {
            IdBookRoom = (int)row["idbookroom"];
            IdRoom = (int)row["idroom"];
            CountPeople = (int)row["CountPeople"];
            DateOfSignUp = (DateTime)row["dateofsignup"];
            DateOfReceive = (DateTime)row["dateofReceive"];
        }
        public int IdBookRoom { get => idBookRoom; set => idBookRoom = value; }
        public int IdRoom { get => idRoom; set => idRoom = value; }
        public int CountPeople { get => countPeople; set => countPeople = value; }
        public DateTime DateOfSignUp { get => dateOfSignUp; set => dateOfSignUp = value; }
        public DateTime DateOfReceive { get => dateOfReceive; set => dateOfReceive = value; }
    }
}
