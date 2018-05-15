using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fRoomType : Form
    {
        #region Property
        private DataTable _tableRoomType;
        public DataTable TableRoomType
        {
            get => _tableRoomType;
            private set
            {
                _tableRoomType = value;
                BindingSource source = new BindingSource();
                source.DataSource = _tableRoomType;
                dataGridViewRoomType.DataSource = source;
                bindingCustomerType.BindingSource = source;
            }
        }

        #endregion

        #region Constructor
        public fRoomType()
        {
            InitializeComponent();
        }
        public fRoomType(DataTable table)
        {
            InitializeComponent();
            TableRoomType = table;
            //LoadFullRoomType();
        }
        #endregion

        #region Load
        private void LoadFullRoomType()
        {
            this.TableRoomType = GetFullRoomType();
        }
        #endregion

        #region Click
        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnAddRoomType_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn thêm loại phòng mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if(result == DialogResult.OK)
                InsertRoomType();
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbID.Text = "Tự Động";
            txbName.Text = string.Empty;
            txbPrice.Text = "0";
            txbLimitPerson.Text = "0";
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn cập nhật loại phòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateRoomType();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            if (saveRoomType.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (saveRoomType.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridViewRoomType, saveRoomType.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridViewRoomType, saveRoomType.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridViewRoomType, saveRoomType.FileName, ModeExportToExcel.XLS);
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

        #region GetData
        private DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }
        private RoomType GetRoomTypeNow()
        {
            RoomType roomType = new RoomType();
            try
            {
                roomType.Id = int.Parse(txbID.Text);
            }
            catch
            {
                roomType.Id = 0;
            }
            roomType.Name = txbName.Text;
            roomType.Price = int.Parse(txbPrice.Text);
            roomType.LimitPerson = int.Parse(txbLimitPerson.Text);
            return roomType;
        }
        #endregion

        #region Method
        private void InsertRoomType()
        {
            if (fCustomer.CheckFillInText(new Control[] { txbName, txbPrice, txbLimitPerson }))
            {
                try
                {
                    RoomType roomTypeNow = GetRoomTypeNow();
                    if (RoomTypeDAO.Instance.InsertRoomType(roomTypeNow))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadFullRoomType();
                    }
                    else
                        MetroFramework.MetroMessageBox.Show(this, "Loại phòng này đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi loại phòng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UpdateRoomType()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbName, txbPrice, txbLimitPerson }))
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                RoomType roomTypePre = groupRoomType.Tag as RoomType;
                try
                {
                    RoomType roomTypeNow = GetRoomTypeNow();
                    if (roomTypeNow.Equals(roomTypePre))
                        MetroFramework.MetroMessageBox.Show(this, "Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = RoomTypeDAO.Instance.UpdateRoomType(roomTypeNow, roomTypePre);
                        if(check)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Cập nhật thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupRoomType.Tag = roomTypeNow;
                            LoadFullRoomType();
                        }
                        else
                            MetroFramework.MetroMessageBox.Show(this, "Loại phòng này chưa tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi Nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txbID.Text = "Tự Động";
                txbName.Text = string.Empty;
                txbPrice.Text = "0";
                txbLimitPerson.Text = "0";
            }
            else
            {
                txbID.Text = row.Cells["colID"].Value.ToString();
                txbName.Text = row.Cells["colName"].Value.ToString();
                txbPrice.Text = row.Cells["colPrice"].Value.ToString();
                txbLimitPerson.Text = row.Cells["colLimitPerson"].Value.ToString();
                RoomType roomType = new RoomType(((DataRowView) row.DataBoundItem).Row);
                groupRoomType.Tag = roomType;
            }
        }

        #endregion

        #region Change
        private void DataGridViewRoomType_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRoomType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewRoomType.SelectedRows[0];
                ChangeText(row);
            }
        }



        #endregion

        #region Check Idigit
        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }




        #endregion

    }
}
