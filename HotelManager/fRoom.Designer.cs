namespace HotelManager
{
    partial class fRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fRoom));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txbSreach = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupRoom = new System.Windows.Forms.GroupBox();
            this.btnStatusRoom = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnRoomType = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnAddRoom = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxRoomType = new MetroFramework.Controls.MetroComboBox();
            this.txbID = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.comboBoxStatusRoom = new MetroFramework.Controls.MetroComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txbNameRoom = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewRoom = new System.Windows.Forms.DataGridView();
            this.colIDRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameRoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdRoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdStutus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingRoom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupRoom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRoom)).BeginInit();
            this.bindingRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(776, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 14);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 27;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.txbSreach);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox3.Location = new System.Drawing.Point(12, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 143);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // btnSearch
            // 
            this.btnSearch.ActiveBorderThickness = 1;
            this.btnSearch.ActiveCornerRadius = 20;
            this.btnSearch.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.ActiveForecolor = System.Drawing.Color.White;
            this.btnSearch.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.ButtonText = "Tìm Kiếm";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.IdleBorderThickness = 1;
            this.btnSearch.IdleCornerRadius = 20;
            this.btnSearch.IdleFillColor = System.Drawing.Color.White;
            this.btnSearch.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnSearch.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.Location = new System.Drawing.Point(22, 81);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 40);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbSreach
            // 
            this.txbSreach.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbSreach.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbSreach.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbSreach.BorderThickness = 1;
            this.txbSreach.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbSreach.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbSreach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbSreach.isPassword = false;
            this.txbSreach.Location = new System.Drawing.Point(22, 44);
            this.txbSreach.Margin = new System.Windows.Forms.Padding(4);
            this.txbSreach.Name = "txbSreach";
            this.txbSreach.Size = new System.Drawing.Size(200, 29);
            this.txbSreach.TabIndex = 27;
            this.txbSreach.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SeaGreen;
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "ID:";
            // 
            // groupRoom
            // 
            this.groupRoom.Controls.Add(this.btnStatusRoom);
            this.groupRoom.Controls.Add(this.btnRoomType);
            this.groupRoom.Controls.Add(this.btnAddRoom);
            this.groupRoom.Controls.Add(this.label16);
            this.groupRoom.Controls.Add(this.comboBoxRoomType);
            this.groupRoom.Controls.Add(this.txbID);
            this.groupRoom.Controls.Add(this.comboBoxStatusRoom);
            this.groupRoom.Controls.Add(this.label13);
            this.groupRoom.Controls.Add(this.label20);
            this.groupRoom.Controls.Add(this.label15);
            this.groupRoom.Controls.Add(this.txbNameRoom);
            this.groupRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupRoom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupRoom.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupRoom.Location = new System.Drawing.Point(12, 181);
            this.groupRoom.Name = "groupRoom";
            this.groupRoom.Size = new System.Drawing.Size(244, 311);
            this.groupRoom.TabIndex = 33;
            this.groupRoom.TabStop = false;
            this.groupRoom.Text = "Thông tin phòng";
            // 
            // btnStatusRoom
            // 
            this.btnStatusRoom.ActiveBorderThickness = 1;
            this.btnStatusRoom.ActiveCornerRadius = 20;
            this.btnStatusRoom.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnStatusRoom.ActiveForecolor = System.Drawing.Color.White;
            this.btnStatusRoom.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnStatusRoom.BackColor = System.Drawing.Color.White;
            this.btnStatusRoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStatusRoom.BackgroundImage")));
            this.btnStatusRoom.ButtonText = "Sửa";
            this.btnStatusRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatusRoom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusRoom.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnStatusRoom.IdleBorderThickness = 1;
            this.btnStatusRoom.IdleCornerRadius = 15;
            this.btnStatusRoom.IdleFillColor = System.Drawing.Color.White;
            this.btnStatusRoom.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnStatusRoom.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnStatusRoom.Location = new System.Drawing.Point(169, 206);
            this.btnStatusRoom.Margin = new System.Windows.Forms.Padding(4);
            this.btnStatusRoom.Name = "btnStatusRoom";
            this.btnStatusRoom.Size = new System.Drawing.Size(53, 39);
            this.btnStatusRoom.TabIndex = 51;
            this.btnStatusRoom.TabStop = false;
            this.btnStatusRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStatusRoom.Click += new System.EventHandler(this.btnStatusRoom_Click);
            // 
            // btnRoomType
            // 
            this.btnRoomType.ActiveBorderThickness = 1;
            this.btnRoomType.ActiveCornerRadius = 20;
            this.btnRoomType.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnRoomType.ActiveForecolor = System.Drawing.Color.White;
            this.btnRoomType.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnRoomType.BackColor = System.Drawing.Color.White;
            this.btnRoomType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRoomType.BackgroundImage")));
            this.btnRoomType.ButtonText = "Sửa";
            this.btnRoomType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoomType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomType.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnRoomType.IdleBorderThickness = 1;
            this.btnRoomType.IdleCornerRadius = 15;
            this.btnRoomType.IdleFillColor = System.Drawing.Color.White;
            this.btnRoomType.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnRoomType.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnRoomType.Location = new System.Drawing.Point(169, 150);
            this.btnRoomType.Margin = new System.Windows.Forms.Padding(4);
            this.btnRoomType.Name = "btnRoomType";
            this.btnRoomType.Size = new System.Drawing.Size(53, 39);
            this.btnRoomType.TabIndex = 50;
            this.btnRoomType.TabStop = false;
            this.btnRoomType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRoomType.Click += new System.EventHandler(this.btnRoomType_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.ActiveBorderThickness = 1;
            this.btnAddRoom.ActiveCornerRadius = 20;
            this.btnAddRoom.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnAddRoom.ActiveForecolor = System.Drawing.Color.White;
            this.btnAddRoom.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddRoom.BackColor = System.Drawing.Color.White;
            this.btnAddRoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddRoom.BackgroundImage")));
            this.btnAddRoom.ButtonText = "Thêm Phòng";
            this.btnAddRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRoom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoom.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAddRoom.IdleBorderThickness = 1;
            this.btnAddRoom.IdleCornerRadius = 15;
            this.btnAddRoom.IdleFillColor = System.Drawing.Color.White;
            this.btnAddRoom.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnAddRoom.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddRoom.Location = new System.Drawing.Point(22, 253);
            this.btnAddRoom.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(203, 45);
            this.btnAddRoom.TabIndex = 8;
            this.btnAddRoom.TabStop = false;
            this.btnAddRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.SeaGreen;
            this.label16.Location = new System.Drawing.Point(15, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 20);
            this.label16.TabIndex = 22;
            this.label16.Text = "ID";
            // 
            // comboBoxRoomType
            // 
            this.comboBoxRoomType.BackColor = System.Drawing.Color.White;
            this.comboBoxRoomType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRoomType.FormattingEnabled = true;
            this.comboBoxRoomType.ItemHeight = 23;
            this.comboBoxRoomType.Location = new System.Drawing.Point(22, 156);
            this.comboBoxRoomType.Name = "comboBoxRoomType";
            this.comboBoxRoomType.Size = new System.Drawing.Size(146, 29);
            this.comboBoxRoomType.TabIndex = 2;
            this.comboBoxRoomType.UseCustomBackColor = true;
            this.comboBoxRoomType.UseCustomForeColor = true;
            this.comboBoxRoomType.UseSelectable = true;
            this.comboBoxRoomType.UseStyleColors = true;
            // 
            // txbID
            // 
            this.txbID.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbID.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbID.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbID.BorderThickness = 1;
            this.txbID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbID.Enabled = false;
            this.txbID.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbID.isPassword = false;
            this.txbID.Location = new System.Drawing.Point(22, 44);
            this.txbID.Margin = new System.Windows.Forms.Padding(0);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(200, 29);
            this.txbID.TabIndex = 0;
            this.txbID.Text = "Tự Động";
            this.txbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBoxStatusRoom
            // 
            this.comboBoxStatusRoom.BackColor = System.Drawing.Color.White;
            this.comboBoxStatusRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxStatusRoom.FormattingEnabled = true;
            this.comboBoxStatusRoom.ItemHeight = 23;
            this.comboBoxStatusRoom.Location = new System.Drawing.Point(22, 211);
            this.comboBoxStatusRoom.Name = "comboBoxStatusRoom";
            this.comboBoxStatusRoom.Size = new System.Drawing.Size(146, 29);
            this.comboBoxStatusRoom.TabIndex = 4;
            this.comboBoxStatusRoom.UseCustomBackColor = true;
            this.comboBoxStatusRoom.UseCustomForeColor = true;
            this.comboBoxStatusRoom.UseSelectable = true;
            this.comboBoxStatusRoom.UseStyleColors = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.SeaGreen;
            this.label13.Location = new System.Drawing.Point(15, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Trạng Thái";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.SeaGreen;
            this.label20.Location = new System.Drawing.Point(15, 133);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 20);
            this.label20.TabIndex = 41;
            this.label20.Text = "Loại Phòng";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.SeaGreen;
            this.label15.Location = new System.Drawing.Point(15, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 20);
            this.label15.TabIndex = 24;
            this.label15.Text = "Tên Phòng";
            // 
            // txbNameRoom
            // 
            this.txbNameRoom.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbNameRoom.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbNameRoom.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbNameRoom.BorderThickness = 1;
            this.txbNameRoom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbNameRoom.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbNameRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbNameRoom.isPassword = false;
            this.txbNameRoom.Location = new System.Drawing.Point(22, 100);
            this.txbNameRoom.Margin = new System.Windows.Forms.Padding(0);
            this.txbNameRoom.Name = "txbNameRoom";
            this.txbNameRoom.Size = new System.Drawing.Size(200, 29);
            this.txbNameRoom.TabIndex = 1;
            this.txbNameRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewRoom);
            this.groupBox1.Controls.Add(this.bindingRoom);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox1.Location = new System.Drawing.Point(262, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 460);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Phòng";
            // 
            // dataGridViewRoom
            // 
            this.dataGridViewRoom.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRoom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewRoom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIDRoom,
            this.colName,
            this.colNameRoomType,
            this.colStatus,
            this.colIdRoomType,
            this.colIdStutus});
            this.dataGridViewRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRoom.Location = new System.Drawing.Point(3, 64);
            this.dataGridViewRoom.Name = "dataGridViewRoom";
            this.dataGridViewRoom.ReadOnly = true;
            this.dataGridViewRoom.RowHeadersVisible = false;
            this.dataGridViewRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRoom.Size = new System.Drawing.Size(529, 393);
            this.dataGridViewRoom.TabIndex = 28;
            // 
            // colIDRoom
            // 
            this.colIDRoom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIDRoom.DataPropertyName = "id";
            this.colIDRoom.HeaderText = "ID";
            this.colIDRoom.Name = "colIDRoom";
            this.colIDRoom.ReadOnly = true;
            this.colIDRoom.Width = 45;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "name";
            this.colName.HeaderText = "Tên";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 53;
            // 
            // colNameRoomType
            // 
            this.colNameRoomType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNameRoomType.DataPropertyName = "nameRoomType";
            this.colNameRoomType.HeaderText = "Loại Phòng";
            this.colNameRoomType.Name = "colNameRoomType";
            this.colNameRoomType.ReadOnly = true;
            this.colNameRoomType.Width = 98;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.DataPropertyName = "nameStatusRoom";
            this.colStatus.HeaderText = "Trạng Thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colIdRoomType
            // 
            this.colIdRoomType.DataPropertyName = "idRoomType";
            this.colIdRoomType.HeaderText = "";
            this.colIdRoomType.Name = "colIdRoomType";
            this.colIdRoomType.ReadOnly = true;
            this.colIdRoomType.Visible = false;
            // 
            // colIdStutus
            // 
            this.colIdStutus.DataPropertyName = "idStatusRoom";
            this.colIdStutus.HeaderText = "";
            this.colIdStutus.Name = "colIdStutus";
            this.colIdStutus.ReadOnly = true;
            this.colIdStutus.Visible = false;
            // 
            // bindingRoom
            // 
            this.bindingRoom.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingRoom.AutoSize = false;
            this.bindingRoom.BackColor = System.Drawing.Color.Transparent;
            this.bindingRoom.CountItem = this.bindingNavigatorCountItem;
            this.bindingRoom.CountItemFormat = "của {0}";
            this.bindingRoom.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingRoom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingRoom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingRoom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.toolStripButton1,
            this.toolStripLabel1});
            this.bindingRoom.Location = new System.Drawing.Point(3, 21);
            this.bindingRoom.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingRoom.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingRoom.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingRoom.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingRoom.Name = "bindingRoom";
            this.bindingRoom.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingRoom.Size = new System.Drawing.Size(529, 43);
            this.bindingRoom.TabIndex = 29;
            this.bindingRoom.Text = "binding";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.AutoSize = false;
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(47, 40);
            this.bindingNavigatorCountItem.Text = "của {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.AutoSize = false;
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AutoSize = false;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AutoSize = false;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 43);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AutoSize = false;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AutoSize = false;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(50, 40);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 40);
            this.toolStripLabel1.Text = "Eport";
            // 
            // fRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 504);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupRoom);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fRoom";
            this.Text = "fRoom";
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupRoom.ResumeLayout(false);
            this.groupRoom.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRoom)).EndInit();
            this.bindingRoom.ResumeLayout(false);
            this.bindingRoom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSearch;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbSreach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupRoom;
        private Bunifu.Framework.UI.BunifuThinButton2 btnRoomType;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddRoom;
        private System.Windows.Forms.Label label16;
        private MetroFramework.Controls.MetroComboBox comboBoxRoomType;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbID;
        private MetroFramework.Controls.MetroComboBox comboBoxStatusRoom;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbNameRoom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewRoom;
        private System.Windows.Forms.BindingNavigator bindingRoom;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnStatusRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameRoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdStutus;
    }
}