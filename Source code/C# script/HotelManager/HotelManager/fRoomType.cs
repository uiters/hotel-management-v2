using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Globalization;
using System.Text;
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
                ChangePrice(_tableRoomType);
                source.DataSource = _tableRoomType;
                dataGridViewRoomType.DataSource = source;
                bindingCustomerType.BindingSource = source;
                comboboxID.DataSource = source;
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
            comboboxID.DisplayMember = "id";
            dataGridViewRoomType.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }
        #endregion

        #region Load
        private void LoadFullRoomType(DataTable table)
        {
            this.TableRoomType = table;
        }
        #endregion

        #region Click
        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //private void BtnAddRoomType_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show( "Bạn có muốn thêm loại phòng mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        //    if(result == DialogResult.OK)
        //        InsertRoomType();
        //}
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            comboboxID.Text = "Tự Động";
            txbName.Text = string.Empty;
            txbPrice.Text = "0";
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Bạn có muốn cập nhật loại phòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateRoomType();
            comboboxID.Focus();
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
                        MessageBox.Show( "Xuất thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show( "Lỗi xuất thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show( "Lỗi (Cần cài đặt Office)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LoadFullRoomType(GetFullRoomType());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
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
            if (comboboxID.Text == string.Empty)
                roomType.Id = 0;
            else
                roomType.Id = int.Parse(comboboxID.Text);

            roomType.Name = txbName.Text;
            roomType.Price = int.Parse(StringToInt(txbPrice.Text));
            roomType.LimitPerson = int.Parse(txbLimitPerson.Text);
            return roomType;
        }
        private DataTable GetSearchRoomType()
        {
            if (int.TryParse(txbSearch.Text, out int id))
                return RoomTypeDAO.Instance.Search(txbSearch.Text, id);
            else
                return RoomTypeDAO.Instance.Search(txbSearch.Text, 0);
        }

        #endregion

        #region Method
        //private void InsertRoomType()
        //{
        //    if (fCustomer.CheckFillInText(new Control[] { txbName, txbPrice, txbLimitPerson }))
        //    {
        //        try
        //        {
        //            RoomType roomTypeNow = GetRoomTypeNow();
        //            if (RoomTypeDAO.Instance.InsertRoomType(roomTypeNow))
        //            {
        //                MessageBox.Show( "Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                this.LoadFullRoomType();
        //            }
        //            else
        //                MessageBox.Show( "Loại phòng này đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        catch
        //        {
        //            MessageBox.Show( "Lỗi loại phòng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        }
        //    }
        //    else
        //        MessageBox.Show( "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        private void UpdateRoomType()
        {
            if(comboboxID.Text == string.Empty)
            {
                MessageBox.Show( "Loại phòng này chưa tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            if (!fCustomer.CheckFillInText(new Control[] { txbName, txbPrice }))
            {
                MessageBox.Show( "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                RoomType roomTypePre = groupRoomType.Tag as RoomType;
                try
                {
                    RoomType roomTypeNow = GetRoomTypeNow();
                    if (roomTypeNow.Equals(roomTypePre))
                        MessageBox.Show( "Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = RoomTypeDAO.Instance.UpdateRoomType(roomTypeNow, roomTypePre);
                        if(check)
                        {
                            MessageBox.Show( "Cập nhật thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupRoomType.Tag = roomTypeNow;
                            if (btnCancel.Visible == false)
                            {
                                int index = dataGridViewRoomType.SelectedRows[0].Index;
                                LoadFullRoomType(GetFullRoomType());
                                comboboxID.SelectedIndex = index;
                            }
                            else
                                BtnCancel_Click(null, null);
                        }
                        else
                            MessageBox.Show( "Loại phòng này chưa tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    
                    MessageBox.Show( "Lỗi Nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txbName.Text = string.Empty;
                txbPrice.Text = "0";
                txbLimitPerson.Text = "0";
            }
            else
            {
                txbName.Text = row.Cells["colName"].Value.ToString();
                txbPrice.Text = (string)row.Cells["colPrice"].Value;
                txbLimitPerson.Text = row.Cells["colLimitPerson"].Value.ToString();
                RoomType roomType = new RoomType(((DataRowView) row.DataBoundItem).Row);
                groupRoomType.Tag = roomType;
            }
        }
        private void Search()
        {
            LoadFullRoomType(GetSearchRoomType());
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
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("price_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            }         
        }
        private string StringToInt(string text)
        {
            if (text.Contains(".") || text.Contains(" "))
            {
                string[] vs = text.Split(new char[] { '.', ' ' });
                StringBuilder textNow = new StringBuilder();
                for (int i = 0; i < vs.Length - 1; i++)
                {
                    textNow.Append(vs[i]);
                }
                return textNow.ToString();
            }
            else return text;
        }
        private string IntToString(string text)
        {
            if (text == string.Empty)
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            if (text.Contains(".") || text.Contains(" "))
                return text;
            else
                return (int.Parse(text).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN")));
        }

        #endregion

        #region Check Idigit
        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }
        #endregion

        #region Key
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FRoomType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        #endregion

        #region Leave
        private void TxbName_Leave(object sender, EventArgs e)
        {
            if (txbName.Text == string.Empty)
                txbName.Text = txbName.Tag as String;

        }
        private void TxbPrice_Leave(object sender, EventArgs e)
        {
            if (txbPrice.Text == string.Empty)
            {
                txbPrice.Text = (string)txbPrice.Tag;
            }
            else
                txbPrice.Text = IntToString(txbPrice.Text);
        }
        private void TxbLimitPerson_Leave(object sender, EventArgs e)
        {
            if (txbLimitPerson.Text == string.Empty)
                txbLimitPerson.Text = txbLimitPerson.Tag as String;
        }
        #endregion

        #region Enter
        private void TxbPrice_Enter(object sender, EventArgs e)
        {
            txbPrice.Tag = txbPrice.Text;
            txbPrice.Text = StringToInt(txbPrice.Text);
        }
        private void TxbName_Enter(object sender, EventArgs e)
        {
            txbName.Tag = txbName.Text;
        }
        private void TxbLimitPerson_Enter(object sender, EventArgs e)
        {
            txbLimitPerson.Tag = txbLimitPerson.Text;
        }

        #endregion

        #region Close
        private void FRoomType_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(sender, null);
        }
        #endregion
    }
}
