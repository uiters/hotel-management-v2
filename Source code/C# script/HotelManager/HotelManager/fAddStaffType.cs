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
    public partial class fAddStaffType : Form
    {
        private int idStaffType = -1;
        public fAddStaffType()
        {
            InitializeComponent();
            btn.ButtonText = "Thêm mới";
            title.Text = "Thêm Loại Nhân Viên";
        }

        public fAddStaffType(int idStaffType, string name)
        {
            InitializeComponent();
            this.idStaffType = idStaffType;
            btn.ButtonText = "Cập nhật";
            txbName.Text = name;
            title.Text = "Cập Nhật Loại Nhân Viên";
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            if(idStaffType == -1 && !string.IsNullOrWhiteSpace(txbName.Text))
            {
                if(AccountTypeDAO.Instance.Insert(txbName.Text))
                {
                    MessageBox.Show("Thêm loại nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                if(AccountTypeDAO.Instance.Update(idStaffType, txbName.Text))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                btnClose_Click(sender, e);
            else if (e.KeyChar == 13)
                btn_Click(sender, e);
        }
    }
}
