namespace HotelManager
{
    partial class fService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fService));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.groupService = new System.Windows.Forms.GroupBox();
            this.txbPrice = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnServiceType = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnAddService = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxServiceType = new MetroFramework.Controls.MetroComboBox();
            this.txbID = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txbName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txbSreach = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewService = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameServiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdNameServiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingService = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.groupService.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingService)).BeginInit();
            this.bindingService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // groupService
            // 
            this.groupService.Controls.Add(this.txbPrice);
            this.groupService.Controls.Add(this.btnServiceType);
            this.groupService.Controls.Add(this.btnAddService);
            this.groupService.Controls.Add(this.label16);
            this.groupService.Controls.Add(this.comboBoxServiceType);
            this.groupService.Controls.Add(this.txbID);
            this.groupService.Controls.Add(this.label13);
            this.groupService.Controls.Add(this.label20);
            this.groupService.Controls.Add(this.label15);
            this.groupService.Controls.Add(this.txbName);
            this.groupService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupService.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupService.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupService.Location = new System.Drawing.Point(12, 184);
            this.groupService.Name = "groupService";
            this.groupService.Size = new System.Drawing.Size(244, 311);
            this.groupService.TabIndex = 41;
            this.groupService.TabStop = false;
            this.groupService.Text = "Thông tin dịch vụ";
            // 
            // txbPrice
            // 
            this.txbPrice.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbPrice.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbPrice.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbPrice.BorderThickness = 1;
            this.txbPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPrice.ForeColor = System.Drawing.Color.SeaGreen;
            this.txbPrice.isPassword = false;
            this.txbPrice.Location = new System.Drawing.Point(22, 216);
            this.txbPrice.Margin = new System.Windows.Forms.Padding(0);
            this.txbPrice.Name = "txbPrice";
            this.txbPrice.Size = new System.Drawing.Size(200, 29);
            this.txbPrice.TabIndex = 51;
            this.txbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnServiceType
            // 
            this.btnServiceType.ActiveBorderThickness = 1;
            this.btnServiceType.ActiveCornerRadius = 20;
            this.btnServiceType.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnServiceType.ActiveForecolor = System.Drawing.Color.White;
            this.btnServiceType.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnServiceType.BackColor = System.Drawing.Color.White;
            this.btnServiceType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnServiceType.BackgroundImage")));
            this.btnServiceType.ButtonText = "Sửa";
            this.btnServiceType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServiceType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServiceType.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnServiceType.IdleBorderThickness = 1;
            this.btnServiceType.IdleCornerRadius = 15;
            this.btnServiceType.IdleFillColor = System.Drawing.Color.White;
            this.btnServiceType.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnServiceType.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnServiceType.Location = new System.Drawing.Point(169, 153);
            this.btnServiceType.Margin = new System.Windows.Forms.Padding(4);
            this.btnServiceType.Name = "btnServiceType";
            this.btnServiceType.Size = new System.Drawing.Size(53, 39);
            this.btnServiceType.TabIndex = 50;
            this.btnServiceType.TabStop = false;
            this.btnServiceType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnServiceType.Click += new System.EventHandler(this.btnServiceType_Click);
            // 
            // btnAddService
            // 
            this.btnAddService.ActiveBorderThickness = 1;
            this.btnAddService.ActiveCornerRadius = 20;
            this.btnAddService.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnAddService.ActiveForecolor = System.Drawing.Color.White;
            this.btnAddService.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddService.BackColor = System.Drawing.Color.White;
            this.btnAddService.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddService.BackgroundImage")));
            this.btnAddService.ButtonText = "Thêm";
            this.btnAddService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddService.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddService.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAddService.IdleBorderThickness = 1;
            this.btnAddService.IdleCornerRadius = 15;
            this.btnAddService.IdleFillColor = System.Drawing.Color.White;
            this.btnAddService.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnAddService.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddService.Location = new System.Drawing.Point(22, 253);
            this.btnAddService.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(203, 45);
            this.btnAddService.TabIndex = 8;
            this.btnAddService.TabStop = false;
            this.btnAddService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.SeaGreen;
            this.label16.Location = new System.Drawing.Point(15, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 20);
            this.label16.TabIndex = 22;
            this.label16.Text = "Mã dịch vụ";
            // 
            // comboBoxServiceType
            // 
            this.comboBoxServiceType.BackColor = System.Drawing.Color.White;
            this.comboBoxServiceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxServiceType.ForeColor = System.Drawing.Color.SeaGreen;
            this.comboBoxServiceType.FormattingEnabled = true;
            this.comboBoxServiceType.ItemHeight = 23;
            this.comboBoxServiceType.Location = new System.Drawing.Point(22, 159);
            this.comboBoxServiceType.Name = "comboBoxServiceType";
            this.comboBoxServiceType.Size = new System.Drawing.Size(146, 29);
            this.comboBoxServiceType.Style = MetroFramework.MetroColorStyle.Green;
            this.comboBoxServiceType.TabIndex = 2;
            this.comboBoxServiceType.UseCustomBackColor = true;
            this.comboBoxServiceType.UseCustomForeColor = true;
            this.comboBoxServiceType.UseSelectable = true;
            this.comboBoxServiceType.UseStyleColors = true;
            // 
            // txbID
            // 
            this.txbID.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbID.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbID.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbID.BorderThickness = 1;
            this.txbID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbID.Enabled = false;
            this.txbID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbID.ForeColor = System.Drawing.Color.SeaGreen;
            this.txbID.isPassword = false;
            this.txbID.Location = new System.Drawing.Point(22, 44);
            this.txbID.Margin = new System.Windows.Forms.Padding(0);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(200, 29);
            this.txbID.TabIndex = 0;
            this.txbID.Text = "Tự Động";
            this.txbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.SeaGreen;
            this.label13.Location = new System.Drawing.Point(15, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Giá";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.SeaGreen;
            this.label20.Location = new System.Drawing.Point(15, 133);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 20);
            this.label20.TabIndex = 41;
            this.label20.Text = "Loại dịch vụ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.SeaGreen;
            this.label15.Location = new System.Drawing.Point(15, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 20);
            this.label15.TabIndex = 24;
            this.label15.Text = "Tên dịch vụ";
            // 
            // txbName
            // 
            this.txbName.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbName.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbName.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbName.BorderThickness = 1;
            this.txbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbName.ForeColor = System.Drawing.Color.SeaGreen;
            this.txbName.isPassword = false;
            this.txbName.Location = new System.Drawing.Point(22, 100);
            this.txbName.Margin = new System.Windows.Forms.Padding(0);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(200, 29);
            this.txbName.TabIndex = 1;
            this.txbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.txbSreach);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox3.Location = new System.Drawing.Point(12, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 143);
            this.groupBox3.TabIndex = 40;
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
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Mã dịch vụ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewService);
            this.groupBox1.Controls.Add(this.bindingService);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox1.Location = new System.Drawing.Point(262, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 460);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Dịch Vụ";
            // 
            // dataGridViewService
            // 
            this.dataGridViewService.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewService.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewService.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colPrice,
            this.colNameServiceType,
            this.colIdNameServiceType});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewService.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewService.Location = new System.Drawing.Point(3, 64);
            this.dataGridViewService.Name = "dataGridViewService";
            this.dataGridViewService.ReadOnly = true;
            this.dataGridViewService.RowHeadersVisible = false;
            this.dataGridViewService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewService.Size = new System.Drawing.Size(529, 393);
            this.dataGridViewService.TabIndex = 28;
            this.dataGridViewService.SelectionChanged += new System.EventHandler(this.dataGridViewService_SelectionChanged);
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colID.DataPropertyName = "id";
            this.colID.HeaderText = "Mã";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 52;
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
            // colPrice
            // 
            this.colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPrice.DataPropertyName = "price";
            this.colPrice.HeaderText = "Giá";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 52;
            // 
            // colNameServiceType
            // 
            this.colNameServiceType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNameServiceType.DataPropertyName = "nameServiceType";
            this.colNameServiceType.HeaderText = "Loại dịch vụ";
            this.colNameServiceType.Name = "colNameServiceType";
            this.colNameServiceType.ReadOnly = true;
            // 
            // colIdNameServiceType
            // 
            this.colIdNameServiceType.DataPropertyName = "idServiceType";
            this.colIdNameServiceType.HeaderText = "";
            this.colIdNameServiceType.Name = "colIdNameServiceType";
            this.colIdNameServiceType.ReadOnly = true;
            this.colIdNameServiceType.Visible = false;
            // 
            // bindingService
            // 
            this.bindingService.AddNewItem = null;
            this.bindingService.AutoSize = false;
            this.bindingService.BackColor = System.Drawing.Color.Transparent;
            this.bindingService.CountItem = this.bindingNavigatorCountItem;
            this.bindingService.CountItemFormat = "của {0}";
            this.bindingService.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingService.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingService.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingService.Location = new System.Drawing.Point(3, 21);
            this.bindingService.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingService.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingService.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingService.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingService.Name = "bindingService";
            this.bindingService.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingService.Size = new System.Drawing.Size(529, 43);
            this.bindingService.TabIndex = 29;
            this.bindingService.Text = "binding";
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
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.AutoSize = false;
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
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
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(778, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClose.TabIndex = 39;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(808, 505);
            this.Controls.Add(this.groupService);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SeaGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fService";
            this.groupService.ResumeLayout(false);
            this.groupService.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingService)).EndInit();
            this.bindingService.ResumeLayout(false);
            this.bindingService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.GroupBox groupService;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbPrice;
        private Bunifu.Framework.UI.BunifuThinButton2 btnServiceType;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddService;
        private System.Windows.Forms.Label label16;
        private MetroFramework.Controls.MetroComboBox comboBoxServiceType;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbName;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSearch;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbSreach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewService;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameServiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdNameServiceType;
        private System.Windows.Forms.BindingNavigator bindingService;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
    }
}