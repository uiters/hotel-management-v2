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
    public partial class fStaff : Form
    {
        #region Properties
        fStaffType staffType;
        #endregion


        #region Constructor
        public fStaff()
        {
            InitializeComponent();
            LoadFullStaffType();
            LoadFullStaff();
        }
        #endregion


        #region Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRoomType_Click(object sender, EventArgs e)
        {
            this.Hide();
            staffType.ShowDialog();
            comboBoxStaffType.DataSource = staffType.tableStaffType;
            LoadFullStaff();
            this.Show();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn thêm nhân viên mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                if (CheckDate())
                {
                    if (CheckPass())
                        InsertStaff();
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Nhập lại mật khẩu không chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn cập nhật nhân viên này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                if (CheckDate())
                {
                    if (CheckPass())
                        UpdateStaff();
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Nhập lại mật khẩu không chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Method
        private void InsertStaff()
        {
            bool isFill = fCustomer.CheckFillInText(new Control[] { txbUserName, txbPassword, comboBoxStaffType, txbName ,
                                                            txbIDcard , comboBoxSex , txbPhoneNumber, txbAddress});
            if (!isFill)
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Account accountNow = GetStaffNow();
                if (AccountDAO.Instance.InsertAccount(accountNow))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFullStaff();
                }
                else
                    MetroFramework.MetroMessageBox.Show(this, "Nhân Viên Đã Tồn Tại(Trùng tên đăng nhập hoặc CMND)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Lỗi Không xác định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateStaff()
        {
            bool isFill = fCustomer.CheckFillInText(new Control[] { txbUserName, comboBoxStaffType, txbName ,
                                                            txbIDcard , comboBoxSex , txbPhoneNumber, txbAddress});
            if (!isFill)
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Account accountPre = groupStaff.Tag as Account;
                try
                {
                    Account accountnow = GetStaffNow();
                    if (accountnow.Equals(accountPre))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "bạn chưa thay đổi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = AccountDAO.Instance.UpdateAccount(accountnow);
                        if (check)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupStaff.Tag = accountnow;
                            LoadFullStaff();
                        }
                        else
                            MetroFramework.MetroMessageBox.Show(this, "Không thể cập nhật(Trùng số chứng minh nhân dân)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi không xác định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
        }
        #endregion

        #region Load data
        private void LoadFullStaff()
        {
            DataTable table = GetFullStaff();
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dataGridStaffType.DataSource = source;
            bindingStaff.BindingSource = source;
        }
        private void LoadFullStaffType()
        {
            comboBoxSex.SelectedIndex = 0;
            DataTable table = GetFullStaffType();
            comboBoxStaffType.DataSource = table;
            comboBoxStaffType.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                comboBoxStaffType.SelectedIndex = 0;
            staffType = new fStaffType(table);
        }
        #endregion

        #region GetData
        private DataTable GetFullStaff()
        {
            return AccountDAO.Instance.LoadFullStaff();
        }
        private DataTable GetFullStaffType()
        {
            return AccountTypeDAO.Instance.LoadFullStaffType();
        }
        private Account GetStaffNow()
        {
            Account account = new Account();
            account.UserName = txbUserName.Text.ToLower();
            account.PassWord = txbPassword.Text;
            int index = comboBoxStaffType.SelectedIndex;
            account.IdStaffType = (int)((DataTable)comboBoxStaffType.DataSource).Rows[index]["id"];
            account.DisplayName = txbName.Text;
            account.IdCard = int.Parse(txbIDcard.Text);
            account.Sex = comboBoxSex.Text;
            account.DateOfBirth = datepickerDateOfBirth.Value;
            account.PhoneNumber = int.Parse(txbPhoneNumber.Text);
            account.Address = txbAddress.Text;
            account.StartDay = datePickerStartDay.Value;
            return account;
        }
        #endregion

        #region Check isDigit
        private void txbIDcard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private bool CheckTrueDate(DateTime date1, DateTime date2)
        {
            if (date2.Subtract(date1).Days < 6574)
                return false;
            return true;
        }
        private bool CheckDate()
        {
            if (!CheckTrueDate(datepickerDateOfBirth.Value, DateTime.Now))
            {
                MetroFramework.MetroMessageBox.Show(this, "Ngày sinh không hợp lệ (Tuổi phải lớn hơn 18)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                if (!CheckTrueDate(datepickerDateOfBirth.Value, datePickerStartDay.Value))
            {
                MetroFramework.MetroMessageBox.Show(this, "Ngày vào làm không hợp lệ (Lớn hơn 18 tuổi)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool CheckPass()
        {
            return txbPassword.Text == txbPassword2.Text;
        }
        #endregion


    }
}
