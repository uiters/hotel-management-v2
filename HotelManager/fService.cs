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
    public partial class fService : Form
    {
        #region Properties
        fServiceType _fServiceType;
        #endregion

        #region Constructor
        public fService()
        {
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
            if (table.Rows.Count > 0)
                comboBoxServiceType.SelectedIndex = 0;
            _fServiceType = new fServiceType(table);
        }
        #endregion

        #region Click
        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (btnAddService.ButtonText.Contains("Thêm"))
                InsertService();
            else
                UpdateService();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnServiceType_Click(object sender, EventArgs e)
        {
            this.Hide();
            _fServiceType.ShowDialog();
            this.LoadFullService();
            comboBoxServiceType.DataSource = _fServiceType.TableSerViceType;
            this.Show();
        }
        #endregion

        #region Method
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txbID.Text = "Tự Động";
                txbName.Text = string.Empty;
                btnAddService.ButtonText = "Thêm";
                txbPrice.Text = string.Empty;
            }
            else
            {
                txbID.Text = row.Cells["colID"].Value.ToString();
                txbName.Text = row.Cells["colName"].Value.ToString();
                comboBoxServiceType.Text =(string) row.Cells["colNameServiceType"].Value;
                txbPrice.Text = row.Cells["colPrice"].Value.ToString();
                Service room = new Service(((DataRowView)row.DataBoundItem).Row);
                groupService.Tag = room;
                btnAddService.ButtonText = "Cập";
            }
        }
        private void InsertService()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbName, comboBoxServiceType, txbPrice }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Service serviceNow = GetServiceNow();
                if (ServiceDAO.Instance.InsertService(serviceNow))
                {
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFullService();
                }
                else
                    MessageBox.Show("Phòng đã tồn tại\nTrùng số chứng minh nhân dân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateService()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbName, comboBoxServiceType, txbPrice }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = ServiceDAO.Instance.UpdateService(serviceNow, servicePre);
                        if (check)
                        {
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupService.Tag = serviceNow;
                            LoadFullService();
                        }
                        else
                            MessageBox.Show("Phòng đã tồn tại\nTrùng số chứng minh nhân dân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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


    }
}
