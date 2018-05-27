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
    
    public partial class fReceiveRoom : Form
    {
        List<int> ListIDCustomer=new List<int>();
        int IDBookRoom=-1;
        DateTime dateCheckIn;
        public fReceiveRoom(int idBookRoom)
        {
            IDBookRoom = idBookRoom;
            InitializeComponent();
            LoadData();
            ShowBookRoomInfo(IDBookRoom);
        }
        public fReceiveRoom()
        {
            InitializeComponent();
            LoadData();
          
        }
        public void LoadData()
        {
            LoadListRoomType();
            LoadReceiveRoomInfo();
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
        public bool IsIDBookRoomExists(int idBookRoom)
        {
            return BookRoomDAO.Instance.IsIDBookRoomExists(idBookRoom);
        }
        public void ShowBookRoomInfo(int idBookRoom)
        {
            DataRow dataRow = BookRoomDAO.Instance.ShowBookRoomInfo(idBookRoom);
            txbFullName.Text = dataRow["FullName"].ToString();
            txbIDCard.Text = dataRow["IDCard"].ToString();
            txbRoomTypeName.Text = dataRow["RoomTypeName"].ToString();
            cbRoomType.Text= dataRow["RoomTypeName"].ToString();//*
            txbDateCheckIn.Text = dataRow["DateCheckIn"].ToString().Split(' ')[0];
            dateCheckIn = (DateTime)dataRow["DateCheckIn"];
            txbDateCheckOut.Text = dataRow["DateCheckOut"].ToString().Split(' ')[0];
            txbAmountPeople.Text= dataRow["LimitPerson"].ToString();
            txbPrice.Text= dataRow["Price"].ToString();
        }
        public bool InsertReceiveRoom(int idBookRoom, int idRoom)
        {
            return ReceiveRoomDAO.Instance.InsertReceiveRoom(idBookRoom, idRoom);
        }
        public bool InsertReceiveRoomDetails(int idReceiveRoom, int idCustomerOther)
        {
            return ReceiveRoomDetailsDAO.Instance.InsertReceiveRoomDetails(idReceiveRoom, idCustomerOther);
        }
        public void LoadReceiveRoomInfo()
        {
            dataGridViewReceiveRoom.DataSource = ReceiveRoomDAO.Instance.LoadReceiveRoomInfo();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomTypeName.Text = (cbRoomType.SelectedItem as RoomType).Name;
            LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id);
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomName.Text = cbRoom.Text;
        }

        private void txbIDBookRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txbIDBookRoom.Text!=string.Empty)
            {
                if (IsIDBookRoomExists(int.Parse(txbIDBookRoom.Text)))
                {
                    btnSearch.Tag = txbIDBookRoom.Text;
                    ShowBookRoomInfo(int.Parse(txbIDBookRoom.Text));
                }
                else
                    MetroFramework.MetroMessageBox.Show(this, "Mã đặt phòng không tồn tại.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbIDBookRoom.Text = string.Empty;
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            fAddCustomerInfo fAddCustomerInfo = new fAddCustomerInfo();
            fAddCustomerInfo.ShowDialog();
            this.Show();
        }

        private void btnReceiveRoom_Click(object sender, EventArgs e)
        {
            if(txbRoomName.Text!=string.Empty&&txbRoomTypeName.Text!=string.Empty&& txbFullName.Text!=string.Empty&&txbIDCard.Text!=string.Empty&&txbDateCheckIn.Text!=string.Empty&&txbDateCheckOut.Text!=string.Empty&&txbAmountPeople.Text!=string.Empty&&txbPrice.Text!=string.Empty)
            {
                if(dateCheckIn==DateTime.Now.Date)
                {
                    int idBookRoom;
                    if (IDBookRoom!=-1) idBookRoom = IDBookRoom;
                    else idBookRoom = int.Parse(btnSearch.Tag.ToString());
                    int idRoom = (cbRoom.SelectedItem as Room).Id;
                    if (InsertReceiveRoom(idBookRoom, idRoom))
                    {
                        if(fAddCustomerInfo.ListIdCustomer!=null)
                        {
                            foreach (int item in fAddCustomerInfo.ListIdCustomer)
                            {
                                if(item!=int.Parse(txbIDCard.Text))
                                InsertReceiveRoomDetails(ReceiveRoomDAO.Instance.GetIDCurrent(),item);
                            }
                        }
                        MetroFramework.MetroMessageBox.Show(this, "Nhận phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MetroFramework.MetroMessageBox.Show(this, "Tạo phiếu nhận phòng thất bại.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MetroFramework.MetroMessageBox.Show(this, "Mã đặt phòng không hợp lệ.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearData();
                LoadReceiveRoomInfo();
            }
        }
        public void ClearData()
        {
            txbFullName.Text = txbIDCard.Text = txbRoomTypeName.Text = txbDateCheckIn.Text = txbDateCheckOut.Text = txbAmountPeople.Text = txbPrice.Text = string.Empty;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
