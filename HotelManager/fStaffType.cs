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
    public partial class fStaffType : Form
    {
        #region Properties
        private DataTable _tableStaffType;
        public DataTable tableStaffType
        {
            get => _tableStaffType;
            private set
            {
                _tableStaffType = value;
                BindingSource source = new BindingSource();
                source.DataSource = _tableStaffType;
                dataGridViewStaffType.DataSource = source;
                bindingStaffType.BindingSource = source;
            }
        }
        #endregion

        #region Constructor
        public fStaffType()
        {
            InitializeComponent();
        }
        public fStaffType(DataTable table)
        {
            InitializeComponent();
            this.tableStaffType = table;
        }

        #endregion

        #region Load
        private void LoadFullStaffType()
        {
            this.tableStaffType = GetFullStaffType();
        }
        #endregion

        #region Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddStaffType_Click(object sender, EventArgs e)
        {
            if (btnAddStaffType.ButtonText.Contains("Thêm"))
                InsertStaffType();
            else
                UpdateStaffType();
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridViewStaffType.SelectedRows)
            {
                Row.Selected = false;
            }
            int last = dataGridViewStaffType.RowCount - 1;
            dataGridViewStaffType.Rows[last].Selected = true;
        }

        #endregion

        #region Method
        private void InsertStaffType()
        {
            if (CheckFill(new Control[] { txbName }))
            {
                if (AccountTypeDAO.Instance.InsertStaffType(txbName.Text))
                {
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadFullStaffType();
                }
                else
                    MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UpdateStaffType()
        {
            if (!CheckFill(new Control[] { txbName }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                AccountType StaffTypePre = groupStaffType.Tag as AccountType;
                try
                {
                    AccountType StaffTypeNow = new AccountType(int.Parse(txbID.Text), txbName.Text);
                    if (StaffTypeNow.Equals(StaffTypePre))
                        MessageBox.Show("Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = AccountTypeDAO.Instance.UpdateStaffType(StaffTypeNow);
                        if (check)
                        {
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupStaffType.Tag = StaffTypeNow;
                            LoadFullStaffType();
                        }
                        else
                            MessageBox.Show("Trùng loại nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi Nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txbID.Text = "Tự Động";
                txbName.Text = string.Empty;
                btnAddStaffType.ButtonText = "Thêm";
            }
            else
            {
                txbID.Text = row.Cells["colID"].Value.ToString();
                txbName.Text = row.Cells["colName"].Value.ToString();

                AccountType customerType = new AccountType(((DataRowView)row.DataBoundItem).Row);
                groupStaffType.Tag = customerType;
                btnAddStaffType.ButtonText = "Cập Nhật";
            }
        }
        public bool CheckFill(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == "")
                    return false;
            }
            return true;
        }

        #endregion

        #region GetData
        private DataTable GetFullStaffType()
        {
            return AccountTypeDAO.Instance.LoadFullStaffType();
        }
        #endregion

        #region Change
        private void dataGridViewStaffType_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStaffType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewStaffType.SelectedRows[0];
                ChangeText(row);
            }
        }

        #endregion
    }
}
