using System.Data;
using System.Windows.Forms;
using HotelManager.DAO;
using HotelManager.DTO;
using System;

namespace HotelManager
{
    public partial class fServiceType : Form
    {
        #region Properties
        DataTable _tableSerViceType;
        public DataTable TableSerViceType
        {
            get => _tableSerViceType;
            private set
            {
                _tableSerViceType = value;
                BindingSource source = new BindingSource();
                source.DataSource = _tableSerViceType;
                dataGridViewServiceType.DataSource = source;
                bindingServiceType.BindingSource = source;
            }
        }

        #endregion

        #region Constructor
        public fServiceType()
        {
            InitializeComponent();
        }
        public fServiceType(DataTable table)
        {
            InitializeComponent();
            this.TableSerViceType = table;
        }
        #endregion

        #region Load
        private void LoadFullServiceType()
        {
            this.TableSerViceType = GetFullServiceType();
        }
        #endregion

        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnUpdateServiceType_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn cập nhật loại dịch vụ này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateServiceType();
        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn thêm mới loại dịch vụ không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertServiceType();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txbName.Text = string.Empty;
            txbID.Text = "Tự Động";
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            bool check;
            if (saveServiceType.ShowDialog() == DialogResult.Cancel)
                return;
            try
            {
                switch (saveServiceType.FilterIndex)
                {
                    case 2:
                        check = ExportToExcel.Instance.Export(dataGridViewServiceType, saveServiceType.FileName, ModeExportToExcel.XLSX);
                        break;
                    case 3:
                        check = ExportToExcel.Instance.Export(dataGridViewServiceType, saveServiceType.FileName, ModeExportToExcel.PDF);
                        break;
                    default:
                        check = ExportToExcel.Instance.Export(dataGridViewServiceType, saveServiceType.FileName, ModeExportToExcel.XLS);
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

        #endregion

        #region GetData
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDAO.Instance.LoadFullServiceType();
        }
        private ServiceType GetServiceTypeNow()
        {
            ServiceType serviceType = new ServiceType();
            try
            {
                serviceType.Id = int.Parse(txbID.Text);
            }
            catch
            {
                serviceType.Id = -1;
            }
            serviceType.Name = txbName.Text;
            return serviceType;
        }
        #endregion

        #region Method
        private void InsertServiceType()
        {
            if (fCustomer.CheckFillInText(new Control[] { txbName }))
            {
                try
                {
                    ServiceType serviceTypeNow = GetServiceTypeNow();
                    if (ServiceTypeDAO.Instance.InsertServiceType(serviceTypeNow))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadFullServiceType();
                    }
                    else
                        MetroFramework.MetroMessageBox.Show(this, "Lỗi nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi loại dịch vụ đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void UpdateServiceType()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbName }))
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ServiceType serviceTypePre = groupServiceType.Tag as ServiceType;
                try
                {
                    ServiceType serviceTypeNow = GetServiceTypeNow();
                    if (serviceTypeNow.Equals(serviceTypePre))
                        MetroFramework.MetroMessageBox.Show(this, "Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = ServiceTypeDAO.Instance.UpdateServiceType(serviceTypeNow, serviceTypePre);
                        if (check)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupServiceType.Tag = serviceTypeNow;
                            LoadFullServiceType();
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Loại dịch vụ này chưa tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi loại dịch vụ đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                txbID.Text = "Tự Động";
                txbName.Text = string.Empty;
            }
            else
            {
                txbID.Text = row.Cells["colID"].Value.ToString();
                txbName.Text = row.Cells["colName"].Value.ToString();
                ServiceType roomType = new ServiceType(((DataRowView)row.DataBoundItem).Row);
                groupServiceType.Tag = roomType;
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }
        #endregion

        #region Change
        private void dataGridViewServiceType_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewServiceType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewServiceType.SelectedRows[0];
                ChangeText(row);
            }
        }

        #endregion

        #region Key
        private void fServiceType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnUpdateServiceType_Click(sender, e);
            }
        }


        #endregion
    }
}
