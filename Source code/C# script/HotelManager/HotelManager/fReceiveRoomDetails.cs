using HotelManager.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fReceiveRoomDetails : Form
    {
        int idReceiveRoom;
        public fReceiveRoomDetails(int _idReceiRoom)
        {
            InitializeComponent();
            idReceiveRoom = _idReceiRoom;
            ShowReceiveRoom(_idReceiRoom);
            ShowCustomers(_idReceiRoom);
        }
        public void ShowReceiveRoom(int idReceiveRoom)
        {
            DataRow data = ReceiveRoomDAO.Instance.ShowReceiveRoom(idReceiveRoom).Rows[0];
            txbIDReceiveRoom.Text = ((int)data["Mã nhận phòng"]).ToString();
            txbRoomName.Text = data["Tên phòng"].ToString();
            txbDateCheckIn.Text = ((DateTime)data["Ngày nhận"]).ToString().Split(' ')[0];
            txbDateCheckOut.Text= ((DateTime)data["Ngày trả"]).ToString().Split(' ')[0];
        }
        public void ShowCustomers(int idReceiveRoom)
        {
            dataGridView.DataSource = ReceiveRoomDAO.Instance.ShowCusomers(idReceiveRoom);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            fAddCustomerInfo f = new fAddCustomerInfo();
            f.ShowDialog();
            Show();
            if(fAddCustomerInfo.ListIdCustomer.Count>0)
                foreach (var item in fAddCustomerInfo.ListIdCustomer)
                {
                    ReceiveRoomDetailsDAO.Instance.InsertReceiveRoomDetails(idReceiveRoom, item);
                }
            ShowCustomers(idReceiveRoom);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string idCard =dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            int idCustomer = CustomerDAO.Instance.GetInfoByIdCard(idCard).Id;
            if (idCustomer != CustomerDAO.Instance.GetIDCustomerFromBookRoom(idReceiveRoom))
            {
                ReceiveRoomDetailsDAO.Instance.DeleteReceiveRoomDetails(idReceiveRoom, idCustomer);
                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowCustomers(idReceiveRoom);
            }
            else
                MessageBox.Show("Không thể xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            string idCard = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            int idCustomer = CustomerDAO.Instance.GetInfoByIdCard(idCard).Id;
            fUpdateCustomerInfo f = new fUpdateCustomerInfo(idCard);
            f.ShowDialog();
            Show();
            ShowCustomers(idReceiveRoom);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            fChangeRoom f = new fChangeRoom(RoomDAO.Instance.GetIdRoomFromReceiveRoom(idReceiveRoom),idReceiveRoom);
            f.ShowDialog();
            Show();
            ShowReceiveRoom(idReceiveRoom);
        }
    }
}
