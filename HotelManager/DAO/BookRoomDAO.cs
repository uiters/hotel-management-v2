using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class BookRoomDAO
    {
        private static BookRoomDAO instance;
        private BookRoomDAO() { }
        public static BookRoomDAO Instance { get { if (instance == null) instance = new BookRoomDAO();return instance; }
            private set => instance = value; }
        

       
    }
}
