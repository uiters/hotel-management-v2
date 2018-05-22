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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        public bool Login()
        {
            return AccountDAO.Instance.Login(txbUserName.Text, txbPassWord.Text);
        }
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MetroFramework.MetroMessageBox.Show(this,"Bạn có muốn thoát không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (Login())
            {
                this.Hide();
                fManager f = new fManager();
                f.ShowDialog();
                this.Show();
                txbUserName.Text = String.Empty;
                txbPassWord.Text = String.Empty;
                txbUserName.Focus();

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Tên Đăng Nhập không tồn tại hoặc Mật Khẩu không đúng.\nVui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
