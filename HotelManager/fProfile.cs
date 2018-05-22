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
    public partial class fProfile : Form
    {
        public fProfile(string userName)
        {
            InitializeComponent();
            LoadProfile(userName);
        }
        string Password;
        public void LoadProfile(string username)
        {
            Account staff = AccountDAO.Instance.LoadStaffInforByUserName(username);
            lblUserName.Text = txbUserName.Text = staff.UserName;
            lblDisplayName.Text = txbDisplayName.Text = staff.DisplayName;
            txbStaffType.Text = AccountTypeDAO.Instance.GetStaffTypeByUserName(username).Name;
            txbIDCard.Text = staff.IdCard.ToString();
            txbPhoneNumber.Text = staff.PhoneNumber.ToString();
            txbAddress.Text = staff.Address;
            txbDateOfBirth.Text = staff.DateOfBirth.ToString().Split(' ')[0];
            txbSex.Text = staff.Sex;
            txbStartDay.Text = staff.StartDay.ToShortDateString();
            Password = staff.PassWord;
        }
        public void UpdateDisplayName(string username, string displayname)
        {
            AccountDAO.Instance.UpdateDisplayName(username, displayname);
        }
        public void UpdatePassword(string username, string password)
        {
            AccountDAO.Instance.UpdatePassword(username, password);
        }
        public void UpdateInfo(string username, string address, int phonenumber,string idCard)
        {
            AccountDAO.Instance.UpdateInfo(username, address, phonenumber,idCard);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            if(txbDisplayName.Text!=String.Empty)
            {
                UpdateDisplayName(txbUserName.Text, txbDisplayName.Text);
                MetroFramework.MetroMessageBox.Show(this, "Cập nhật thông tin tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProfile(txbUserName.Text);
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "Tên hiển thị không hợp lệ.\nVui lòng nhập lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (AccountDAO.Instance.HashPass(txbPass.Text) ==Password&&txbNewPass.Text!=String.Empty&&txbReNewPass.Text!=String.Empty)
            {
                if(txbNewPass.Text==txbReNewPass.Text)
                {
                    UpdatePassword(txbUserName.Text, txbNewPass.Text);
                    MetroFramework.MetroMessageBox.Show(this, "Cập nhật mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbPass.Text = txbNewPass.Text = txbReNewPass.Text = String.Empty;
                    LoadProfile(txbUserName.Text);
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Mật khẩu mới không hợp lệ.\nVui lòng nhập lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbNewPass.Text = txbReNewPass.Text = String.Empty;
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Mật khẩu không hợp lệ.\nVui lòng nhập lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbPass.Text=txbNewPass.Text = txbReNewPass.Text = String.Empty;
            }   
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (txbAddress.Text != String.Empty&&txbPhoneNumber.Text!=String.Empty)
            {
                if (AccountDAO.Instance.IsIdCardExists(txbIDCard.Text))
                {
                    UpdateInfo(txbUserName.Text, txbAddress.Text, int.Parse(txbPhoneNumber.Text), txbIDCard.Text);
                    MetroFramework.MetroMessageBox.Show(this, "Cập nhật thông tin cơ bản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProfile(txbUserName.Text);
                }
                else
                    MetroFramework.MetroMessageBox.Show(this, "Thẻ căn cước/ CMND không tồn tại.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "Thông tin cơ bản không hợp lệ.\nVui lòng nhập lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
