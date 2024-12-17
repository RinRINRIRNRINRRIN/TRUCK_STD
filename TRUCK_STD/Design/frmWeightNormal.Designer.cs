namespace TRUCK_STD.Design
{
    partial class frmWeightNormal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeightNormal));
            this.msgD = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.msg = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.saPLC = new System.IO.Ports.SerialPort(this.components);
            this.saScale = new System.IO.Ports.SerialPort(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvdata = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cl_del = new System.Windows.Forms.DataGridViewImageColumn();
            this.cl_print = new System.Windows.Forms.DataGridViewImageColumn();
            this.cl_customerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_productPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblWeight = new System.Windows.Forms.Label();
            this.pnText = new System.Windows.Forms.Panel();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.pnMainInformation = new System.Windows.Forms.Panel();
            this.lblWeightIn = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbProduct = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPriceProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLicenseTail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLicenseHead = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOther = new Guna.UI2.WinForms.Guna2TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnContaminants = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContaminants = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnHumidity = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHumidity = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnPowder = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPowder = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancelWeight = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tmCheckWeight = new System.Windows.Forms.Timer(this.components);
            this.lblScaleName = new System.Windows.Forms.Label();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.pnText.SuspendLayout();
            this.pnMainInformation.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnContaminants.SuspendLayout();
            this.pnHumidity.SuspendLayout();
            this.pnPowder.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgD
            // 
            this.msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msgD.Caption = null;
            this.msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.msgD.Parent = this;
            this.msgD.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.msgD.Text = null;
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
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Athiti SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "ชั่งรายการสินค้า";
            // 
            // saScale
            // 
            this.saScale.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.saScale_DataReceived);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(1401, 8);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(40, 33);
            this.guna2ControlBox1.TabIndex = 5;
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
            this.guna2GroupBox2.Location = new System.Drawing.Point(813, 65);
            this.guna2GroupBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(628, 670);
            this.guna2GroupBox2.TabIndex = 6;
            this.guna2GroupBox2.Text = "รายการที่กำลังชั่ง";
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvdata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvdata.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.ColumnHeadersHeight = 30;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_del,
            this.cl_print,
            this.cl_customerId,
            this.cl_customerName,
            this.cl_productId,
            this.cl_productName,
            this.cl_productPrice,
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdata.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvdata.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvdata.Location = new System.Drawing.Point(4, 43);
            this.dgvdata.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersVisible = false;
            this.dgvdata.RowTemplate.Height = 30;
            this.dgvdata.Size = new System.Drawing.Size(616, 621);
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
            this.dgvdata.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellDoubleClick);
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
            // cl_productPrice
            // 
            this.cl_productPrice.DataPropertyName = "productPrice";
            this.cl_productPrice.HeaderText = "productPrice";
            this.cl_productPrice.Name = "cl_productPrice";
            this.cl_productPrice.ReadOnly = true;
            this.cl_productPrice.Visible = false;
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
            // lblWeight
            // 
            this.lblWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWeight.Font = new System.Drawing.Font("Athiti", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblWeight.Location = new System.Drawing.Point(8, 65);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(801, 147);
            this.lblWeight.TabIndex = 7;
            this.lblWeight.Text = "ERROR";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnText
            // 
            this.pnText.Controls.Add(this.guna2GradientButton1);
            this.pnText.Controls.Add(this.pnMainInformation);
            this.pnText.Controls.Add(this.label11);
            this.pnText.Controls.Add(this.label10);
            this.pnText.Controls.Add(this.txtOther);
            this.pnText.Controls.Add(this.flowLayoutPanel1);
            this.pnText.Controls.Add(this.btnCancelWeight);
            this.pnText.Controls.Add(this.btnSave);
            this.pnText.Location = new System.Drawing.Point(8, 215);
            this.pnText.Name = "pnText";
            this.pnText.Size = new System.Drawing.Size(802, 520);
            this.pnText.TabIndex = 24;
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.BorderRadius = 2;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.MidnightBlue;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GradientButton1.Location = new System.Drawing.Point(13, 478);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(196, 36);
            this.guna2GradientButton1.TabIndex = 46;
            this.guna2GradientButton1.Text = "บันทึกชั่งเข้า";
            this.guna2GradientButton1.Visible = false;
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // pnMainInformation
            // 
            this.pnMainInformation.Controls.Add(this.lblWeightIn);
            this.pnMainInformation.Controls.Add(this.label7);
            this.pnMainInformation.Controls.Add(this.cbbProduct);
            this.pnMainInformation.Controls.Add(this.cbbCustomer);
            this.pnMainInformation.Controls.Add(this.label2);
            this.pnMainInformation.Controls.Add(this.label9);
            this.pnMainInformation.Controls.Add(this.label8);
            this.pnMainInformation.Controls.Add(this.label3);
            this.pnMainInformation.Controls.Add(this.txtPriceProduct);
            this.pnMainInformation.Controls.Add(this.txtLicenseTail);
            this.pnMainInformation.Controls.Add(this.txtLicenseHead);
            this.pnMainInformation.Location = new System.Drawing.Point(3, 3);
            this.pnMainInformation.Name = "pnMainInformation";
            this.pnMainInformation.Size = new System.Drawing.Size(794, 136);
            this.pnMainInformation.TabIndex = 45;
            // 
            // lblWeightIn
            // 
            this.lblWeightIn.AutoSize = true;
            this.lblWeightIn.Font = new System.Drawing.Font("Athiti Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblWeightIn.Location = new System.Drawing.Point(121, 93);
            this.lblWeightIn.Name = "lblWeightIn";
            this.lblWeightIn.Size = new System.Drawing.Size(28, 25);
            this.lblWeightIn.TabIndex = 43;
            this.lblWeightIn.Text = "--";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 25);
            this.label7.TabIndex = 40;
            this.label7.Text = "ทะเบียนส่วนหัว :";
            // 
            // cbbProduct
            // 
            this.cbbProduct.AllowDrop = true;
            this.cbbProduct.BackColor = System.Drawing.Color.Transparent;
            this.cbbProduct.BorderColor = System.Drawing.Color.Firebrick;
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
            this.cbbProduct.Location = new System.Drawing.Point(455, 49);
            this.cbbProduct.Name = "cbbProduct";
            this.cbbProduct.Size = new System.Drawing.Size(288, 36);
            this.cbbProduct.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbbProduct.TabIndex = 22;
            this.cbbProduct.Tag = "product";
            this.cbbProduct.DropDown += new System.EventHandler(this.SelectItems);
            this.cbbProduct.SelectedIndexChanged += new System.EventHandler(this.cbbProduct_SelectedIndexChanged);
            // 
            // cbbCustomer
            // 
            this.cbbCustomer.AllowDrop = true;
            this.cbbCustomer.BackColor = System.Drawing.Color.Transparent;
            this.cbbCustomer.BorderColor = System.Drawing.Color.Firebrick;
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
            this.cbbCustomer.Location = new System.Drawing.Point(455, 7);
            this.cbbCustomer.Name = "cbbCustomer";
            this.cbbCustomer.Size = new System.Drawing.Size(288, 36);
            this.cbbCustomer.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbbCustomer.TabIndex = 23;
            this.cbbCustomer.Tag = "customer";
            this.cbbCustomer.DropDown += new System.EventHandler(this.SelectItems);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "สินค้า :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 25);
            this.label9.TabIndex = 42;
            this.label9.Text = "ทะเบียนส่วนท้าย :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(752, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 25);
            this.label8.TabIndex = 32;
            this.label8.Text = "บาท";
            this.label8.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "ชื่อลูกค้า :";
            // 
            // txtPriceProduct
            // 
            this.txtPriceProduct.BorderColor = System.Drawing.Color.Firebrick;
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
            this.txtPriceProduct.Location = new System.Drawing.Point(608, 93);
            this.txtPriceProduct.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPriceProduct.Name = "txtPriceProduct";
            this.txtPriceProduct.PasswordChar = '\0';
            this.txtPriceProduct.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPriceProduct.PlaceholderText = "ราคา/กิโลกรัม";
            this.txtPriceProduct.ReadOnly = true;
            this.txtPriceProduct.SelectedText = "";
            this.txtPriceProduct.Size = new System.Drawing.Size(135, 36);
            this.txtPriceProduct.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtPriceProduct.TabIndex = 31;
            this.txtPriceProduct.Tag = "value";
            this.txtPriceProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPriceProduct.Visible = false;
            // 
            // txtLicenseTail
            // 
            this.txtLicenseTail.BorderColor = System.Drawing.Color.Firebrick;
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
            this.txtLicenseTail.Location = new System.Drawing.Point(122, 49);
            this.txtLicenseTail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtLicenseTail.Name = "txtLicenseTail";
            this.txtLicenseTail.PasswordChar = '\0';
            this.txtLicenseTail.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtLicenseTail.PlaceholderText = "ทะเบียนท้าย";
            this.txtLicenseTail.SelectedText = "";
            this.txtLicenseTail.Size = new System.Drawing.Size(249, 36);
            this.txtLicenseTail.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtLicenseTail.TabIndex = 41;
            this.txtLicenseTail.Tag = "value";
            this.txtLicenseTail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLicenseHead
            // 
            this.txtLicenseHead.BorderColor = System.Drawing.Color.Firebrick;
            this.txtLicenseHead.BorderRadius = 3;
            this.txtLicenseHead.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLicenseHead.DefaultText = "";
            this.txtLicenseHead.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLicenseHead.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLicenseHead.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLicenseHead.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLicenseHead.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicenseHead.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenseHead.ForeColor = System.Drawing.Color.Black;
            this.txtLicenseHead.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicenseHead.Location = new System.Drawing.Point(122, 5);
            this.txtLicenseHead.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtLicenseHead.Name = "txtLicenseHead";
            this.txtLicenseHead.PasswordChar = '\0';
            this.txtLicenseHead.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtLicenseHead.PlaceholderText = "ทะเบียนหัว";
            this.txtLicenseHead.SelectedText = "";
            this.txtLicenseHead.Size = new System.Drawing.Size(249, 36);
            this.txtLicenseHead.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtLicenseHead.TabIndex = 39;
            this.txtLicenseHead.Tag = "value";
            this.txtLicenseHead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Brown;
            this.label11.Location = new System.Drawing.Point(4, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(795, 3);
            this.label11.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Athiti Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(7, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 25);
            this.label10.TabIndex = 43;
            this.label10.Text = "หักอื่น ๆ ";
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
            this.txtOther.Enabled = false;
            this.txtOther.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOther.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOther.ForeColor = System.Drawing.Color.Black;
            this.txtOther.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOther.Location = new System.Drawing.Point(11, 293);
            this.txtOther.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtOther.Multiline = true;
            this.txtOther.Name = "txtOther";
            this.txtOther.PasswordChar = '\0';
            this.txtOther.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtOther.PlaceholderText = "อื่น ๆ ค่าจัดลา ค่าทำความสะอาด";
            this.txtOther.SelectedText = "";
            this.txtOther.Size = new System.Drawing.Size(778, 177);
            this.txtOther.TabIndex = 26;
            this.txtOther.Tag = "value";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnContaminants);
            this.flowLayoutPanel1.Controls.Add(this.pnHumidity);
            this.flowLayoutPanel1.Controls.Add(this.pnPowder);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 182);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(791, 103);
            this.flowLayoutPanel1.TabIndex = 38;
            // 
            // pnContaminants
            // 
            this.pnContaminants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnContaminants.Controls.Add(this.label4);
            this.pnContaminants.Controls.Add(this.txtContaminants);
            this.pnContaminants.Location = new System.Drawing.Point(3, 3);
            this.pnContaminants.Name = "pnContaminants";
            this.pnContaminants.Size = new System.Drawing.Size(257, 88);
            this.pnContaminants.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 33;
            this.label4.Text = "% สิ่งเจือปน";
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
            this.pnHumidity.Controls.Add(this.label5);
            this.pnHumidity.Controls.Add(this.txtHumidity);
            this.pnHumidity.Location = new System.Drawing.Point(266, 3);
            this.pnHumidity.Name = "pnHumidity";
            this.pnHumidity.Size = new System.Drawing.Size(257, 88);
            this.pnHumidity.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 25);
            this.label5.TabIndex = 35;
            this.label5.Text = "% ความชื่น";
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
            this.pnPowder.Controls.Add(this.label6);
            this.pnPowder.Controls.Add(this.txtPowder);
            this.pnPowder.Location = new System.Drawing.Point(529, 3);
            this.pnPowder.Name = "pnPowder";
            this.pnPowder.Size = new System.Drawing.Size(257, 88);
            this.pnPowder.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 25);
            this.label6.TabIndex = 36;
            this.label6.Text = "% แป้ง";
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
            this.btnCancelWeight.Location = new System.Drawing.Point(596, 478);
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
            this.btnSave.Location = new System.Drawing.Point(394, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(196, 36);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "บันทึกชั่งเข้า";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tmCheckWeight
            // 
            this.tmCheckWeight.Interval = 5000;
            this.tmCheckWeight.Tick += new System.EventHandler(this.tmCheckWeight_Tick);
            // 
            // lblScaleName
            // 
            this.lblScaleName.AutoSize = true;
            this.lblScaleName.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblScaleName.ForeColor = System.Drawing.Color.DarkGray;
            this.lblScaleName.Location = new System.Drawing.Point(10, 68);
            this.lblScaleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScaleName.Name = "lblScaleName";
            this.lblScaleName.Size = new System.Drawing.Size(92, 33);
            this.lblScaleName.TabIndex = 25;
            this.lblScaleName.Text = "เครื่องชั่ง";
            // 
            // frmWeightNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1445, 740);
            this.Controls.Add(this.lblScaleName);
            this.Controls.Add(this.pnText);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWeight);
            this.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmWeightNormal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWeightNormal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWeightNormal_FormClosing);
            this.Load += new System.EventHandler(this.frmWeightNormal_Load);
            this.guna2GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.pnText.ResumeLayout(false);
            this.pnText.PerformLayout();
            this.pnMainInformation.ResumeLayout(false);
            this.pnMainInformation.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnContaminants.ResumeLayout(false);
            this.pnContaminants.PerformLayout();
            this.pnHumidity.ResumeLayout(false);
            this.pnHumidity.PerformLayout();
            this.pnPowder.ResumeLayout(false);
            this.pnPowder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2MessageDialog msgD;
        private Bunifu.UI.WinForms.BunifuSnackbar msg;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort saPLC;
        private System.IO.Ports.SerialPort saScale;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvdata;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Panel pnText;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtPriceProduct;
        private Guna.UI2.WinForms.Guna2TextBox txtHumidity;
        private Guna.UI2.WinForms.Guna2TextBox txtOther;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cbbCustomer;
        private Guna.UI2.WinForms.Guna2ComboBox cbbProduct;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancelWeight;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtPowder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtContaminants;
        private System.Windows.Forms.Panel pnContaminants;
        private System.Windows.Forms.Panel pnHumidity;
        private System.Windows.Forms.Panel pnPowder;
        private System.Windows.Forms.Timer tmCheckWeight;
        private System.Windows.Forms.Label lblScaleName;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtLicenseTail;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtLicenseHead;
        private System.Windows.Forms.DataGridViewImageColumn cl_del;
        private System.Windows.Forms.DataGridViewImageColumn cl_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_customerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_productPrice;
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnMainInformation;
        private System.Windows.Forms.Label lblWeightIn;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
    }
}