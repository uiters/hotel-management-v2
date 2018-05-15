using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fService : Form
    {
        #region Properties
        fServiceType _fServiceType;
        #endregion

        #region Constructor
        public fService()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            LoadFullService();
            LoadFullServiceType();
        }
        #endregion

        #region Load
        private void LoadFullService()
        {
            DataTable table = GetFullService();
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dataGridViewService.DataSource = source;
            bindingService.BindingSource = source;
        }
        private void LoadFullServiceType()
        {
            DataTable table = GetFullServiceType();
            comboBoxServiceType.DataSource = table;
            comboBoxServiceType.DisplayMember = "name";
            ;
            if (table.Rows.Count > 0)
                comboBoxServiceType.SelectedIndex = 0;
            _fServiceType = new fServiceType(table);
        }
        #endregion

        #region Click
        private void BtnInsertService_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn thêm mới dịch vụ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertService();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn cập nhật lại dịch vụ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateService();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnServiceType_Click(object sender, EventArgs e)
        {
            this.Hide();
            _fServiceType.ShowDialog();
            this.LoadFullService();
            comboBoxServiceType.DataSource = _fServiceType.TableSerViceType;
            this.Show();
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbID.Text = "Tự Động";
            txbName.Text = string.Empty;
            txbPrice.Text = string.Empty;
        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            if (saveService.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (saveService.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridViewService, saveService.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridViewService, saveService.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridViewService, saveService.FileName, ModeExportToExcel.XLS);
                            break;
                    }
                    if (check)
                        MetroFramework.MetroMessageBox.Show(this, "Xuất thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MetroFramework.MetroMessageBox.Show(this, "Lỗi xuất thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi (Cần cài đặt Office)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Method
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                txbID.Text = "Tự Động";
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
            }
            else
            {
                txbID.Text = row.Cells["colID"].Value.ToString();
                txbName.Text = row.Cells["colName"].Value.ToString();
                comboBoxServiceType.SelectedIndex = (int)row.Cells["colIdServiceType"].Value - 1;
                txbPrice.Text = row.Cells["colPrice"].Value.ToString();
                Service room = new Service(((DataRowView)row.DataBoundItem).Row);
                groupService.Tag = room;
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }
        private void InsertService()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbName, comboBoxServiceType, txbPrice }))
            {
                DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Service serviceNow = GetServiceNow();
                if (ServiceDAO.Instance.InsertService(serviceNow))
                {
                   MetroFramework.MetroMessageBox.Show(this, "Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFullService();
                }
                else
                    MetroFramework.MetroMessageBox.Show(this, "Dịch vụ đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateService()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbName, comboBoxServiceType, txbPrice }))
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Service servicePre = groupService.Tag as Service;
                try
                {
                    Service serviceNow = GetServiceNow();
                    if (serviceNow.Equals(servicePre))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = ServiceDAO.Instance.UpdateService(serviceNow, servicePre);
                        if (check)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupService.Tag = serviceNow;
                            LoadFullService();
                        }
                        else
                            MetroFramework.MetroMessageBox.Show(this, "Dịch vụ không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Get Data
        private DataTable GetFullService()
        {
            return ServiceDAO.Instance.LoadFullService();
        }
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDAO.Instance.LoadFullServiceType();
        }
        private Service GetServiceNow()
        {
            Service service = new Service();
            try
            {
                service.Id = int.Parse(txbID.Text);
            }
            catch
            {
                service.Id = -1;
            }
            service.Name = txbName.Text;
            service.Price = int.Parse(txbPrice.Text);
            int index = comboBoxServiceType.SelectedIndex;
            service.IdServiceType = (int)((DataTable)comboBoxServiceType.DataSource).Rows[index]["id"];
            return service;
        }
        #endregion

        #region Change
        private void dataGridViewService_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewService.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewService.SelectedRows[0];
                ChangeText(row);
            }
        }




        #endregion

        #region Key
        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        #endregion


    }
}
