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
        int RoomID;
        string RoomName;
        string RoomTypeName;
        int CountPeople;
        string Note;
        int Price;
        string CustomerName;
        string IDCard;
        string CustomerTypeName;
        int PhoneNumber;
        string Address;
        string Sex;
        DateTime DateOfBirth;
        string Nationality;
        int IDBookRoom=-1;
        int CountOfDay;
        public fReceiveRoom(int roomId, string roomName, string roomTypeName,int countPeople, string note,int price,string customerName,string idCard,string customerTypeName,int phoneNumer,string address, string sex,DateTime dateOfBirth, string nationality, int idBookRoom, int countOfDay)
        {
            RoomID = roomId;
            RoomName = roomName;
            RoomTypeName = roomTypeName;
            CountPeople = countPeople;
            Note = note;
            Price = price;
            CustomerName = customerName;
            IDCard = idCard;
            CustomerTypeName = customerTypeName;
            PhoneNumber = phoneNumer;
            Address = address;
            Sex = sex;
            DateOfBirth = dateOfBirth;
            IDBookRoom = idBookRoom;
            Nationality = nationality;
            CountOfDay = countOfDay;
            InitializeComponent();
            LoadData();
            LoadBookRoomInfo();
        }
        public fReceiveRoom()
        {
            InitializeComponent();
            LoadData();
          
        }
        public void LoadData()
        {
           
            LoadListCustomerType();
            txbDateOfReceive.Text = DateTime.Now.ToString("d");
            dataGridViewReceiveRoom.DataSource = ReceiveRoomDAO.Instance.ShowReceiveInfo();
        }
       
        public void LoadBookRoomInfo()
        {
          
            txbRoomID.Text = RoomID.ToString();
            txbRoomName.Text = RoomName;
            txbRoomTypeName.Text = RoomTypeName;
            txbNote.Text = Note;
            CultureInfo culture = new CultureInfo("vi-VN");
            txbPrice.Text = Price.ToString("c", culture);
            txbAmountPeople.Text =CountPeople.ToString();
            txbFullName.Text = CustomerName;
            txbIDCard.Text = IDCard;
            txbAddress.Text = Address;
            txbPhoneNumber.Text = PhoneNumber.ToString();
            txbNationality.Text = Nationality;
            comboBoxSex.Text = Sex;
            txbCountOfDay.Text = CountOfDay.ToString();
            txbDateOfPay.Text = DateTime.Now.Date.AddDays(int.Parse(txbCountOfDay.Text)).ToString("d");
            dpkDateOfBirth.Value = DateOfBirth;
        }
        public void ShowRoomInfo(int id)
        {
            Room room = RoomDAO.Instance.ShowRoomInfo(id);
            txbRoomID.Text = room.Id.ToString();
            txbRoomName.Text = room.RoomName;
            txbRoomTypeName.Text = room.RoomTypeName;
            txbNote.Text = room.Note;
            CultureInfo culture = new CultureInfo("vi-VN");
            txbPrice.Text = room.Price.ToString("c", culture);
            txbAmountPeople.Text = room.CountPeople.ToString();
           
        }
        public int GetIDRoomFromBookRoom(int IdBookRoom)
        {
            return (int)RoomDAO.Instance.GetIDRoomFromBookRoom(IdBookRoom);
        }
        public int GetIDCustomerFromBookRoom(int idBookRoom)
        {
            return (int)CustomerDAO.Instance.GetIDCustomerFromBookRoom(idBookRoom);
        }
        public void ShowCustomerInfo(int idCustomer)
        {
            Customer customer = CustomerDAO.Instance.ShowCustomerInfo(idCustomer);
            txbFullName.Text = customer.CustomerName;
            txbIDCard.Text = customer.IdCard;
            txbAddress.Text = customer.Address;
            txbPhoneNumber.Text = customer.PhoneNumber.ToString();
            txbNationality.Text = customer.Nationality;
            comboBoxSex.Text = customer.Sex;
            dpkDateOfBirth.Value=DateTime.Parse((customer.DateOfBirth.ToString("d")));
        }
        public int GetCountDay(int id)
        {
            return BookRoomDAO.Instance.GetCountDay(id);
        }
        public int GetIDCustomerType(int id)
        {
            return (int)CustomerTypeDAO.Instance.GetIDCustomerType(id);
        }
        public void ShowCustomerTypeName(int id)
        {
            object obj = CustomerTypeDAO.Instance.GetCustomerTypeName(id);
            comboBoxCustomerType.Text = obj.ToString();
        }
        public void LoadListCustomerType()
        {
            comboBoxCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            comboBoxCustomerType.DisplayMember = "Name";
        }
        public bool CheckIDBookRoomExists(int id)
        {
            return BookRoomDAO.Instance.CheckIDBookRoomExists(id);
        }
        
        public bool CheckIDCardExists(string idCard)
        {
            return CustomerDAO.Instance.CheckIDCardExists(idCard);
        }
        public bool InsertCustomer(string customerName, int idCustomerType, string idCard, string address,DateTime dateOfBirth, int phoneNumber, string sex, string nationality)
        {
            return CustomerDAO.Instance.InsertCustomer(customerName, idCustomerType, idCard, address,dpkDateOfBirth.Value, phoneNumber, sex, nationality);
        }
        public Customer GetIDCustomer(string idCard)
        {
            Customer customer = CustomerDAO.Instance.GetIDCustomer(idCard);
            return customer;
        }
        
        public bool InsertBookRoom(int idCustomer, int idRoom, DateTime DateOfSignUp, DateTime DateOfReceive, int countOfDay)
        {
            return BookRoomDAO.Instance.InsertBookRoom(idCustomer, idRoom, DateOfSignUp, DateOfReceive, int.Parse(txbCountOfDay.Text));
        }
        public bool UpdateCustomer1(int phoneNumber, string address, string idCard)
        {
            return CustomerDAO.Instance.UpdateCustomer1(phoneNumber, address, idCard);
        }
        public bool InsertReceiveRoom(int idBookRoom, int idCustomer, DateTime dateOfReceive, DateTime dateOfPay)
        {
            return ReceiveRoomDAO.Instance.InsertReceiveRoom(idBookRoom,  idCustomer, dateOfReceive,  dateOfPay);
        }
        public bool InsertReceiveRoomInfo(int idReceiveRoom, int idCustomer)
        {
            return ReceiveRoomInfoDAO.Instance.InsertReceiveRoomInfo(idReceiveRoom, idCustomer);
        }
        public int GetIDReceiveRoom(int idBookRoom, int idCustomer)
        {
            return ReceiveRoomDAO.Instance.GetIDReceiveRoom(idBookRoom, idCustomer);

        }
        public void ReceiveRoom(List<int> listIDCustomer)
        {
            if (CheckIDCardExists(txbIDCard.Text) == false)
            {
                int idCustomerType = (comboBoxCustomerType.SelectedItem as CustomerType).Id;
                InsertCustomer(txbFullName.Text, idCustomerType, txbIDCard.Text, txbAddress.Text,dpkDateOfBirth.Value, int.Parse(txbPhoneNumber.Text), comboBoxSex.SelectedItem.ToString(), txbNationality.Text);
            }
            else
            {
                UpdateCustomer1(int.Parse(txbPhoneNumber.Text), txbAddress.Text, txbIDCard.Text);
            }
            Customer customer = GetIDCustomer(txbIDCard.Text);
            int idBookRoom = 0;
            if(IDBookRoom==-1 && idBookRoom1==-1)
            {
                MetroFramework.MetroMessageBox.Show(this, "Mã đặt phòng không chính xác!\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (IDBookRoom != -1 && idBookRoom1 == -1)
                    idBookRoom = IDBookRoom;
                if (IDBookRoom == -1 && idBookRoom1 != -1)
                    idBookRoom = idBookRoom1;
                
                InsertReceiveRoom(idBookRoom, customer.Id, DateTime.Parse(txbDateOfReceive.Text), DateTime.Parse(txbDateOfPay.Text));
                int idReceiveRoom = GetIDReceiveRoom(idBookRoom, customer.Id);
                InsertReceiveRoomInfo(idReceiveRoom, customer.Id);// Insert cả thông tin của người đứng tên nhận phòng
                if(listIDCustomer.Count!=0)
                foreach (int item in listIDCustomer)
                {
                    InsertReceiveRoomInfo(idReceiveRoom, item);
                }
            }
        }
        private void txbIDBookRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //Hide();
            fAddCustomerInfo f = new fAddCustomerInfo();
            f.ShowDialog();
            Show();
            f.sendListIDCustomer += F_sendListIDCustomer;
            ListIDCustomer = f.listIDCustomer;
        }

        private void F_sendListIDCustomer(List<int> listIDCustomer)
        {
            ListIDCustomer = listIDCustomer;
        }

        private void btnReceiveRoom_Click(object sender, EventArgs e)
        {
            if (txbRoomTypeName.Text == string.Empty || txbFullName.Text == string.Empty || txbIDCard.Text == string.Empty || txbNationality.Text == string.Empty || txbPhoneNumber.Text == string.Empty || comboBoxSex.Text == string.Empty || txbAddress.Text == string.Empty)
                MetroFramework.MetroMessageBox.Show(this, "Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ReceiveRoom(ListIDCustomer);
                MetroFramework.MetroMessageBox.Show(this, "Nhận phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewReceiveRoom.DataSource = ReceiveRoomDAO.Instance.ShowReceiveInfo();
                txbRoomID.Text = string.Empty;
                txbRoomName.Text = string.Empty;
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
                txbFullName.Focus();
            }
           

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int idBookRoom1 = -1;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (CheckIDBookRoomExists(int.Parse(txbIDBookRoom.Text)))
            {
                int idRoom = GetIDRoomFromBookRoom(int.Parse(txbIDBookRoom.Text));
                ShowRoomInfo(idRoom);
                int idCustomer = GetIDCustomerFromBookRoom(int.Parse(txbIDBookRoom.Text));
                ShowCustomerInfo(idCustomer);
                int idCustomertype = GetIDCustomerType(idCustomer);
                ShowCustomerTypeName(idCustomertype);
                idBookRoom1 = int.Parse(txbIDBookRoom.Text);
                txbCountOfDay.Text = GetCountDay(idBookRoom1).ToString();
                txbDateOfPay.Text = DateTime.Now.Date.AddDays(int.Parse(txbCountOfDay.Text)).ToString("d");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Mã đặt phòng không chính xác!\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txbRoomID.Text = string.Empty;
            txbRoomName.Text = string.Empty;
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
            txbFullName.Focus();
        }

        private void txbCountOfDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
