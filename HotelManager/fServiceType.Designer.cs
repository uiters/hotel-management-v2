namespace HotelManager
{
    partial class fServiceType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fServiceType));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txbSreach = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupServiceType = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnAddServiceType = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label16 = new System.Windows.Forms.Label();
            this.txbID = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewServiceType = new System.Windows.Forms.DataGridView();
            this.bindingServiceType = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupServiceType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingServiceType)).BeginInit();
            this.bindingServiceType.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(658, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 14);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 44;
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
            this.groupBox3.Size = new System.Drawing.Size(243, 172);
            this.groupBox3.TabIndex = 45;
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
            this.btnSearch.Location = new System.Drawing.Point(30, 103);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(198, 53);
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
            this.txbSreach.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSreach.ForeColor = System.Drawing.Color.SeaGreen;
            this.txbSreach.isPassword = false;
            this.txbSreach.Location = new System.Drawing.Point(26, 52);
            this.txbSreach.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txbSreach.Name = "txbSreach";
            this.txbSreach.Size = new System.Drawing.Size(199, 38);
            this.txbSreach.TabIndex = 27;
            this.txbSreach.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SeaGreen;
            this.label5.Location = new System.Drawing.Point(16, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "ID/Tên:";
            // 
            // groupServiceType
            // 
            this.groupServiceType.Controls.Add(this.label1);
            this.groupServiceType.Controls.Add(this.txbName);
            this.groupServiceType.Controls.Add(this.btnAddServiceType);
            this.groupServiceType.Controls.Add(this.label16);
            this.groupServiceType.Controls.Add(this.txbID);
            this.groupServiceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupServiceType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupServiceType.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupServiceType.Location = new System.Drawing.Point(12, 214);
            this.groupServiceType.Name = "groupServiceType";
            this.groupServiceType.Size = new System.Drawing.Size(244, 245);
            this.groupServiceType.TabIndex = 46;
            this.groupServiceType.TabStop = false;
            this.groupServiceType.Text = "Thêm Loại Dịch Vụ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(16, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tên loại dịch vụ";
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
            this.txbName.Location = new System.Drawing.Point(22, 133);
            this.txbName.Margin = new System.Windows.Forms.Padding(0);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(201, 38);
            this.txbName.TabIndex = 0;
            this.txbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnAddServiceType
            // 
            this.btnAddServiceType.ActiveBorderThickness = 1;
            this.btnAddServiceType.ActiveCornerRadius = 20;
            this.btnAddServiceType.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnAddServiceType.ActiveForecolor = System.Drawing.Color.White;
            this.btnAddServiceType.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddServiceType.BackColor = System.Drawing.Color.White;
            this.btnAddServiceType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddServiceType.BackgroundImage")));
            this.btnAddServiceType.ButtonText = "Thêm";
            this.btnAddServiceType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddServiceType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddServiceType.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAddServiceType.IdleBorderThickness = 1;
            this.btnAddServiceType.IdleCornerRadius = 15;
            this.btnAddServiceType.IdleFillColor = System.Drawing.Color.White;
            this.btnAddServiceType.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnAddServiceType.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddServiceType.Location = new System.Drawing.Point(22, 177);
            this.btnAddServiceType.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddServiceType.Name = "btnAddServiceType";
            this.btnAddServiceType.Size = new System.Drawing.Size(201, 55);
            this.btnAddServiceType.TabIndex = 8;
            this.btnAddServiceType.TabStop = false;
            this.btnAddServiceType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddServiceType.Click += new System.EventHandler(this.btnAddServiceType_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.SeaGreen;
            this.label16.Location = new System.Drawing.Point(16, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 17);
            this.label16.TabIndex = 22;
            this.label16.Text = "Mã loại dịch vụ";
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
            this.txbID.Location = new System.Drawing.Point(22, 61);
            this.txbID.Margin = new System.Windows.Forms.Padding(0);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(201, 38);
            this.txbID.TabIndex = 0;
            this.txbID.Text = "Tự Động";
            this.txbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewServiceType);
            this.groupBox1.Controls.Add(this.bindingServiceType);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox1.Location = new System.Drawing.Point(262, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 427);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Loại Dịch Vụ";
            // 
            // dataGridViewServiceType
            // 
            this.dataGridViewServiceType.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewServiceType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewServiceType.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewServiceType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServiceType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName});
            this.dataGridViewServiceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewServiceType.Location = new System.Drawing.Point(3, 46);
            this.dataGridViewServiceType.Name = "dataGridViewServiceType";
            this.dataGridViewServiceType.ReadOnly = true;
            this.dataGridViewServiceType.RowHeadersVisible = false;
            this.dataGridViewServiceType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServiceType.Size = new System.Drawing.Size(406, 378);
            this.dataGridViewServiceType.TabIndex = 28;
            this.dataGridViewServiceType.SelectionChanged += new System.EventHandler(this.dataGridViewServiceType_SelectionChanged);
            // 
            // bindingServiceType
            // 
            this.bindingServiceType.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingServiceType.CountItem = this.bindingNavigatorCountItem;
            this.bindingServiceType.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingServiceType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingServiceType.Location = new System.Drawing.Point(3, 21);
            this.bindingServiceType.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingServiceType.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingServiceType.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingServiceType.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingServiceType.Name = "bindingServiceType";
            this.bindingServiceType.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingServiceType.Size = new System.Drawing.Size(406, 25);
            this.bindingServiceType.TabIndex = 29;
            this.bindingServiceType.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(58, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colID.DataPropertyName = "id";
            this.colID.HeaderText = "Mã loại dịch vụ";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 122;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "name";
            this.colName.FillWeight = 90F;
            this.colName.HeaderText = "Tên loại dịch vụ";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // fServiceType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(686, 470);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupServiceType);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SeaGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fServiceType";
            this.Text = "fServiceType";
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupServiceType.ResumeLayout(false);
            this.groupServiceType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingServiceType)).EndInit();
            this.bindingServiceType.ResumeLayout(false);
            this.bindingServiceType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSearch;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbSreach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupServiceType;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbName;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddServiceType;
        private System.Windows.Forms.Label label16;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewServiceType;
        private System.Windows.Forms.BindingNavigator bindingServiceType;
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
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    }
}