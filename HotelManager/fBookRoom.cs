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
    public partial class fBookRoom : Form
    {
        int idBookRoom;
        public fBookRoom()
        {
            InitializeComponent();
            LoadData();
       
        }
        public void LoadData()
        {
            ShowDate();
            LoadListRoomType();
            LoadListCustomerType();
            LoadListBookRoom();

        }
        public void LoadDateOfPay()
        {
            if(txbCountOfDay.Text!=string.Empty)
            dpkDateOfPay.Value = dpkDateOfReceive.Value.AddDays(int.Parse(txbCountOfDay.Text));
        }
        public void LoadCountOfDay()
        {
            TimeSpan timespan = dpkDateOfPay.Value - dpkDateOfReceive.Value;
            txbCountOfDay.Text = timespan.Days.ToString();
        }
        public void LoadListBookRoom()
        {
          // dataGridViewBookRoom.DataSource=BookRoomDAO.Instance.LoadListBookRoom();

 
        }
        public void LoadListRoomType()
        {
            cbRoomType.DataSource= RoomTypeDAO.Instance.LoadRoomType();
            cbRoomType.DisplayMember = "Name";

        }
        public void LoadEmptyListRoomByRoomType(int id)
        {
            cbRoom.DataSource = RoomDAO.Instance.LoadEmptyListRoomByRoomType(id);
            cbRoom.DisplayMember = "RoomName";
        }
        int price = 0;
        public void ShowRoomInfo(int id)
        {
            Room room = RoomDAO.Instance.ShowRoomInfo(id);
            txbRoomID.Text = room.Id.ToString();
            txbRoomName.Text = room.RoomName;
            //txbRoomTypeName.Text = room.RoomTypeName;
            //txbNote.Text = room.Note;
            //price = room.Price;
            //CultureInfo culture = new CultureInfo("vi-VN");
            //txbPrice.Text = room.Price.ToString("c",culture);
           
            //txbAmountPeople.Text = room.CountPeople.ToString();
        }


        public bool CheckIDCardExists(string idCard)
        {
            return CustomerDAO.Instance.CheckIDCardExists(idCard);
        }
        public bool InsertCustomer(string customerName, int idCustomerType, string idCard, string address, DateTime dateOfBirth, int phoneNumber, string sex, string nationality)
        {
            return CustomerDAO.Instance.InsertCustomer(customerName,idCustomerType, idCard, address,dateOfBirth, phoneNumber, sex,nationality);
        }
        public Customer GetIDCustomer(string idCard)
        {
            Customer customer = CustomerDAO.Instance.GetIDCustomer(idCard);
            return customer;
        }
        public bool InsertBookRoom(int idCustomer, int idRoom, DateTime DateOfSignUp, DateTime DateOfReceive, int countOfDay)
        {
            return false; // BookRoomDAO.Instance.InsertBookRoom(idCustomer,idRoom,DateOfSignUp,DateOfReceive,int.Parse(txbCountOfDay.Text));
        }

        public bool UpdateCustomer1(int phoneNumber, string address, string idCard)
        {
            return CustomerDAO.Instance.UpdateCustomer1(phoneNumber,address,idCard);
        }
        public void BookRoom()
        {
            if(CheckIDCardExists(txbIDCard.Text)==false)
            {
                int idCustomerType = (comboBoxCustomerType.SelectedItem as CustomerType).Id;
                InsertCustomer(txbFullName.Text,idCustomerType, txbIDCard.Text, txbAddress.Text,dpkDateOfBirth.Value,int.Parse(txbPhoneNumber.Text), comboBoxSex.SelectedItem.ToString(), txbNationality.Text);
            }
            else
            {
                UpdateCustomer1(int.Parse(txbPhoneNumber.Text), txbAddress.Text, txbIDCard.Text);
            }
            Customer customer = GetIDCustomer(txbIDCard.Text);
            int idRoom = (cbRoom.SelectedItem as Room).Id;
            //InsertBookRoom(customer.Id,idRoom, DateTime.Parse(txbDateOfSignUp.Text), DatepickerDateOfReceive.Value,int.Parse(txbCountOfDay.Text));
            //idBookRoom = GetIDBookRoom(customer.Id,idRoom);
        }
        public void LoadListCustomerType()
        {
            comboBoxCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            comboBoxCustomerType.DisplayMember = "Name";
        }
        public void ShowDate()
        {
            dpkDateOfReceive.Value = DateTime.Now;
            txbDateOfSignUp.Text = DateTime.Now.ToString("d");
            dpkDateOfPay.Value = DateTime.Now.AddDays(1);
            dpkDateOfBirth.Value = new DateTime(2000,8,20);
            LoadCountOfDay();
            dpkDateOfReceive.onValueChanged += DpkDateOfReceive_onValueChanged;
            dpkDateOfPay.onValueChanged += DpkDateOfPay_onValueChanged;
        }

        private void DpkDateOfPay_onValueChanged(object sender, EventArgs e)
        {
            if(dpkDateOfPay.Value.AddDays(-1)<DateTime.Now.Date || dpkDateOfPay.Value.AddDays(-1)<dpkDateOfReceive.Value)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ngày trả phòng không hợp lệ!\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dpkDateOfPay.Value = DateTime.Now.Date.AddDays(1);
            }
            LoadCountOfDay();
        }

        private void DpkDateOfReceive_onValueChanged(object sender, EventArgs e)
        {
            if(dpkDateOfReceive.Value<DateTime.Now.Date || dpkDateOfPay.Value.AddDays(-1) < dpkDateOfReceive.Value)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ngày nhận phòng không hợp lệ!\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dpkDateOfReceive.Value = DateTime.Now.Date;
            }
            LoadCountOfDay();
        }

        public int GetIDBookRoom(int idCustomer, int idRoom)
        {
            return 0; //BookRoomDAO.Instance.GetIDBookRoom(idCustomer, idRoom);
        }
        //public void LoadEmptyListRoom()
        //{
        //    List<Room> listRoom = RoomDAO.Instance.LoadEmptyListRoom();
        //    foreach (Room item in listRoom)
        //    {
        //        Button btn = new Button();
        //        btn.Tag = item;
        //        btn.Click += Btn_Click;
        //        btn.Width = 180;
        //        btn.Height = 80;
        //        btn.BackColor = Color.SeaGreen;
        //        btn.ForeColor = Color.White;
        //        btn.Font= new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        btn.Text = item.RoomName + "\n" + item.RoomTypeName + "\n" + item.Status;
        //        flowLayoutPanel.Controls.Add(btn);
        //    }
        //}

        //private void Btn_Click(object sender, EventArgs e)
        //{
        //    Button btn = sender as Button;
        //    btn.BackColor = Color.Tomato;
        //    foreach (Control item in flowLayoutPanel.Controls)
        //    {
        //        if(item!=btn)
        //        {
        //            item.BackColor = Color.SeaGreen;
        //        }
        //    }
        //    int id = ((sender as Button).Tag as Room).Id;
        //    ShowRoomInfo(id);
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (cbRoomType.SelectedItem as RoomType).Id;
            LoadEmptyListRoomByRoomType(id);
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (cbRoom.SelectedItem as Room).Id;
            ShowRoomInfo(id);
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbCountPeople_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnSignUpRoom_Click_1(object sender, EventArgs e)
        {
            if (cbRoom.Text==string.Empty|| txbCountOfDay.Text==string.Empty || txbFullName.Text == string.Empty || txbIDCard.Text == string.Empty || txbNationality.Text == string.Empty || txbPhoneNumber.Text == string.Empty || comboBoxSex.Text == string.Empty || txbAddress.Text == string.Empty)
                MetroFramework.MetroMessageBox.Show(this, "Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                BookRoom();
                MetroFramework.MetroMessageBox.Show(this, "Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadListBookRoom();
                if (bunifuCheckbox1.Checked == true)
                {
                    this.Hide();
                                        
                    fReceiveRoom f = new fReceiveRoom(int.Parse(txbRoomID.Text),txbRoomName.Text,txbRoomTypeName.Text,int.Parse(txbAmountPeople.Text), txbNote.Text,price,txbFullName.Text,txbIDCard.Text,comboBoxCustomerType.Text,int.Parse(txbPhoneNumber.Text),txbAddress.Text,comboBoxSex.Text,dpkDateOfBirth.Value ,txbNationality.Text,idBookRoom,int.Parse(txbCountOfDay.Text));
                    f.ShowDialog();
                    this.Show();
                }
                txbRoomID.Text = string.Empty;
                txbRoomName.Text = string.Empty;
                txbCountOfDay.Text = string.Empty;
                txbAmountPeople.Text = string.Empty;
                txbNote.Text = string.Empty;
                txbPrice.Text = string.Empty;
                comboBoxCustomerType.Text = string.Empty;
                txbRoomTypeName.Text = string.Empty;
                txbFullName.Text = string.Empty;
                txbIDCard.Text = string.Empty;
                txbNationality.Text = string.Empty;
                txbPhoneNumber.Text = string.Empty;
                comboBoxSex.Text = string.Empty;
                txbAddress.Text = string.Empty;
                dpkDateOfBirth.Value = new DateTime(2000, 8, 20);
                txbFullName.Focus();
            }
            
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {

            txbRoomID.Text = string.Empty;
            txbRoomName.Text = string.Empty;
            txbAmountPeople.Text = string.Empty;
            txbNote.Text = string.Empty;
            txbCountOfDay.Text = string.Empty;
            txbPrice.Text = string.Empty;
            comboBoxCustomerType.Text = string.Empty;
            txbRoomTypeName.Text = string.Empty;
            txbFullName.Text = string.Empty;
            txbIDCard.Text = string.Empty;
            txbNationality.Text = string.Empty;
            txbPhoneNumber.Text = string.Empty;
            dpkDateOfBirth.Value = new DateTime(2000, 8, 20);
            comboBoxSex.Text = string.Empty;
            txbAddress.Text = string.Empty;
            txbFullName.Focus();

        }

        private void txbCountOfDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

       

        private void txbCountOfDay_OnValueChanged(object sender, EventArgs e)
        {
            LoadDateOfPay();
        }

        private void dpkDateOfReceive_onValueChanged_1(object sender, EventArgs e)
        {
            if (dpkDateOfReceive.Value < DateTime.Now.Date || dpkDateOfPay.Value.AddDays(-1) < dpkDateOfReceive.Value)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ngày nhận phòng không hợp lệ!\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dpkDateOfReceive.Value = DateTime.Now.Date;
            }
            LoadCountOfDay();
        }

        private void dpkDateOfPay_onValueChanged_1(object sender, EventArgs e)
        {
            if (dpkDateOfPay.Value.AddDays(-1) < DateTime.Now.Date || dpkDateOfPay.Value.AddDays(-1) < dpkDateOfReceive.Value)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ngày trả phòng không hợp lệ!\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dpkDateOfPay.Value = DateTime.Now.Date.AddDays(1);
            }
            LoadCountOfDay();
        }
    }
}
