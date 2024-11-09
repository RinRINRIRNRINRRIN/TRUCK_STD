
namespace TRUCK_STD.Design
{
    partial class frmWeightHire
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation2 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeightHire));
            this.gbMain = new Guna.UI2.WinForms.Guna2GroupBox();
            this.gbProduct = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvProduct = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCustomer = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnClose1 = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCustomer = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchCustomer = new Guna.UI2.WinForms.Guna2TextBox();
            this.gbWeightIN = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnCancelWeighIN = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnSaveWeightIN = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnSearchProduct = new Bunifu.UI.WinForms.BunifuImageButton();
            this.btnSearchCustomer = new Bunifu.UI.WinForms.BunifuImageButton();
            this.txtPrdName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPrdCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCusName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCusID = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbIndicator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.txtCarRegistration = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.bunifuTransition1 = new Bunifu.UI.WinForms.BunifuTransition(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tmStableWeight = new System.Windows.Forms.Timer(this.components);
            this.gbMain.SuspendLayout();
            this.gbProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.gbCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.gbWeightIN.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.BorderColor = System.Drawing.Color.Navy;
            this.gbMain.BorderRadius = 8;
            this.gbMain.BorderThickness = 2;
            this.gbMain.Controls.Add(this.gbProduct);
            this.gbMain.Controls.Add(this.gbCustomer);
            this.gbMain.Controls.Add(this.gbWeightIN);
            this.gbMain.Controls.Add(this.panel2);
            this.gbMain.Controls.Add(this.guna2ControlBox1);
            this.gbMain.Controls.Add(this.txtCarRegistration);
            this.gbMain.CustomBorderColor = System.Drawing.Color.Navy;
            this.bunifuTransition1.SetDecoration(this.gbMain, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMain.ForeColor = System.Drawing.Color.White;
            this.gbMain.Location = new System.Drawing.Point(0, 0);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(1354, 523);
            this.gbMain.TabIndex = 4;
            this.gbMain.Text = "จ้างชั่ง";
            this.gbMain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbProduct
            // 
            this.gbProduct.BorderColor = System.Drawing.Color.Teal;
            this.gbProduct.BorderRadius = 8;
            this.gbProduct.Controls.Add(this.btnClose);
            this.gbProduct.Controls.Add(this.pictureBox1);
            this.gbProduct.Controls.Add(this.label2);
            this.gbProduct.Controls.Add(this.txtSearchProduct);
            this.gbProduct.Controls.Add(this.dgvProduct);
            this.gbProduct.CustomBorderColor = System.Drawing.Color.Teal;
            this.bunifuTransition1.SetDecoration(this.gbProduct, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.gbProduct.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProduct.ForeColor = System.Drawing.Color.White;
            this.gbProduct.Location = new System.Drawing.Point(751, 52);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Size = new System.Drawing.Size(291, 463);
            this.gbProduct.TabIndex = 19;
            this.gbProduct.Text = "ข้อมูล สินค้า";
            this.gbProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClose
            // 
            this.bunifuTransition1.SetDecoration(this.btnClose, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Teal;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(250, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 36);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.bunifuTransition1.SetDecoration(this.pictureBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(248, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.bunifuTransition1.SetDecoration(this.label2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Athiti Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 30);
            this.label2.TabIndex = 26;
            this.label2.Text = "เลือกรายการสินค้าที่ต้องการแล้วกดที่รูป";
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Animated = true;
            this.txtSearchProduct.BorderColor = System.Drawing.Color.Black;
            this.txtSearchProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtSearchProduct, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.txtSearchProduct.DefaultText = "";
            this.txtSearchProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchProduct.ForeColor = System.Drawing.Color.Black;
            this.txtSearchProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.IconRight = ((System.Drawing.Image)(resources.GetObject("txtSearchProduct.IconRight")));
            this.txtSearchProduct.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.txtSearchProduct.Location = new System.Drawing.Point(6, 44);
            this.txtSearchProduct.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PasswordChar = '\0';
            this.txtSearchProduct.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtSearchProduct.PlaceholderText = "ค้นหา รหัสสินค้า";
            this.txtSearchProduct.SelectedText = "";
            this.txtSearchProduct.Size = new System.Drawing.Size(275, 32);
            this.txtSearchProduct.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtSearchProduct.TabIndex = 18;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProduct.ColumnHeadersHeight = 30;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column15});
            this.bunifuTransition1.SetDecoration(this.dgvProduct, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProduct.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProduct.Location = new System.Drawing.Point(6, 114);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.Size = new System.Drawing.Size(275, 342);
            this.dgvProduct.TabIndex = 24;
            this.dgvProduct.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProduct.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvProduct.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvProduct.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvProduct.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvProduct.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvProduct.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProduct.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvProduct.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvProduct.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProduct.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProduct.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProduct.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvProduct.ThemeStyle.ReadOnly = true;
            this.dgvProduct.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProduct.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProduct.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProduct.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProduct.ThemeStyle.RowsStyle.Height = 22;
            this.dgvProduct.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProduct.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellContentClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "";
            this.Column8.Image = ((System.Drawing.Image)(resources.GetObject("Column8.Image")));
            this.Column8.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TYPECODE";
            this.dataGridViewTextBoxColumn1.HeaderText = "รหัสสินค้า";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 110;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TYPEDESC";
            this.dataGridViewTextBoxColumn2.HeaderText = "ชื่อสินค้า";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "TYPEPRICE";
            this.Column15.HeaderText = "ราคา";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // gbCustomer
            // 
            this.gbCustomer.BorderColor = System.Drawing.Color.Olive;
            this.gbCustomer.BorderRadius = 8;
            this.gbCustomer.Controls.Add(this.btnClose1);
            this.gbCustomer.Controls.Add(this.pictureBox2);
            this.gbCustomer.Controls.Add(this.label3);
            this.gbCustomer.Controls.Add(this.dgvCustomer);
            this.gbCustomer.Controls.Add(this.txtSearchCustomer);
            this.gbCustomer.CustomBorderColor = System.Drawing.Color.Olive;
            this.bunifuTransition1.SetDecoration(this.gbCustomer, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.gbCustomer.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCustomer.ForeColor = System.Drawing.Color.White;
            this.gbCustomer.Location = new System.Drawing.Point(1048, 52);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(291, 463);
            this.gbCustomer.TabIndex = 28;
            this.gbCustomer.Text = "ข้อมูล ลูกค้า";
            this.gbCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClose1
            // 
            this.bunifuTransition1.SetDecoration(this.btnClose1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnClose1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose1.FillColor = System.Drawing.Color.Olive;
            this.btnClose1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose1.ForeColor = System.Drawing.Color.White;
            this.btnClose1.Location = new System.Drawing.Point(249, 3);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(33, 36);
            this.btnClose1.TabIndex = 29;
            this.btnClose1.Text = "X";
            this.btnClose1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox2
            // 
            this.bunifuTransition1.SetDecoration(this.pictureBox2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(248, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.bunifuTransition1.SetDecoration(this.label3, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Athiti Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 30);
            this.label3.TabIndex = 26;
            this.label3.Text = "เลือกรายการลูกค้าที่ต้องการแล้วกดที่รูป";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvCustomer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Olive;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Olive;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCustomer.ColumnHeadersHeight = 30;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.bunifuTransition1.SetDecoration(this.dgvCustomer, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomer.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvCustomer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomer.Location = new System.Drawing.Point(6, 116);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.ReadOnly = true;
            this.dgvCustomer.RowHeadersVisible = false;
            this.dgvCustomer.Size = new System.Drawing.Size(275, 344);
            this.dgvCustomer.TabIndex = 25;
            this.dgvCustomer.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomer.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCustomer.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCustomer.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCustomer.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCustomer.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomer.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomer.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCustomer.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvCustomer.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomer.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCustomer.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomer.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvCustomer.ThemeStyle.ReadOnly = true;
            this.dgvCustomer.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomer.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomer.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomer.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCustomer.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCustomer.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomer.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellContentClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "COMPCODE";
            this.dataGridViewTextBoxColumn3.HeaderText = "รหัสลูกค้า";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "COMPDESC";
            this.dataGridViewTextBoxColumn4.HeaderText = "ชื่อลูกค้า";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Animated = true;
            this.txtSearchCustomer.BorderColor = System.Drawing.Color.Black;
            this.txtSearchCustomer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtSearchCustomer, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.txtSearchCustomer.DefaultText = "";
            this.txtSearchCustomer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchCustomer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchCustomer.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCustomer.ForeColor = System.Drawing.Color.Black;
            this.txtSearchCustomer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchCustomer.IconRight = ((System.Drawing.Image)(resources.GetObject("txtSearchCustomer.IconRight")));
            this.txtSearchCustomer.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.txtSearchCustomer.Location = new System.Drawing.Point(6, 44);
            this.txtSearchCustomer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.PasswordChar = '\0';
            this.txtSearchCustomer.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtSearchCustomer.PlaceholderText = "ค้นหา รหัสลูกค้า";
            this.txtSearchCustomer.SelectedText = "";
            this.txtSearchCustomer.Size = new System.Drawing.Size(275, 32);
            this.txtSearchCustomer.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtSearchCustomer.TabIndex = 18;
            // 
            // gbWeightIN
            // 
            this.gbWeightIN.BorderColor = System.Drawing.Color.Navy;
            this.gbWeightIN.BorderRadius = 8;
            this.gbWeightIN.Controls.Add(this.btnCancelWeighIN);
            this.gbWeightIN.Controls.Add(this.btnSaveWeightIN);
            this.gbWeightIN.Controls.Add(this.btnSearchProduct);
            this.gbWeightIN.Controls.Add(this.btnSearchCustomer);
            this.gbWeightIN.Controls.Add(this.txtPrdName);
            this.gbWeightIN.Controls.Add(this.txtPrdCode);
            this.gbWeightIN.Controls.Add(this.txtCusName);
            this.gbWeightIN.Controls.Add(this.txtCusID);
            this.gbWeightIN.CustomBorderColor = System.Drawing.Color.Navy;
            this.bunifuTransition1.SetDecoration(this.gbWeightIN, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.gbWeightIN.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbWeightIN.ForeColor = System.Drawing.Color.White;
            this.gbWeightIN.Location = new System.Drawing.Point(76, 350);
            this.gbWeightIN.Name = "gbWeightIN";
            this.gbWeightIN.Size = new System.Drawing.Size(562, 176);
            this.gbWeightIN.TabIndex = 12;
            this.gbWeightIN.Text = "ข้อมูลรถจ้างชั่ง";
            this.gbWeightIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCancelWeighIN
            // 
            this.btnCancelWeighIN.AllowAnimations = true;
            this.btnCancelWeighIN.AllowMouseEffects = true;
            this.btnCancelWeighIN.AllowToggling = false;
            this.btnCancelWeighIN.AnimationSpeed = 200;
            this.btnCancelWeighIN.AutoGenerateColors = false;
            this.btnCancelWeighIN.AutoRoundBorders = false;
            this.btnCancelWeighIN.AutoSizeLeftIcon = true;
            this.btnCancelWeighIN.AutoSizeRightIcon = true;
            this.btnCancelWeighIN.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelWeighIN.BackColor1 = System.Drawing.Color.White;
            this.btnCancelWeighIN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelWeighIN.BackgroundImage")));
            this.btnCancelWeighIN.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancelWeighIN.ButtonText = "ยกเลิก";
            this.btnCancelWeighIN.ButtonTextMarginLeft = 0;
            this.btnCancelWeighIN.ColorContrastOnClick = 45;
            this.btnCancelWeighIN.ColorContrastOnHover = 45;
            this.btnCancelWeighIN.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnCancelWeighIN.CustomizableEdges = borderEdges3;
            this.bunifuTransition1.SetDecoration(this.btnCancelWeighIN, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnCancelWeighIN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancelWeighIN.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCancelWeighIN.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancelWeighIN.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCancelWeighIN.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnCancelWeighIN.Font = new System.Drawing.Font("Athiti", 12F);
            this.btnCancelWeighIN.ForeColor = System.Drawing.Color.Red;
            this.btnCancelWeighIN.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelWeighIN.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnCancelWeighIN.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnCancelWeighIN.IconMarginLeft = 11;
            this.btnCancelWeighIN.IconPadding = 10;
            this.btnCancelWeighIN.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelWeighIN.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnCancelWeighIN.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnCancelWeighIN.IconSize = 25;
            this.btnCancelWeighIN.IdleBorderColor = System.Drawing.Color.Red;
            this.btnCancelWeighIN.IdleBorderRadius = 6;
            this.btnCancelWeighIN.IdleBorderThickness = 1;
            this.btnCancelWeighIN.IdleFillColor = System.Drawing.Color.White;
            this.btnCancelWeighIN.IdleIconLeftImage = null;
            this.btnCancelWeighIN.IdleIconRightImage = null;
            this.btnCancelWeighIN.IndicateFocus = false;
            this.btnCancelWeighIN.Location = new System.Drawing.Point(12, 133);
            this.btnCancelWeighIN.Name = "btnCancelWeighIN";
            this.btnCancelWeighIN.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCancelWeighIN.OnDisabledState.BorderRadius = 6;
            this.btnCancelWeighIN.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancelWeighIN.OnDisabledState.BorderThickness = 1;
            this.btnCancelWeighIN.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancelWeighIN.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCancelWeighIN.OnDisabledState.IconLeftImage = null;
            this.btnCancelWeighIN.OnDisabledState.IconRightImage = null;
            this.btnCancelWeighIN.onHoverState.BorderColor = System.Drawing.Color.Red;
            this.btnCancelWeighIN.onHoverState.BorderRadius = 6;
            this.btnCancelWeighIN.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancelWeighIN.onHoverState.BorderThickness = 1;
            this.btnCancelWeighIN.onHoverState.FillColor = System.Drawing.Color.Red;
            this.btnCancelWeighIN.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnCancelWeighIN.onHoverState.IconLeftImage = null;
            this.btnCancelWeighIN.onHoverState.IconRightImage = null;
            this.btnCancelWeighIN.OnIdleState.BorderColor = System.Drawing.Color.Red;
            this.btnCancelWeighIN.OnIdleState.BorderRadius = 6;
            this.btnCancelWeighIN.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancelWeighIN.OnIdleState.BorderThickness = 1;
            this.btnCancelWeighIN.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnCancelWeighIN.OnIdleState.ForeColor = System.Drawing.Color.Red;
            this.btnCancelWeighIN.OnIdleState.IconLeftImage = null;
            this.btnCancelWeighIN.OnIdleState.IconRightImage = null;
            this.btnCancelWeighIN.OnPressedState.BorderColor = System.Drawing.Color.Red;
            this.btnCancelWeighIN.OnPressedState.BorderRadius = 6;
            this.btnCancelWeighIN.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancelWeighIN.OnPressedState.BorderThickness = 1;
            this.btnCancelWeighIN.OnPressedState.FillColor = System.Drawing.Color.White;
            this.btnCancelWeighIN.OnPressedState.ForeColor = System.Drawing.Color.Red;
            this.btnCancelWeighIN.OnPressedState.IconLeftImage = null;
            this.btnCancelWeighIN.OnPressedState.IconRightImage = null;
            this.btnCancelWeighIN.Size = new System.Drawing.Size(229, 32);
            this.btnCancelWeighIN.TabIndex = 17;
            this.btnCancelWeighIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelWeighIN.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCancelWeighIN.TextMarginLeft = 0;
            this.btnCancelWeighIN.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancelWeighIN.UseDefaultRadiusAndThickness = true;
            this.btnCancelWeighIN.Click += new System.EventHandler(this.btnCancelWeighIN_Click);
            // 
            // btnSaveWeightIN
            // 
            this.btnSaveWeightIN.AllowAnimations = true;
            this.btnSaveWeightIN.AllowMouseEffects = true;
            this.btnSaveWeightIN.AllowToggling = false;
            this.btnSaveWeightIN.AnimationSpeed = 200;
            this.btnSaveWeightIN.AutoGenerateColors = false;
            this.btnSaveWeightIN.AutoRoundBorders = false;
            this.btnSaveWeightIN.AutoSizeLeftIcon = true;
            this.btnSaveWeightIN.AutoSizeRightIcon = true;
            this.btnSaveWeightIN.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveWeightIN.BackColor1 = System.Drawing.Color.White;
            this.btnSaveWeightIN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveWeightIN.BackgroundImage")));
            this.btnSaveWeightIN.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveWeightIN.ButtonText = "บันทึก";
            this.btnSaveWeightIN.ButtonTextMarginLeft = 0;
            this.btnSaveWeightIN.ColorContrastOnClick = 45;
            this.btnSaveWeightIN.ColorContrastOnHover = 45;
            this.btnSaveWeightIN.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.btnSaveWeightIN.CustomizableEdges = borderEdges4;
            this.bunifuTransition1.SetDecoration(this.btnSaveWeightIN, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnSaveWeightIN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveWeightIN.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSaveWeightIN.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSaveWeightIN.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSaveWeightIN.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSaveWeightIN.Font = new System.Drawing.Font("Athiti", 12F);
            this.btnSaveWeightIN.ForeColor = System.Drawing.Color.Green;
            this.btnSaveWeightIN.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveWeightIN.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveWeightIN.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSaveWeightIN.IconMarginLeft = 11;
            this.btnSaveWeightIN.IconPadding = 10;
            this.btnSaveWeightIN.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveWeightIN.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveWeightIN.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSaveWeightIN.IconSize = 25;
            this.btnSaveWeightIN.IdleBorderColor = System.Drawing.Color.Green;
            this.btnSaveWeightIN.IdleBorderRadius = 6;
            this.btnSaveWeightIN.IdleBorderThickness = 1;
            this.btnSaveWeightIN.IdleFillColor = System.Drawing.Color.White;
            this.btnSaveWeightIN.IdleIconLeftImage = null;
            this.btnSaveWeightIN.IdleIconRightImage = null;
            this.btnSaveWeightIN.IndicateFocus = false;
            this.btnSaveWeightIN.Location = new System.Drawing.Point(247, 133);
            this.btnSaveWeightIN.Name = "btnSaveWeightIN";
            this.btnSaveWeightIN.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSaveWeightIN.OnDisabledState.BorderRadius = 6;
            this.btnSaveWeightIN.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveWeightIN.OnDisabledState.BorderThickness = 1;
            this.btnSaveWeightIN.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSaveWeightIN.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSaveWeightIN.OnDisabledState.IconLeftImage = null;
            this.btnSaveWeightIN.OnDisabledState.IconRightImage = null;
            this.btnSaveWeightIN.onHoverState.BorderColor = System.Drawing.Color.Green;
            this.btnSaveWeightIN.onHoverState.BorderRadius = 6;
            this.btnSaveWeightIN.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveWeightIN.onHoverState.BorderThickness = 1;
            this.btnSaveWeightIN.onHoverState.FillColor = System.Drawing.Color.Green;
            this.btnSaveWeightIN.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSaveWeightIN.onHoverState.IconLeftImage = null;
            this.btnSaveWeightIN.onHoverState.IconRightImage = null;
            this.btnSaveWeightIN.OnIdleState.BorderColor = System.Drawing.Color.Green;
            this.btnSaveWeightIN.OnIdleState.BorderRadius = 6;
            this.btnSaveWeightIN.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveWeightIN.OnIdleState.BorderThickness = 1;
            this.btnSaveWeightIN.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnSaveWeightIN.OnIdleState.ForeColor = System.Drawing.Color.Green;
            this.btnSaveWeightIN.OnIdleState.IconLeftImage = null;
            this.btnSaveWeightIN.OnIdleState.IconRightImage = null;
            this.btnSaveWeightIN.OnPressedState.BorderColor = System.Drawing.Color.Green;
            this.btnSaveWeightIN.OnPressedState.BorderRadius = 6;
            this.btnSaveWeightIN.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSaveWeightIN.OnPressedState.BorderThickness = 1;
            this.btnSaveWeightIN.OnPressedState.FillColor = System.Drawing.Color.White;
            this.btnSaveWeightIN.OnPressedState.ForeColor = System.Drawing.Color.Green;
            this.btnSaveWeightIN.OnPressedState.IconLeftImage = null;
            this.btnSaveWeightIN.OnPressedState.IconRightImage = null;
            this.btnSaveWeightIN.Size = new System.Drawing.Size(261, 32);
            this.btnSaveWeightIN.TabIndex = 16;
            this.btnSaveWeightIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveWeightIN.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSaveWeightIN.TextMarginLeft = 0;
            this.btnSaveWeightIN.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSaveWeightIN.UseDefaultRadiusAndThickness = true;
            this.btnSaveWeightIN.Click += new System.EventHandler(this.btnSaveWeightIN_Click);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.ActiveImage = null;
            this.btnSearchProduct.AllowAnimations = true;
            this.btnSearchProduct.AllowBuffering = false;
            this.btnSearchProduct.AllowToggling = false;
            this.btnSearchProduct.AllowZooming = true;
            this.btnSearchProduct.AllowZoomingOnFocus = false;
            this.btnSearchProduct.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.btnSearchProduct, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnSearchProduct.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSearchProduct.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnSearchProduct.ErrorImage")));
            this.btnSearchProduct.FadeWhenInactive = false;
            this.btnSearchProduct.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnSearchProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchProduct.Image")));
            this.btnSearchProduct.ImageActive = null;
            this.btnSearchProduct.ImageLocation = null;
            this.btnSearchProduct.ImageMargin = 15;
            this.btnSearchProduct.ImageSize = new System.Drawing.Size(20, 17);
            this.btnSearchProduct.ImageZoomSize = new System.Drawing.Size(35, 32);
            this.btnSearchProduct.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnSearchProduct.InitialImage")));
            this.btnSearchProduct.Location = new System.Drawing.Point(514, 91);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Rotation = 0;
            this.btnSearchProduct.ShowActiveImage = true;
            this.btnSearchProduct.ShowCursorChanges = true;
            this.btnSearchProduct.ShowImageBorders = true;
            this.btnSearchProduct.ShowSizeMarkers = false;
            this.btnSearchProduct.Size = new System.Drawing.Size(35, 32);
            this.btnSearchProduct.TabIndex = 5;
            this.btnSearchProduct.ToolTipText = "";
            this.btnSearchProduct.WaitOnLoad = false;
            this.btnSearchProduct.Zoom = 15;
            this.btnSearchProduct.ZoomSpeed = 10;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.ActiveImage = null;
            this.btnSearchCustomer.AllowAnimations = true;
            this.btnSearchCustomer.AllowBuffering = false;
            this.btnSearchCustomer.AllowToggling = false;
            this.btnSearchCustomer.AllowZooming = true;
            this.btnSearchCustomer.AllowZoomingOnFocus = false;
            this.btnSearchCustomer.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.btnSearchCustomer, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnSearchCustomer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSearchCustomer.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnSearchCustomer.ErrorImage")));
            this.btnSearchCustomer.FadeWhenInactive = false;
            this.btnSearchCustomer.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnSearchCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCustomer.Image")));
            this.btnSearchCustomer.ImageActive = null;
            this.btnSearchCustomer.ImageLocation = null;
            this.btnSearchCustomer.ImageMargin = 15;
            this.btnSearchCustomer.ImageSize = new System.Drawing.Size(20, 17);
            this.btnSearchCustomer.ImageZoomSize = new System.Drawing.Size(35, 32);
            this.btnSearchCustomer.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnSearchCustomer.InitialImage")));
            this.btnSearchCustomer.Location = new System.Drawing.Point(514, 49);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Rotation = 0;
            this.btnSearchCustomer.ShowActiveImage = true;
            this.btnSearchCustomer.ShowCursorChanges = true;
            this.btnSearchCustomer.ShowImageBorders = true;
            this.btnSearchCustomer.ShowSizeMarkers = false;
            this.btnSearchCustomer.Size = new System.Drawing.Size(35, 32);
            this.btnSearchCustomer.TabIndex = 4;
            this.btnSearchCustomer.ToolTipText = "";
            this.btnSearchCustomer.WaitOnLoad = false;
            this.btnSearchCustomer.Zoom = 15;
            this.btnSearchCustomer.ZoomSpeed = 10;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // txtPrdName
            // 
            this.txtPrdName.Animated = true;
            this.txtPrdName.BorderColor = System.Drawing.Color.Black;
            this.txtPrdName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtPrdName, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.txtPrdName.DefaultText = "";
            this.txtPrdName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrdName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrdName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrdName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrdName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrdName.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrdName.ForeColor = System.Drawing.Color.Black;
            this.txtPrdName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrdName.Location = new System.Drawing.Point(247, 91);
            this.txtPrdName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.PasswordChar = '\0';
            this.txtPrdName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPrdName.PlaceholderText = "ชื่อสินค้า";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.SelectedText = "";
            this.txtPrdName.Size = new System.Drawing.Size(261, 32);
            this.txtPrdName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtPrdName.TabIndex = 3;
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Animated = true;
            this.txtPrdCode.BorderColor = System.Drawing.Color.Black;
            this.txtPrdCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtPrdCode, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.txtPrdCode.DefaultText = "";
            this.txtPrdCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrdCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrdCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrdCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrdCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrdCode.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrdCode.ForeColor = System.Drawing.Color.Black;
            this.txtPrdCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrdCode.Location = new System.Drawing.Point(12, 91);
            this.txtPrdCode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.PasswordChar = '\0';
            this.txtPrdCode.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPrdCode.PlaceholderText = "รหัสสินค้า";
            this.txtPrdCode.ReadOnly = true;
            this.txtPrdCode.SelectedText = "";
            this.txtPrdCode.Size = new System.Drawing.Size(229, 32);
            this.txtPrdCode.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtPrdCode.TabIndex = 2;
            // 
            // txtCusName
            // 
            this.txtCusName.Animated = true;
            this.txtCusName.BorderColor = System.Drawing.Color.Black;
            this.txtCusName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtCusName, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.txtCusName.DefaultText = "";
            this.txtCusName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCusName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCusName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusName.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusName.ForeColor = System.Drawing.Color.Black;
            this.txtCusName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusName.Location = new System.Drawing.Point(247, 49);
            this.txtCusName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.PasswordChar = '\0';
            this.txtCusName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtCusName.PlaceholderText = "ชื่อลูกค้า หรือ ชื่อบริษัท";
            this.txtCusName.ReadOnly = true;
            this.txtCusName.SelectedText = "";
            this.txtCusName.Size = new System.Drawing.Size(261, 32);
            this.txtCusName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtCusName.TabIndex = 1;
            // 
            // txtCusID
            // 
            this.txtCusID.Animated = true;
            this.txtCusID.BorderColor = System.Drawing.Color.Black;
            this.txtCusID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtCusID, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.txtCusID.DefaultText = "";
            this.txtCusID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCusID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCusID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCusID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusID.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusID.ForeColor = System.Drawing.Color.Black;
            this.txtCusID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCusID.Location = new System.Drawing.Point(12, 49);
            this.txtCusID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCusID.Name = "txtCusID";
            this.txtCusID.PasswordChar = '\0';
            this.txtCusID.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtCusID.PlaceholderText = "รหัสลูกค้า หรือ รหัสบริษัท";
            this.txtCusID.ReadOnly = true;
            this.txtCusID.SelectedText = "";
            this.txtCusID.Size = new System.Drawing.Size(229, 32);
            this.txtCusID.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtCusID.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbIndicator);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label4);
            this.bunifuTransition1.SetDecoration(this.panel2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.panel2.Location = new System.Drawing.Point(12, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 217);
            this.panel2.TabIndex = 11;
            // 
            // lbIndicator
            // 
            this.lbIndicator.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.lbIndicator, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lbIndicator.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIndicator.ForeColor = System.Drawing.Color.DimGray;
            this.lbIndicator.Location = new System.Drawing.Point(6, 187);
            this.lbIndicator.Name = "lbIndicator";
            this.lbIndicator.Size = new System.Drawing.Size(87, 25);
            this.lbIndicator.TabIndex = 13;
            this.lbIndicator.Text = "เครื่องชั่ง : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.bunifuTransition1.SetDecoration(this.label1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Athiti SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 43);
            this.label1.TabIndex = 12;
            this.label1.Text = "น้ำหนักรถ บรรทุก";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.bunifuTransition1.SetDecoration(this.label11, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.label11.Font = new System.Drawing.Font("Athiti", 71.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(510, 50);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(189, 158);
            this.label11.TabIndex = 11;
            this.label11.Text = "KG";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuTransition1.SetDecoration(this.label4, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Athiti", 86.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(717, 217);
            this.label4.TabIndex = 9;
            this.label4.Text = "ERROR";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Navy;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.White;
            this.guna2ControlBox1.BorderRadius = 6;
            this.guna2ControlBox1.BorderThickness = 1;
            this.bunifuTransition1.SetDecoration(this.guna2ControlBox1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1308, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(34, 32);
            this.guna2ControlBox1.TabIndex = 8;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // txtCarRegistration
            // 
            this.txtCarRegistration.Animated = true;
            this.txtCarRegistration.BorderColor = System.Drawing.Color.Black;
            this.txtCarRegistration.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txtCarRegistration, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.txtCarRegistration.DefaultText = "";
            this.txtCarRegistration.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCarRegistration.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCarRegistration.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCarRegistration.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCarRegistration.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCarRegistration.Font = new System.Drawing.Font("Athiti", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarRegistration.ForeColor = System.Drawing.Color.Black;
            this.txtCarRegistration.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCarRegistration.Location = new System.Drawing.Point(151, 275);
            this.txtCarRegistration.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.txtCarRegistration.MaxLength = 20;
            this.txtCarRegistration.Name = "txtCarRegistration";
            this.txtCarRegistration.PasswordChar = '\0';
            this.txtCarRegistration.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtCarRegistration.PlaceholderText = "ใส่ ทะเบียนรถตรงนี้";
            this.txtCarRegistration.SelectedText = "";
            this.txtCarRegistration.Size = new System.Drawing.Size(429, 72);
            this.txtCarRegistration.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtCarRegistration.TabIndex = 18;
            this.txtCarRegistration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.gbMain;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.VertSlide;
            this.bunifuTransition1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation2;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // tmStableWeight
            // 
            this.tmStableWeight.Interval = 1000;
            this.tmStableWeight.Tick += new System.EventHandler(this.tmStableWeight_Tick);
            // 
            // frmWeightHire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1354, 523);
            this.Controls.Add(this.gbMain);
            this.bunifuTransition1.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmWeightHire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHireWeight";
            this.Load += new System.EventHandler(this.frmHireWeight_Load);
            this.gbMain.ResumeLayout(false);
            this.gbProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.gbCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.gbWeightIN.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gbMain;
        private Guna.UI2.WinForms.Guna2GroupBox gbCustomer;
        private Guna.UI2.WinForms.Guna2Button btnClose1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCustomer;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchCustomer;
        private Guna.UI2.WinForms.Guna2GroupBox gbProduct;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchProduct;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProduct;
        private Guna.UI2.WinForms.Guna2GroupBox gbWeightIN;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnCancelWeighIN;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSaveWeightIN;
        private Bunifu.UI.WinForms.BunifuImageButton btnSearchProduct;
        private Bunifu.UI.WinForms.BunifuImageButton btnSearchCustomer;
        private Guna.UI2.WinForms.Guna2TextBox txtPrdName;
        private Guna.UI2.WinForms.Guna2TextBox txtPrdCode;
        private Guna.UI2.WinForms.Guna2TextBox txtCusName;
        private Guna.UI2.WinForms.Guna2TextBox txtCusID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbIndicator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtCarRegistration;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Bunifu.UI.WinForms.BunifuTransition bunifuTransition1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer tmStableWeight;
        private System.Windows.Forms.DataGridViewImageColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
    }
}