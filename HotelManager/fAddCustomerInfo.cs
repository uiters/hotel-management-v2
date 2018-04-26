using HotelManager.DAO;
using HotelManager.DTO;
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
    public partial class fAddCustomerInfo : Form
    {
        public List<int> listIDCustomer;
        public delegate void SendListIDCustomer(List<int> listIDCustomer);
        public event SendListIDCustomer sendListIDCustomer;
        public fAddCustomerInfo()
        {
            InitializeComponent();
            LoadListCustomerType();
            listIDCustomer = new List<int>();
            dpkDateOfBirth.Value = new DateTime(2000, 8, 20);
        }
        public void LoadListCustomerType()
        {
            comboBoxCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            comboBoxCustomerType.DisplayMember = "Name";
        }
       
        public bool CheckIDCardExists(string idCard)
        {
            return CustomerDAO.Instance.CheckIDCardExists(idCard);
        }
        public bool InsertCustomer(string customerName, int idCustomerType, string idCard, string address, DateTime dateOfBirth, int phoneNumber, string sex, string nationality)
        {
            return CustomerDAO.Instance.InsertCustomer(customerName, idCustomerType, idCard, address,dateOfBirth, phoneNumber, sex, nationality);
        }
        public Customer GetIDCustomer(string idCard)
        {
            Customer customer = CustomerDAO.Instance.GetIDCustomer(idCard);
            return customer;
        }
        

        public bool UpdateCustomer1(int phoneNumber, string address, string idCard)
        {
            return CustomerDAO.Instance.UpdateCustomer1(phoneNumber, address, idCard);
        }
        public void InsertCustomer()
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
            //listIDCustomer.Add(customer.IdCard);
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txbFullName.Text == string.Empty || txbIDCard.Text == string.Empty || txbNationality.Text == string.Empty || txbPhoneNumber.Text == string.Empty || comboBoxSex.Text == string.Empty || txbAddress.Text == string.Empty)
                MetroFramework.MetroMessageBox.Show(this, "Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                InsertCustomer();
                if (MetroFramework.MetroMessageBox.Show(this, "Thêm khách hàng thành công!\nBạn có muốn tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    comboBoxCustomerType.Text = string.Empty;
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
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fAddCustomerInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
          if(sendListIDCustomer!=null)
            sendListIDCustomer(listIDCustomer);
        }
    }
}
