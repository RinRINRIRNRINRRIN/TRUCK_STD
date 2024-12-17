namespace TRUCK_STD.Design
{
    partial class frmWeightLPR_CCTV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeightLPR_CCTV));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpCam = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLPRBack = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.vlcFront = new Vlc.DotNet.Forms.VlcControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblLPRFront = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.guna2GroupBox4 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.vlcBack = new Vlc.DotNet.Forms.VlcControl();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvdata = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cl_del = new System.Windows.Forms.DataGridViewImageColumn();
            this.cl_print = new System.Windows.Forms.DataGridViewImageColumn();
            this.cl_customerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_idCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_epc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_provinceHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_provinceTail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_objective = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_dateRegistor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_licenseHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_licenseTail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_weightIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saScale = new System.IO.Ports.SerialPort(this.components);
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.tmCheckWeight = new System.Windows.Forms.Timer(this.components);
            this.saPLC = new System.IO.Ports.SerialPort(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.guna2CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.pnText = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnContaminants = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtContaminants = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnHumidity = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHumidity = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnPowder = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPowder = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPriceProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOther = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbProduct = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtLicenseTail = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GroupBox5 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblLicense = new System.Windows.Forms.Label();
            this.btnCancelWeight = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtWeightIn = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblWeight = new System.Windows.Forms.Label();
            this.msg = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.msgD = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.panel1.SuspendLayout();
            this.flpCam.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.guna2GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcFront)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.guna2GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcBack)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.panel4.SuspendLayout();
            this.pnText.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnContaminants.SuspendLayout();
            this.pnHumidity.SuspendLayout();
            this.pnPowder.SuspendLayout();
            this.guna2GroupBox5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Athiti SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "ชั่งรายการสินค้า";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(1789, 9);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.flpCam);
            this.panel1.Controls.Add(this.guna2GroupBox2);
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1831, 1013);
            this.panel1.TabIndex = 5;
            // 
            // flpCam
            // 
            this.flpCam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCam.AutoScroll = true;
            this.flpCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpCam.Controls.Add(this.panel2);
            this.flpCam.Controls.Add(this.panel3);
            this.flpCam.Location = new System.Drawing.Point(2, 3);
            this.flpCam.Name = "flpCam";
            this.flpCam.Size = new System.Drawing.Size(1231, 540);
            this.flpCam.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblLPRBack);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.guna2GroupBox3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.vlcFront);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 526);
            this.panel2.TabIndex = 12;
            // 
            // lblLPRBack
            // 
            this.lblLPRBack.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblLPRBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLPRBack.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLPRBack.ForeColor = System.Drawing.Color.White;
            this.lblLPRBack.Location = new System.Drawing.Point(0, 0);
            this.lblLPRBack.Name = "lblLPRBack";
            this.lblLPRBack.Size = new System.Drawing.Size(648, 31);
            this.lblLPRBack.TabIndex = 15;
            this.lblLPRBack.Text = "กล้องด้านหลัง";
            this.lblLPRBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(208, 401);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(198, 118);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox3.BorderColor = System.Drawing.Color.MidnightBlue;
            this.guna2GroupBox3.Controls.Add(this.label4);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.MidnightBlue;
            this.guna2GroupBox3.CustomBorderThickness = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.guna2GroupBox3.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox3.Location = new System.Drawing.Point(412, 403);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.guna2GroupBox3.Size = new System.Drawing.Size(233, 116);
            this.guna2GroupBox3.TabIndex = 2;
            this.guna2GroupBox3.Text = "ทะเบียนรถ";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Athiti", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(5, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 76);
            this.label4.TabIndex = 13;
            this.label4.Text = "----";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(4, 401);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // vlcFront
            // 
            this.vlcFront.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcFront.BackColor = System.Drawing.Color.DimGray;
            this.vlcFront.Location = new System.Drawing.Point(3, 34);
            this.vlcFront.Name = "vlcFront";
            this.vlcFront.Size = new System.Drawing.Size(642, 363);
            this.vlcFront.Spu = -1;
            this.vlcFront.TabIndex = 0;
            this.vlcFront.Text = "vlcControl1";
            this.vlcFront.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcFront.VlcLibDirectory")));
            this.vlcFront.VlcMediaplayerOptions = new string[] {
        ":network-caching=0",
        ":file-caching=100"};
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblLPRFront);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.guna2GroupBox4);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.vlcBack);
            this.panel3.Location = new System.Drawing.Point(3, 535);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(650, 526);
            this.panel3.TabIndex = 13;
            // 
            // lblLPRFront
            // 
            this.lblLPRFront.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblLPRFront.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLPRFront.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLPRFront.ForeColor = System.Drawing.Color.White;
            this.lblLPRFront.Location = new System.Drawing.Point(0, 0);
            this.lblLPRFront.Name = "lblLPRFront";
            this.lblLPRFront.Size = new System.Drawing.Size(648, 31);
            this.lblLPRFront.TabIndex = 16;
            this.lblLPRFront.Text = "กล้องด้านหน้า";
            this.lblLPRFront.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(208, 401);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(198, 118);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // guna2GroupBox4
            // 
            this.guna2GroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox4.BorderColor = System.Drawing.Color.MidnightBlue;
            this.guna2GroupBox4.Controls.Add(this.label5);
            this.guna2GroupBox4.CustomBorderColor = System.Drawing.Color.MidnightBlue;
            this.guna2GroupBox4.CustomBorderThickness = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.guna2GroupBox4.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox4.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox4.Location = new System.Drawing.Point(412, 401);
            this.guna2GroupBox4.Name = "guna2GroupBox4";
            this.guna2GroupBox4.Padding = new System.Windows.Forms.Padding(5);
            this.guna2GroupBox4.Size = new System.Drawing.Size(233, 118);
            this.guna2GroupBox4.TabIndex = 14;
            this.guna2GroupBox4.Text = "ทะเบียนรถ";
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Athiti", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(5, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 78);
            this.label5.TabIndex = 13;
            this.label5.Text = "----";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(4, 401);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(198, 118);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // vlcBack
            // 
            this.vlcBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcBack.BackColor = System.Drawing.Color.DimGray;
            this.vlcBack.Location = new System.Drawing.Point(3, 34);
            this.vlcBack.Name = "vlcBack";
            this.vlcBack.Size = new System.Drawing.Size(642, 363);
            this.vlcBack.Spu = -1;
            this.vlcBack.TabIndex = 0;
            this.vlcBack.Text = "vlcControl1";
            this.vlcBack.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcBack.VlcLibDirectory")));
            this.vlcBack.VlcMediaplayerOptions = new string[] {
        ":network-caching=0",
        ":file-caching=100"};
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox2.BackColor = System.Drawing.Color.White;
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Maroon;
            this.guna2GroupBox2.Controls.Add(this.dgvdata);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.Maroon;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Location = new System.Drawing.Point(1270, 6);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(561, 1007);
            this.guna2GroupBox2.TabIndex = 5;
            this.guna2GroupBox2.Text = "รายการที่กำลังชั่ง";
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvdata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvdata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvdata.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvdata.ColumnHeadersHeight = 30;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_del,
            this.cl_print,
            this.cl_customerId,
            this.cl_customerName,
            this.cl_productId,
            this.cl_productName,
            this.cl_id,
            this.cl_idCard,
            this.cl_epc,
            this.cl_fullname,
            this.cl_provinceHead,
            this.cl_provinceTail,
            this.cl_objective,
            this.cl_dateRegistor,
            this.cl_status,
            this.cl_job,
            this.cl_licenseHead,
            this.cl_licenseTail,
            this.cl_weightIn});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdata.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvdata.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvdata.Location = new System.Drawing.Point(3, 46);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersVisible = false;
            this.dgvdata.RowTemplate.Height = 30;
            this.dgvdata.Size = new System.Drawing.Size(553, 958);
            this.dgvdata.TabIndex = 0;
            this.dgvdata.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvdata.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvdata.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvdata.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvdata.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvdata.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvdata.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvdata.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvdata.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvdata.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvdata.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvdata.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvdata.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvdata.ThemeStyle.ReadOnly = true;
            this.dgvdata.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvdata.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvdata.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvdata.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvdata.ThemeStyle.RowsStyle.Height = 30;
            this.dgvdata.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvdata.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentDoubleClick);
            // 
            // cl_del
            // 
            this.cl_del.HeaderText = "";
            this.cl_del.Image = ((System.Drawing.Image)(resources.GetObject("cl_del.Image")));
            this.cl_del.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.cl_del.Name = "cl_del";
            this.cl_del.ReadOnly = true;
            this.cl_del.Width = 30;
            // 
            // cl_print
            // 
            this.cl_print.HeaderText = "";
            this.cl_print.Image = ((System.Drawing.Image)(resources.GetObject("cl_print.Image")));
            this.cl_print.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.cl_print.Name = "cl_print";
            this.cl_print.ReadOnly = true;
            this.cl_print.Width = 30;
            // 
            // cl_customerId
            // 
            this.cl_customerId.DataPropertyName = "customerId";
            this.cl_customerId.HeaderText = "customerId";
            this.cl_customerId.Name = "cl_customerId";
            this.cl_customerId.ReadOnly = true;
            this.cl_customerId.Visible = false;
            // 
            // cl_customerName
            // 
            this.cl_customerName.DataPropertyName = "customerName";
            this.cl_customerName.HeaderText = "customerName";
            this.cl_customerName.Name = "cl_customerName";
            this.cl_customerName.ReadOnly = true;
            this.cl_customerName.Visible = false;
            // 
            // cl_productId
            // 
            this.cl_productId.DataPropertyName = "productId";
            this.cl_productId.HeaderText = "productId";
            this.cl_productId.Name = "cl_productId";
            this.cl_productId.ReadOnly = true;
            this.cl_productId.Visible = false;
            // 
            // cl_productName
            // 
            this.cl_productName.DataPropertyName = "productName";
            this.cl_productName.HeaderText = "productName";
            this.cl_productName.Name = "cl_productName";
            this.cl_productName.ReadOnly = true;
            this.cl_productName.Visible = false;
            // 
            // cl_id
            // 
            this.cl_id.DataPropertyName = "id";
            this.cl_id.HeaderText = "id";
            this.cl_id.Name = "cl_id";
            this.cl_id.ReadOnly = true;
            this.cl_id.Visible = false;
            // 
            // cl_idCard
            // 
            this.cl_idCard.DataPropertyName = "idCard";
            this.cl_idCard.HeaderText = "idCard";
            this.cl_idCard.Name = "cl_idCard";
            this.cl_idCard.ReadOnly = true;
            this.cl_idCard.Visible = false;
            // 
            // cl_epc
            // 
            this.cl_epc.DataPropertyName = "epc";
            this.cl_epc.HeaderText = "epc";
            this.cl_epc.Name = "cl_epc";
            this.cl_epc.ReadOnly = true;
            this.cl_epc.Visible = false;
            // 
            // cl_fullname
            // 
            this.cl_fullname.DataPropertyName = "fullname";
            this.cl_fullname.HeaderText = "fullname";
            this.cl_fullname.Name = "cl_fullname";
            this.cl_fullname.ReadOnly = true;
            this.cl_fullname.Visible = false;
            // 
            // cl_provinceHead
            // 
            this.cl_provinceHead.DataPropertyName = "provinceHead";
            this.cl_provinceHead.HeaderText = "provinceHead";
            this.cl_provinceHead.Name = "cl_provinceHead";
            this.cl_provinceHead.ReadOnly = true;
            this.cl_provinceHead.Visible = false;
            // 
            // cl_provinceTail
            // 
            this.cl_provinceTail.DataPropertyName = "provinceTail";
            this.cl_provinceTail.HeaderText = "provinceTail";
            this.cl_provinceTail.Name = "cl_provinceTail";
            this.cl_provinceTail.ReadOnly = true;
            this.cl_provinceTail.Visible = false;
            // 
            // cl_objective
            // 
            this.cl_objective.DataPropertyName = "note";
            this.cl_objective.HeaderText = "objective";
            this.cl_objective.Name = "cl_objective";
            this.cl_objective.ReadOnly = true;
            this.cl_objective.Visible = false;
            // 
            // cl_dateRegistor
            // 
            this.cl_dateRegistor.DataPropertyName = "dateRegistor";
            this.cl_dateRegistor.HeaderText = "dateRegistor";
            this.cl_dateRegistor.Name = "cl_dateRegistor";
            this.cl_dateRegistor.ReadOnly = true;
            this.cl_dateRegistor.Visible = false;
            // 
            // cl_status
            // 
            this.cl_status.DataPropertyName = "status";
            this.cl_status.HeaderText = "status";
            this.cl_status.Name = "cl_status";
            this.cl_status.ReadOnly = true;
            this.cl_status.Visible = false;
            // 
            // cl_job
            // 
            this.cl_job.DataPropertyName = "jobOrder";
            this.cl_job.HeaderText = "เลขที่ชั่ง";
            this.cl_job.Name = "cl_job";
            this.cl_job.ReadOnly = true;
            this.cl_job.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_job.Width = 200;
            // 
            // cl_licenseHead
            // 
            this.cl_licenseHead.DataPropertyName = "licenseHead";
            this.cl_licenseHead.HeaderText = "ทะเบียนหัว";
            this.cl_licenseHead.Name = "cl_licenseHead";
            this.cl_licenseHead.ReadOnly = true;
            this.cl_licenseHead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cl_licenseTail
            // 
            this.cl_licenseTail.DataPropertyName = "licenseTail";
            this.cl_licenseTail.HeaderText = "ทะเบียนหาง";
            this.cl_licenseTail.Name = "cl_licenseTail";
            this.cl_licenseTail.ReadOnly = true;
            this.cl_licenseTail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cl_weightIn
            // 
            this.cl_weightIn.DataPropertyName = "weight";
            this.cl_weightIn.HeaderText = "น้ำหนักชั่งเข้า";
            this.cl_weightIn.Name = "cl_weightIn";
            this.cl_weightIn.ReadOnly = true;
            this.cl_weightIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_weightIn.Width = 150;
            // 
            // saScale
            // 
            this.saScale.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.saScale_DataReceived);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // tmCheckWeight
            // 
            this.tmCheckWeight.Interval = 10000;
            this.tmCheckWeight.Tick += new System.EventHandler(this.tmCheckWeight_Tick);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.guna2CheckBox1);
            this.panel4.Controls.Add(this.pnText);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(3, 604);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1233, 470);
            this.panel4.TabIndex = 13;
            // 
            // guna2CheckBox1
            // 
            this.guna2CheckBox1.Animated = true;
            this.guna2CheckBox1.AutoSize = true;
            this.guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.CheckedState.BorderRadius = 0;
            this.guna2CheckBox1.CheckedState.BorderThickness = 0;
            this.guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.Location = new System.Drawing.Point(5, 104);
            this.guna2CheckBox1.Name = "guna2CheckBox1";
            this.guna2CheckBox1.Size = new System.Drawing.Size(107, 29);
            this.guna2CheckBox1.TabIndex = 24;
            this.guna2CheckBox1.Text = "เพิ่มตั๋วชั่งเข้า";
            this.guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox1.UncheckedState.BorderRadius = 0;
            this.guna2CheckBox1.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // pnText
            // 
            this.pnText.Controls.Add(this.flowLayoutPanel1);
            this.pnText.Controls.Add(this.label8);
            this.pnText.Controls.Add(this.txtPriceProduct);
            this.pnText.Controls.Add(this.label6);
            this.pnText.Controls.Add(this.txtOther);
            this.pnText.Controls.Add(this.label3);
            this.pnText.Controls.Add(this.label2);
            this.pnText.Controls.Add(this.cbbCustomer);
            this.pnText.Controls.Add(this.cbbProduct);
            this.pnText.Controls.Add(this.txtLicenseTail);
            this.pnText.Controls.Add(this.guna2GroupBox5);
            this.pnText.Controls.Add(this.btnCancelWeight);
            this.pnText.Controls.Add(this.btnSave);
            this.pnText.Controls.Add(this.txtNote);
            this.pnText.Controls.Add(this.txtWeightIn);
            this.pnText.Enabled = false;
            this.pnText.Location = new System.Drawing.Point(3, 135);
            this.pnText.Name = "pnText";
            this.pnText.Size = new System.Drawing.Size(1255, 330);
            this.pnText.TabIndex = 23;
            this.pnText.Paint += new System.Windows.Forms.PaintEventHandler(this.pnText_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnContaminants);
            this.flowLayoutPanel1.Controls.Add(this.pnHumidity);
            this.flowLayoutPanel1.Controls.Add(this.pnPowder);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(315, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(936, 98);
            this.flowLayoutPanel1.TabIndex = 39;
            // 
            // pnContaminants
            // 
            this.pnContaminants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnContaminants.Controls.Add(this.label9);
            this.pnContaminants.Controls.Add(this.txtContaminants);
            this.pnContaminants.Location = new System.Drawing.Point(3, 3);
            this.pnContaminants.Name = "pnContaminants";
            this.pnContaminants.Size = new System.Drawing.Size(257, 88);
            this.pnContaminants.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 25);
            this.label9.TabIndex = 33;
            this.label9.Text = "% สิ่งเจือปน";
            // 
            // txtContaminants
            // 
            this.txtContaminants.BorderColor = System.Drawing.Color.Firebrick;
            this.txtContaminants.BorderRadius = 3;
            this.txtContaminants.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContaminants.DefaultText = "0";
            this.txtContaminants.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContaminants.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContaminants.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContaminants.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContaminants.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContaminants.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContaminants.ForeColor = System.Drawing.Color.Black;
            this.txtContaminants.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContaminants.Location = new System.Drawing.Point(29, 45);
            this.txtContaminants.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtContaminants.Name = "txtContaminants";
            this.txtContaminants.PasswordChar = '\0';
            this.txtContaminants.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtContaminants.PlaceholderText = "เปอร์เซ็นสิ่งเจือปน";
            this.txtContaminants.SelectedText = "";
            this.txtContaminants.Size = new System.Drawing.Size(196, 36);
            this.txtContaminants.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtContaminants.TabIndex = 34;
            this.txtContaminants.Tag = "value";
            this.txtContaminants.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnHumidity
            // 
            this.pnHumidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnHumidity.Controls.Add(this.label10);
            this.pnHumidity.Controls.Add(this.txtHumidity);
            this.pnHumidity.Location = new System.Drawing.Point(266, 3);
            this.pnHumidity.Name = "pnHumidity";
            this.pnHumidity.Size = new System.Drawing.Size(257, 88);
            this.pnHumidity.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 25);
            this.label10.TabIndex = 35;
            this.label10.Text = "% ความชื่น";
            // 
            // txtHumidity
            // 
            this.txtHumidity.BorderColor = System.Drawing.Color.Firebrick;
            this.txtHumidity.BorderRadius = 3;
            this.txtHumidity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHumidity.DefaultText = "0";
            this.txtHumidity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHumidity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHumidity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHumidity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHumidity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHumidity.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHumidity.ForeColor = System.Drawing.Color.Black;
            this.txtHumidity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHumidity.Location = new System.Drawing.Point(47, 45);
            this.txtHumidity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtHumidity.Name = "txtHumidity";
            this.txtHumidity.PasswordChar = '\0';
            this.txtHumidity.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtHumidity.PlaceholderText = "เปอร์เซ็นความชื่น";
            this.txtHumidity.SelectedText = "";
            this.txtHumidity.Size = new System.Drawing.Size(165, 36);
            this.txtHumidity.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtHumidity.TabIndex = 28;
            this.txtHumidity.Tag = "value";
            this.txtHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnPowder
            // 
            this.pnPowder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnPowder.Controls.Add(this.label11);
            this.pnPowder.Controls.Add(this.txtPowder);
            this.pnPowder.Location = new System.Drawing.Point(529, 3);
            this.pnPowder.Name = "pnPowder";
            this.pnPowder.Size = new System.Drawing.Size(257, 88);
            this.pnPowder.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 25);
            this.label11.TabIndex = 36;
            this.label11.Text = "% แป้ง";
            // 
            // txtPowder
            // 
            this.txtPowder.BorderColor = System.Drawing.Color.Firebrick;
            this.txtPowder.BorderRadius = 3;
            this.txtPowder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPowder.DefaultText = "0";
            this.txtPowder.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPowder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPowder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPowder.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPowder.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPowder.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPowder.ForeColor = System.Drawing.Color.Black;
            this.txtPowder.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPowder.Location = new System.Drawing.Point(43, 45);
            this.txtPowder.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPowder.Name = "txtPowder";
            this.txtPowder.PasswordChar = '\0';
            this.txtPowder.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPowder.PlaceholderText = "เปอร์เซ็นแป้ง";
            this.txtPowder.SelectedText = "";
            this.txtPowder.Size = new System.Drawing.Size(179, 36);
            this.txtPowder.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtPowder.TabIndex = 37;
            this.txtPowder.Tag = "value";
            this.txtPowder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(570, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 25);
            this.label8.TabIndex = 32;
            this.label8.Text = "บาท";
            // 
            // txtPriceProduct
            // 
            this.txtPriceProduct.BorderColor = System.Drawing.Color.Black;
            this.txtPriceProduct.BorderRadius = 3;
            this.txtPriceProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPriceProduct.DefaultText = "";
            this.txtPriceProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPriceProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPriceProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPriceProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPriceProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPriceProduct.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceProduct.ForeColor = System.Drawing.Color.Black;
            this.txtPriceProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPriceProduct.Location = new System.Drawing.Point(315, 249);
            this.txtPriceProduct.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPriceProduct.Name = "txtPriceProduct";
            this.txtPriceProduct.PasswordChar = '\0';
            this.txtPriceProduct.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPriceProduct.PlaceholderText = "ราคา/กิโลกรัม";
            this.txtPriceProduct.ReadOnly = true;
            this.txtPriceProduct.SelectedText = "";
            this.txtPriceProduct.Size = new System.Drawing.Size(249, 36);
            this.txtPriceProduct.TabIndex = 31;
            this.txtPriceProduct.Tag = "value";
            this.txtPriceProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 25);
            this.label6.TabIndex = 29;
            this.label6.Text = "KG";
            // 
            // txtOther
            // 
            this.txtOther.AutoScroll = true;
            this.txtOther.BorderColor = System.Drawing.Color.Black;
            this.txtOther.BorderRadius = 3;
            this.txtOther.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOther.DefaultText = "";
            this.txtOther.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOther.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOther.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOther.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOther.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOther.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOther.ForeColor = System.Drawing.Color.Black;
            this.txtOther.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOther.Location = new System.Drawing.Point(851, 163);
            this.txtOther.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtOther.Multiline = true;
            this.txtOther.Name = "txtOther";
            this.txtOther.PasswordChar = '\0';
            this.txtOther.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtOther.PlaceholderText = "อื่น ๆ ค่าจัดลา ค่าทำความสะอาด";
            this.txtOther.SelectedText = "";
            this.txtOther.Size = new System.Drawing.Size(400, 118);
            this.txtOther.TabIndex = 26;
            this.txtOther.Tag = "value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "ชื่อลูกค้า : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "สินค้า : ";
            // 
            // cbbCustomer
            // 
            this.cbbCustomer.AllowDrop = true;
            this.cbbCustomer.BackColor = System.Drawing.Color.Transparent;
            this.cbbCustomer.BorderColor = System.Drawing.Color.Black;
            this.cbbCustomer.BorderRadius = 3;
            this.cbbCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCustomer.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbCustomer.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCustomer.ForeColor = System.Drawing.Color.Black;
            this.cbbCustomer.HoverState.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbbCustomer.HoverState.ForeColor = System.Drawing.Color.Black;
            this.cbbCustomer.ItemHeight = 30;
            this.cbbCustomer.Location = new System.Drawing.Point(315, 163);
            this.cbbCustomer.Name = "cbbCustomer";
            this.cbbCustomer.Size = new System.Drawing.Size(530, 36);
            this.cbbCustomer.TabIndex = 23;
            this.cbbCustomer.Tag = "customer";
            this.cbbCustomer.DropDown += new System.EventHandler(this.SelectItems);
            // 
            // cbbProduct
            // 
            this.cbbProduct.AllowDrop = true;
            this.cbbProduct.BackColor = System.Drawing.Color.Transparent;
            this.cbbProduct.BorderColor = System.Drawing.Color.Black;
            this.cbbProduct.BorderRadius = 3;
            this.cbbProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProduct.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbProduct.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProduct.ForeColor = System.Drawing.Color.Black;
            this.cbbProduct.HoverState.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbbProduct.HoverState.ForeColor = System.Drawing.Color.Black;
            this.cbbProduct.ItemHeight = 30;
            this.cbbProduct.Location = new System.Drawing.Point(315, 205);
            this.cbbProduct.Name = "cbbProduct";
            this.cbbProduct.Size = new System.Drawing.Size(530, 36);
            this.cbbProduct.TabIndex = 22;
            this.cbbProduct.Tag = "product";
            this.cbbProduct.DropDown += new System.EventHandler(this.SelectItems);
            // 
            // txtLicenseTail
            // 
            this.txtLicenseTail.BorderColor = System.Drawing.Color.Black;
            this.txtLicenseTail.BorderRadius = 3;
            this.txtLicenseTail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLicenseTail.DefaultText = "";
            this.txtLicenseTail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLicenseTail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLicenseTail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLicenseTail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLicenseTail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicenseTail.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenseTail.ForeColor = System.Drawing.Color.Black;
            this.txtLicenseTail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicenseTail.Location = new System.Drawing.Point(612, 249);
            this.txtLicenseTail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtLicenseTail.Name = "txtLicenseTail";
            this.txtLicenseTail.PasswordChar = '\0';
            this.txtLicenseTail.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtLicenseTail.PlaceholderText = "ทะเบียนหาง";
            this.txtLicenseTail.SelectedText = "";
            this.txtLicenseTail.Size = new System.Drawing.Size(233, 36);
            this.txtLicenseTail.TabIndex = 21;
            this.txtLicenseTail.Tag = "value";
            // 
            // guna2GroupBox5
            // 
            this.guna2GroupBox5.BorderColor = System.Drawing.Color.MidnightBlue;
            this.guna2GroupBox5.BorderRadius = 3;
            this.guna2GroupBox5.Controls.Add(this.lblLicense);
            this.guna2GroupBox5.CustomBorderColor = System.Drawing.Color.MidnightBlue;
            this.guna2GroupBox5.CustomBorderThickness = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.guna2GroupBox5.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox5.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox5.Location = new System.Drawing.Point(3, 4);
            this.guna2GroupBox5.Name = "guna2GroupBox5";
            this.guna2GroupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.guna2GroupBox5.Size = new System.Drawing.Size(221, 174);
            this.guna2GroupBox5.TabIndex = 15;
            this.guna2GroupBox5.Text = "ทะเบียนรถ";
            // 
            // lblLicense
            // 
            this.lblLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLicense.Font = new System.Drawing.Font("Athiti", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLicense.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLicense.Location = new System.Drawing.Point(5, 35);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(211, 134);
            this.lblLicense.TabIndex = 13;
            this.lblLicense.Text = "----";
            this.lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelWeight
            // 
            this.btnCancelWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelWeight.Animated = true;
            this.btnCancelWeight.BorderRadius = 2;
            this.btnCancelWeight.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelWeight.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelWeight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelWeight.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelWeight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelWeight.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelWeight.FillColor2 = System.Drawing.Color.MidnightBlue;
            this.btnCancelWeight.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelWeight.ForeColor = System.Drawing.Color.White;
            this.btnCancelWeight.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnCancelWeight.HoverState.FillColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelWeight.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnCancelWeight.Location = new System.Drawing.Point(1053, 289);
            this.btnCancelWeight.Name = "btnCancelWeight";
            this.btnCancelWeight.Size = new System.Drawing.Size(199, 36);
            this.btnCancelWeight.TabIndex = 14;
            this.btnCancelWeight.Text = "ยกเลิกการชั่ง";
            this.btnCancelWeight.Click += new System.EventHandler(this.btnCancelWeight_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Animated = true;
            this.btnSave.BorderRadius = 2;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor2 = System.Drawing.Color.MidnightBlue;
            this.btnSave.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(851, 289);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(196, 36);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "บันทึกชั่งเข้า";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNote
            // 
            this.txtNote.AutoScroll = true;
            this.txtNote.BorderColor = System.Drawing.Color.Black;
            this.txtNote.BorderRadius = 3;
            this.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNote.DefaultText = "";
            this.txtNote.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNote.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNote.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNote.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNote.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.ForeColor = System.Drawing.Color.Black;
            this.txtNote.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNote.Location = new System.Drawing.Point(235, 289);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNote.Name = "txtNote";
            this.txtNote.PasswordChar = '\0';
            this.txtNote.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtNote.PlaceholderText = "หมายเหตุ";
            this.txtNote.SelectedText = "";
            this.txtNote.Size = new System.Drawing.Size(610, 36);
            this.txtNote.TabIndex = 20;
            this.txtNote.Tag = "value";
            // 
            // txtWeightIn
            // 
            this.txtWeightIn.BorderColor = System.Drawing.Color.Black;
            this.txtWeightIn.BorderRadius = 3;
            this.txtWeightIn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWeightIn.DefaultText = "";
            this.txtWeightIn.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWeightIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWeightIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWeightIn.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWeightIn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWeightIn.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeightIn.ForeColor = System.Drawing.Color.Black;
            this.txtWeightIn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWeightIn.Location = new System.Drawing.Point(3, 186);
            this.txtWeightIn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtWeightIn.Name = "txtWeightIn";
            this.txtWeightIn.PasswordChar = '\0';
            this.txtWeightIn.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtWeightIn.PlaceholderText = "น้ำหนักชั่งเข้า";
            this.txtWeightIn.ReadOnly = true;
            this.txtWeightIn.SelectedText = "";
            this.txtWeightIn.Size = new System.Drawing.Size(186, 33);
            this.txtWeightIn.TabIndex = 19;
            this.txtWeightIn.Tag = "weight";
            this.txtWeightIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblWeight);
            this.panel5.Location = new System.Drawing.Point(-1, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1229, 96);
            this.panel5.TabIndex = 21;
            // 
            // lblWeight
            // 
            this.lblWeight.Font = new System.Drawing.Font("Athiti", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblWeight.Location = new System.Drawing.Point(2, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(1256, 94);
            this.lblWeight.TabIndex = 0;
            this.lblWeight.Text = "0";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // msg
            // 
            this.msg.AllowDragging = false;
            this.msg.AllowMultipleViews = true;
            this.msg.ClickToClose = true;
            this.msg.DoubleClickToClose = true;
            this.msg.DurationAfterIdle = 3000;
            this.msg.ErrorOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msg.ErrorOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msg.ErrorOptions.ActionBorderRadius = 1;
            this.msg.ErrorOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.msg.ErrorOptions.ActionForeColor = System.Drawing.Color.Black;
            this.msg.ErrorOptions.BackColor = System.Drawing.Color.White;
            this.msg.ErrorOptions.BorderColor = System.Drawing.Color.White;
            this.msg.ErrorOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(199)))));
            this.msg.ErrorOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.msg.ErrorOptions.ForeColor = System.Drawing.Color.Black;
            this.msg.ErrorOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon")));
            this.msg.ErrorOptions.IconLeftMargin = 12;
            this.msg.FadeCloseIcon = false;
            this.msg.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner;
            this.msg.InformationOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msg.InformationOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msg.InformationOptions.ActionBorderRadius = 1;
            this.msg.InformationOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.msg.InformationOptions.ActionForeColor = System.Drawing.Color.Black;
            this.msg.InformationOptions.BackColor = System.Drawing.Color.White;
            this.msg.InformationOptions.BorderColor = System.Drawing.Color.White;
            this.msg.InformationOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.msg.InformationOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.msg.InformationOptions.ForeColor = System.Drawing.Color.Black;
            this.msg.InformationOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon1")));
            this.msg.InformationOptions.IconLeftMargin = 12;
            this.msg.Margin = 10;
            this.msg.MaximumSize = new System.Drawing.Size(0, 0);
            this.msg.MaximumViews = 7;
            this.msg.MessageRightMargin = 15;
            this.msg.MinimumSize = new System.Drawing.Size(0, 0);
            this.msg.ShowBorders = false;
            this.msg.ShowCloseIcon = false;
            this.msg.ShowIcon = true;
            this.msg.ShowShadows = true;
            this.msg.SuccessOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msg.SuccessOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msg.SuccessOptions.ActionBorderRadius = 1;
            this.msg.SuccessOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.msg.SuccessOptions.ActionForeColor = System.Drawing.Color.Black;
            this.msg.SuccessOptions.BackColor = System.Drawing.Color.White;
            this.msg.SuccessOptions.BorderColor = System.Drawing.Color.White;
            this.msg.SuccessOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(237)))));
            this.msg.SuccessOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.msg.SuccessOptions.ForeColor = System.Drawing.Color.Black;
            this.msg.SuccessOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon2")));
            this.msg.SuccessOptions.IconLeftMargin = 12;
            this.msg.ViewsMargin = 7;
            this.msg.WarningOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msg.WarningOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.msg.WarningOptions.ActionBorderRadius = 1;
            this.msg.WarningOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.msg.WarningOptions.ActionForeColor = System.Drawing.Color.Black;
            this.msg.WarningOptions.BackColor = System.Drawing.Color.White;
            this.msg.WarningOptions.BorderColor = System.Drawing.Color.White;
            this.msg.WarningOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(143)))));
            this.msg.WarningOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.msg.WarningOptions.ForeColor = System.Drawing.Color.Black;
            this.msg.WarningOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon3")));
            this.msg.WarningOptions.IconLeftMargin = 12;
            this.msg.ZoomCloseIcon = true;
            // 
            // msgD
            // 
            this.msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msgD.Caption = null;
            this.msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.msgD.Parent = this;
            this.msgD.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.msgD.Text = null;
            // 
            // frmWeightLPR_CCTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1846, 1080);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmWeightLPR_CCTV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNewWeight";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNewWeight_FormClosing);
            this.Load += new System.EventHandler(this.frmNewWeight_Load);
            this.panel1.ResumeLayout(false);
            this.flpCam.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.guna2GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcFront)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.guna2GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcBack)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnText.ResumeLayout(false);
            this.pnText.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnContaminants.ResumeLayout(false);
            this.pnContaminants.PerformLayout();
            this.pnHumidity.ResumeLayout(false);
            this.pnHumidity.PerformLayout();
            this.pnPowder.ResumeLayout(false);
            this.pnPowder.PerformLayout();
            this.guna2GroupBox5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Panel panel1;
        private System.IO.Ports.SerialPort saScale;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Timer tmCheckWeight;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.IO.Ports.SerialPort saPLC;
        private Guna.UI2.WinForms.Guna2DataGridView dgvdata;
        private System.Windows.Forms.FlowLayoutPanel flpCam;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblLPRFront;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Vlc.DotNet.Forms.VlcControl vlcBack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLPRBack;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Vlc.DotNet.Forms.VlcControl vlcFront;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblWeight;
        private Bunifu.UI.WinForms.BunifuSnackbar msg;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancelWeight;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private Guna.UI2.WinForms.Guna2TextBox txtNote;
        private Guna.UI2.WinForms.Guna2TextBox txtWeightIn;
        private Guna.UI2.WinForms.Guna2MessageDialog msgD;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnText;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox5;
        private System.Windows.Forms.Label lblLicense;
        private Guna.UI2.WinForms.Guna2TextBox txtLicenseTail;
        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbbProduct;
        private Guna.UI2.WinForms.Guna2ComboBox cbbCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtOther;
        private System.Windows.Forms.DataGridViewImageColumn cl_del;
        private System.Windows.Forms.DataGridViewImageColumn cl_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_customerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_idCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_epc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_provinceHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_provinceTail;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_objective;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_dateRegistor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_licenseHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_licenseTail;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_weightIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtPriceProduct;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnContaminants;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtContaminants;
        private System.Windows.Forms.Panel pnHumidity;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtHumidity;
        private System.Windows.Forms.Panel pnPowder;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox txtPowder;
    }
}