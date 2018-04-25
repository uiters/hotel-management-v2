namespace HotelManager
{
    partial class fAddCustomerInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAddCustomerInfo));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxCustomerType = new MetroFramework.Controls.MetroComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txbAddress = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxSex = new MetroFramework.Controls.MetroComboBox();
            this.txbNationality = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txbPhoneNumber = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label14 = new System.Windows.Forms.Label();
            this.txbIDCard = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label15 = new System.Windows.Forms.Label();
            this.txbFullName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnAddCustomer = new Bunifu.Framework.UI.BunifuThinButton2();
            this.dpkDateOfBirth = new Bunifu.Framework.UI.BunifuDatepicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dpkDateOfBirth);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxCustomerType);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txbAddress);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.comboBoxSex);
            this.groupBox2.Controls.Add(this.txbNationality);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txbPhoneNumber);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txbIDCard);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txbFullName);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox2.Location = new System.Drawing.Point(21, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 465);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng";
            // 
            // comboBoxCustomerType
            // 
            this.comboBoxCustomerType.BackColor = System.Drawing.Color.White;
            this.comboBoxCustomerType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCustomerType.FormattingEnabled = true;
            this.comboBoxCustomerType.ItemHeight = 23;
            this.comboBoxCustomerType.Location = new System.Drawing.Point(28, 155);
            this.comboBoxCustomerType.Name = "comboBoxCustomerType";
            this.comboBoxCustomerType.Size = new System.Drawing.Size(203, 29);
            this.comboBoxCustomerType.TabIndex = 42;
            this.comboBoxCustomerType.UseCustomBackColor = true;
            this.comboBoxCustomerType.UseCustomForeColor = true;
            this.comboBoxCustomerType.UseSelectable = true;
            this.comboBoxCustomerType.UseStyleColors = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.SeaGreen;
            this.label20.Location = new System.Drawing.Point(24, 131);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(119, 20);
            this.label20.TabIndex = 41;
            this.label20.Text = "Loại khách hàng:";
            // 
            // txbAddress
            // 
            this.txbAddress.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbAddress.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbAddress.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbAddress.BorderThickness = 1;
            this.txbAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbAddress.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbAddress.isPassword = false;
            this.txbAddress.Location = new System.Drawing.Point(28, 311);
            this.txbAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(203, 29);
            this.txbAddress.TabIndex = 25;
            this.txbAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.SeaGreen;
            this.label11.Location = new System.Drawing.Point(22, 291);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "Địa chỉ:";
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.BackColor = System.Drawing.Color.White;
            this.comboBoxSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.ItemHeight = 23;
            this.comboBoxSex.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.comboBoxSex.Location = new System.Drawing.Point(28, 362);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(203, 29);
            this.comboBoxSex.TabIndex = 26;
            this.comboBoxSex.UseCustomBackColor = true;
            this.comboBoxSex.UseCustomForeColor = true;
            this.comboBoxSex.UseSelectable = true;
            this.comboBoxSex.UseStyleColors = true;
            // 
            // txbNationality
            // 
            this.txbNationality.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbNationality.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbNationality.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbNationality.BorderThickness = 1;
            this.txbNationality.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbNationality.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbNationality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbNationality.isPassword = false;
            this.txbNationality.Location = new System.Drawing.Point(28, 417);
            this.txbNationality.Margin = new System.Windows.Forms.Padding(4);
            this.txbNationality.Name = "txbNationality";
            this.txbNationality.Size = new System.Drawing.Size(203, 29);
            this.txbNationality.TabIndex = 27;
            this.txbNationality.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SeaGreen;
            this.label12.Location = new System.Drawing.Point(24, 392);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 20);
            this.label12.TabIndex = 29;
            this.label12.Text = "Quốc tịch:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.SeaGreen;
            this.label13.Location = new System.Drawing.Point(24, 341);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Giới tính:";
            // 
            // txbPhoneNumber
            // 
            this.txbPhoneNumber.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbPhoneNumber.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbPhoneNumber.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbPhoneNumber.BorderThickness = 1;
            this.txbPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbPhoneNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbPhoneNumber.isPassword = false;
            this.txbPhoneNumber.Location = new System.Drawing.Point(26, 207);
            this.txbPhoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txbPhoneNumber.Name = "txbPhoneNumber";
            this.txbPhoneNumber.Size = new System.Drawing.Size(203, 29);
            this.txbPhoneNumber.TabIndex = 24;
            this.txbPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.SeaGreen;
            this.label14.Location = new System.Drawing.Point(24, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = "Số điện thoại:";
            // 
            // txbIDCard
            // 
            this.txbIDCard.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbIDCard.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbIDCard.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbIDCard.BorderThickness = 1;
            this.txbIDCard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbIDCard.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbIDCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbIDCard.isPassword = false;
            this.txbIDCard.Location = new System.Drawing.Point(26, 99);
            this.txbIDCard.Margin = new System.Windows.Forms.Padding(4);
            this.txbIDCard.Name = "txbIDCard";
            this.txbIDCard.Size = new System.Drawing.Size(203, 29);
            this.txbIDCard.TabIndex = 22;
            this.txbIDCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.SeaGreen;
            this.label15.Location = new System.Drawing.Point(24, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(153, 20);
            this.label15.TabIndex = 24;
            this.label15.Text = "Thẻ căn cước/ CMND:";
            // 
            // txbFullName
            // 
            this.txbFullName.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.txbFullName.BorderColorIdle = System.Drawing.Color.SeaGreen;
            this.txbFullName.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.txbFullName.BorderThickness = 1;
            this.txbFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbFullName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txbFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbFullName.isPassword = false;
            this.txbFullName.Location = new System.Drawing.Point(26, 46);
            this.txbFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txbFullName.Name = "txbFullName";
            this.txbFullName.Size = new System.Drawing.Size(203, 29);
            this.txbFullName.TabIndex = 21;
            this.txbFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.SeaGreen;
            this.label16.Location = new System.Drawing.Point(24, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 20);
            this.label16.TabIndex = 22;
            this.label16.Text = "Họ và tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 37);
            this.label2.TabIndex = 27;
            this.label2.Text = "Thêm Khách Hàng";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(21, 47);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(254, 10);
            this.bunifuSeparator1.TabIndex = 30;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(275, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 31;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.ActiveBorderThickness = 1;
            this.btnAddCustomer.ActiveCornerRadius = 20;
            this.btnAddCustomer.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnAddCustomer.ActiveForecolor = System.Drawing.Color.White;
            this.btnAddCustomer.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddCustomer.BackColor = System.Drawing.Color.White;
            this.btnAddCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCustomer.BackgroundImage")));
            this.btnAddCustomer.ButtonText = "Thêm Khách Hàng";
            this.btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAddCustomer.IdleBorderThickness = 1;
            this.btnAddCustomer.IdleCornerRadius = 20;
            this.btnAddCustomer.IdleFillColor = System.Drawing.Color.White;
            this.btnAddCustomer.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnAddCustomer.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddCustomer.Location = new System.Drawing.Point(47, 532);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(203, 40);
            this.btnAddCustomer.TabIndex = 48;
            this.btnAddCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // dpkDateOfBirth
            // 
            this.dpkDateOfBirth.BackColor = System.Drawing.Color.SeaGreen;
            this.dpkDateOfBirth.BorderRadius = 0;
            this.dpkDateOfBirth.ForeColor = System.Drawing.Color.White;
            this.dpkDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkDateOfBirth.FormatCustom = null;
            this.dpkDateOfBirth.Location = new System.Drawing.Point(26, 262);
            this.dpkDateOfBirth.Margin = new System.Windows.Forms.Padding(32, 55, 32, 55);
            this.dpkDateOfBirth.Name = "dpkDateOfBirth";
            this.dpkDateOfBirth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dpkDateOfBirth.Size = new System.Drawing.Size(203, 29);
            this.dpkDateOfBirth.TabIndex = 50;
            this.dpkDateOfBirth.Value = new System.DateTime(2018, 2, 23, 23, 29, 57, 962);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(24, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "Ngày sinh:";
            // 
            // fAddCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(296, 578);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fAddCustomerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fAddCustomerInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fAddCustomerInfo_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroComboBox comboBoxCustomerType;
        private System.Windows.Forms.Label label20;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbAddress;
        private System.Windows.Forms.Label label11;
        private MetroFramework.Controls.MetroComboBox comboBoxSex;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbNationality;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbPhoneNumber;
        private System.Windows.Forms.Label label14;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbIDCard;
        private System.Windows.Forms.Label label15;
        private Bunifu.Framework.UI.BunifuMetroTextbox txbFullName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddCustomer;
        private Bunifu.Framework.UI.BunifuDatepicker dpkDateOfBirth;
        private System.Windows.Forms.Label label1;
    }
}