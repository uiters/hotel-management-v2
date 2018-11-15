using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fChangeRoom : Form
    {
        int idRoom,idReceiveRoom;
        public fChangeRoom(int _idRoom,int _idReceiveRoom)
        {
            InitializeComponent();
            idRoom = _idRoom;
            idReceiveRoom = _idReceiveRoom;
            LoadListRoomType();
            LoadRoomTypeInfo(_idRoom);
        }

        public void LoadListRoomType()
        {
            List<RoomType> rooms = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DataSource = rooms;
            cbRoomType.DisplayMember = "Name";
        }
        public void LoadEmptyRoom(int idRoomType)
        {
            List<Room> rooms = RoomDAO.Instance.LoadEmptyRoom(idRoomType);
            cbRoom.DataSource = rooms;
            cbRoom.DisplayMember = "Name";
        }
        public void LoadRoomTypeInfo(int idRoom)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            RoomType roomType = RoomTypeDAO.Instance.GetRoomTypeByIdRoom(idRoom);
            txbLimitPerson.Text = roomType.LimitPerson.ToString();
            txbPrice.Text = roomType.Price.ToString("c",cultureInfo);
            txbRoomTypeName.Text = roomType.Name;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomTypeName.Text = (cbRoomType.SelectedItem as RoomType).Name;
            LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id);
            LoadRoomTypeInfo((cbRoom.SelectedItem as Room).Id);
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomName.Text = (cbRoom.SelectedItem as Room).Name;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //Phải cập nhật trạng thái của phòng cũ
            RoomDAO.Instance.UpdateStatusRoom(idRoom);
            ReceiveRoomDAO.Instance.UpdateReceiveRoom(idReceiveRoom, (cbRoom.SelectedItem as Room).Id);
            MessageBox.Show("Đổi phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
