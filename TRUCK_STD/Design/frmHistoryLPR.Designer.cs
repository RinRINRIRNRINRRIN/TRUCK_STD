namespace TRUCK_STD.Design
{
    partial class frmHistoryLPR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistoryLPR));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.sb = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbWeightType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cbDate = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cbLicense = new Guna.UI2.WinForms.Guna2CheckBox();
            this.dtpStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpEnd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLicense = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvdata = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.cl_del = new System.Windows.Forms.DataGridViewImageColumn();
            this.cl_print = new System.Windows.Forms.DataGridViewImageColumn();
            this.cl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_dateRegistor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_licenseHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_licenseTail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_weightIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // sb
            // 
            this.sb.AllowDragging = false;
            this.sb.AllowMultipleViews = true;
            this.sb.ClickToClose = true;
            this.sb.DoubleClickToClose = true;
            this.sb.DurationAfterIdle = 3000;
            this.sb.ErrorOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sb.ErrorOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sb.ErrorOptions.ActionBorderRadius = 1;
            this.sb.ErrorOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sb.ErrorOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sb.ErrorOptions.BackColor = System.Drawing.Color.White;
            this.sb.ErrorOptions.BorderColor = System.Drawing.Color.White;
            this.sb.ErrorOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(199)))));
            this.sb.ErrorOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sb.ErrorOptions.ForeColor = System.Drawing.Color.Black;
            this.sb.ErrorOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon")));
            this.sb.ErrorOptions.IconLeftMargin = 12;
            this.sb.FadeCloseIcon = false;
            this.sb.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner;
            this.sb.InformationOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sb.InformationOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sb.InformationOptions.ActionBorderRadius = 1;
            this.sb.InformationOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sb.InformationOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sb.InformationOptions.BackColor = System.Drawing.Color.White;
            this.sb.InformationOptions.BorderColor = System.Drawing.Color.White;
            this.sb.InformationOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.sb.InformationOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sb.InformationOptions.ForeColor = System.Drawing.Color.Black;
            this.sb.InformationOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon1")));
            this.sb.InformationOptions.IconLeftMargin = 12;
            this.sb.Margin = 10;
            this.sb.MaximumSize = new System.Drawing.Size(0, 0);
            this.sb.MaximumViews = 7;
            this.sb.MessageRightMargin = 15;
            this.sb.MinimumSize = new System.Drawing.Size(0, 0);
            this.sb.ShowBorders = false;
            this.sb.ShowCloseIcon = false;
            this.sb.ShowIcon = true;
            this.sb.ShowShadows = true;
            this.sb.SuccessOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sb.SuccessOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sb.SuccessOptions.ActionBorderRadius = 1;
            this.sb.SuccessOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sb.SuccessOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sb.SuccessOptions.BackColor = System.Drawing.Color.White;
            this.sb.SuccessOptions.BorderColor = System.Drawing.Color.White;
            this.sb.SuccessOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(237)))));
            this.sb.SuccessOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sb.SuccessOptions.ForeColor = System.Drawing.Color.Black;
            this.sb.SuccessOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon2")));
            this.sb.SuccessOptions.IconLeftMargin = 12;
            this.sb.ViewsMargin = 7;
            this.sb.WarningOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sb.WarningOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sb.WarningOptions.ActionBorderRadius = 1;
            this.sb.WarningOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sb.WarningOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sb.WarningOptions.BackColor = System.Drawing.Color.White;
            this.sb.WarningOptions.BorderColor = System.Drawing.Color.White;
            this.sb.WarningOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(143)))));
            this.sb.WarningOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sb.WarningOptions.ForeColor = System.Drawing.Color.Black;
            this.sb.WarningOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon3")));
            this.sb.WarningOptions.IconLeftMargin = 12;
            this.sb.ZoomCloseIcon = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "ประวัติการชั่งเข้าและออกทั้งหมด";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Athiti SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "ประวัติการชั่ง";
            // 
            // cbbWeightType
            // 
            this.cbbWeightType.BackColor = System.Drawing.Color.Transparent;
            this.cbbWeightType.BorderColor = System.Drawing.Color.Maroon;
            this.cbbWeightType.BorderRadius = 3;
            this.cbbWeightType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbWeightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWeightType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbWeightType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbWeightType.Font = new System.Drawing.Font("Athiti", 12F);
            this.cbbWeightType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbWeightType.ItemHeight = 30;
            this.cbbWeightType.Items.AddRange(new object[] {
            "กำลังดำเนินการ",
            "ดำเนินการสำเร็จ"});
            this.cbbWeightType.Location = new System.Drawing.Point(12, 126);
            this.cbbWeightType.Name = "cbbWeightType";
            this.cbbWeightType.Size = new System.Drawing.Size(174, 36);
            this.cbbWeightType.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Animated = true;
            this.btnSearch.BorderRadius = 2;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor2 = System.Drawing.Color.Maroon;
            this.btnSearch.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.FillColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSearch.Location = new System.Drawing.Point(914, 128);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(145, 36);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "ค้นหารายการ";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbDate
            // 
            this.cbDate.Animated = true;
            this.cbDate.AutoSize = true;
            this.cbDate.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbDate.CheckedState.BorderRadius = 3;
            this.cbDate.CheckedState.BorderThickness = 0;
            this.cbDate.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbDate.Location = new System.Drawing.Point(202, 92);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(116, 29);
            this.cbDate.TabIndex = 15;
            this.cbDate.Text = "ค้นหาด้วยวันที่";
            this.cbDate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbDate.UncheckedState.BorderRadius = 3;
            this.cbDate.UncheckedState.BorderThickness = 0;
            this.cbDate.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // cbLicense
            // 
            this.cbLicense.Animated = true;
            this.cbLicense.AutoSize = true;
            this.cbLicense.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLicense.CheckedState.BorderRadius = 3;
            this.cbLicense.CheckedState.BorderThickness = 0;
            this.cbLicense.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLicense.Location = new System.Drawing.Point(693, 92);
            this.cbLicense.Name = "cbLicense";
            this.cbLicense.Size = new System.Drawing.Size(151, 29);
            this.cbLicense.TabIndex = 16;
            this.cbLicense.Text = "ค้นหาจากทะเบียนรถ";
            this.cbLicense.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbLicense.UncheckedState.BorderRadius = 3;
            this.cbLicense.UncheckedState.BorderThickness = 0;
            this.cbLicense.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // dtpStart
            // 
            this.dtpStart.BorderColor = System.Drawing.Color.Firebrick;
            this.dtpStart.BorderRadius = 3;
            this.dtpStart.BorderThickness = 1;
            this.dtpStart.Checked = true;
            this.dtpStart.FillColor = System.Drawing.Color.Brown;
            this.dtpStart.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.ForeColor = System.Drawing.Color.White;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpStart.Location = new System.Drawing.Point(235, 130);
            this.dtpStart.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStart.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 31);
            this.dtpStart.TabIndex = 17;
            this.dtpStart.Value = new System.DateTime(2024, 11, 13, 13, 17, 35, 467);
            // 
            // dtpEnd
            // 
            this.dtpEnd.BorderColor = System.Drawing.Color.Firebrick;
            this.dtpEnd.BorderRadius = 3;
            this.dtpEnd.BorderThickness = 1;
            this.dtpEnd.Checked = true;
            this.dtpEnd.FillColor = System.Drawing.Color.Brown;
            this.dtpEnd.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.ForeColor = System.Drawing.Color.White;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEnd.Location = new System.Drawing.Point(480, 131);
            this.dtpEnd.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEnd.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 31);
            this.dtpEnd.TabIndex = 18;
            this.dtpEnd.Value = new System.DateTime(2024, 11, 13, 13, 17, 35, 467);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(197, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "เริ่ม";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(441, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "ถึง";
            // 
            // txtLicense
            // 
            this.txtLicense.BorderColor = System.Drawing.Color.Maroon;
            this.txtLicense.BorderRadius = 3;
            this.txtLicense.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLicense.DefaultText = "";
            this.txtLicense.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLicense.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLicense.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicense.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicense.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicense.Location = new System.Drawing.Point(686, 127);
            this.txtLicense.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.PasswordChar = '\0';
            this.txtLicense.PlaceholderText = "เลขทะเบียนรถ";
            this.txtLicense.SelectedText = "";
            this.txtLicense.Size = new System.Drawing.Size(222, 36);
            this.txtLicense.TabIndex = 21;
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.ColumnHeadersHeight = 30;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_del,
            this.cl_print,
            this.cl_id,
            this.cl_dateRegistor,
            this.cl_job,
            this.cl_licenseHead,
            this.cl_licenseTail,
            this.cl_weightIn,
            this.cl_status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdata.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvdata.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvdata.Location = new System.Drawing.Point(12, 168);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersVisible = false;
            this.dgvdata.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvdata.RowTemplate.Height = 40;
            this.dgvdata.Size = new System.Drawing.Size(1047, 626);
            this.dgvdata.TabIndex = 10;
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
            this.dgvdata.ThemeStyle.RowsStyle.Height = 40;
            this.dgvdata.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvdata.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(1014, 4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 22;
            // 
            // msg
            // 
            this.msg.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msg.Caption = null;
            this.msg.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.msg.Parent = this;
            this.msg.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.msg.Text = null;
            // 
            // cl_del
            // 
            this.cl_del.HeaderText = "";
            this.cl_del.Image = ((System.Drawing.Image)(resources.GetObject("cl_del.Image")));
            this.cl_del.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.cl_del.Name = "cl_del";
            this.cl_del.ReadOnly = true;
            this.cl_del.Width = 50;
            // 
            // cl_print
            // 
            this.cl_print.HeaderText = "";
            this.cl_print.Image = ((System.Drawing.Image)(resources.GetObject("cl_print.Image")));
            this.cl_print.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.cl_print.Name = "cl_print";
            this.cl_print.ReadOnly = true;
            this.cl_print.Width = 50;
            // 
            // cl_id
            // 
            this.cl_id.DataPropertyName = "id";
            this.cl_id.HeaderText = "id";
            this.cl_id.Name = "cl_id";
            this.cl_id.ReadOnly = true;
            this.cl_id.Visible = false;
            // 
            // cl_dateRegistor
            // 
            this.cl_dateRegistor.DataPropertyName = "dateRegistor";
            this.cl_dateRegistor.HeaderText = "วันที่เวลา";
            this.cl_dateRegistor.Name = "cl_dateRegistor";
            this.cl_dateRegistor.ReadOnly = true;
            this.cl_dateRegistor.Width = 200;
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
            this.cl_licenseHead.Width = 150;
            // 
            // cl_licenseTail
            // 
            this.cl_licenseTail.DataPropertyName = "licenseTail";
            this.cl_licenseTail.HeaderText = "ทะเบียนหาง";
            this.cl_licenseTail.Name = "cl_licenseTail";
            this.cl_licenseTail.ReadOnly = true;
            this.cl_licenseTail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_licenseTail.Width = 150;
            // 
            // cl_weightIn
            // 
            this.cl_weightIn.DataPropertyName = "netWeight";
            this.cl_weightIn.HeaderText = "น้ำหนัก";
            this.cl_weightIn.Name = "cl_weightIn";
            this.cl_weightIn.ReadOnly = true;
            this.cl_weightIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_weightIn.Width = 150;
            // 
            // cl_status
            // 
            this.cl_status.DataPropertyName = "state";
            this.cl_status.HeaderText = "สถานะ";
            this.cl_status.Name = "cl_status";
            this.cl_status.ReadOnly = true;
            // 
            // frmHistoryLPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 806);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.cbLicense);
            this.Controls.Add(this.cbDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.cbbWeightType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmHistoryLPR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHistoryLPR";
            this.Load += new System.EventHandler(this.frmHistoryLPR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Bunifu.UI.WinForms.BunifuSnackbar sb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbbWeightType;
        private Guna.UI2.WinForms.Guna2GradientButton btnSearch;
        private Guna.UI2.WinForms.Guna2CheckBox cbDate;
        private Guna.UI2.WinForms.Guna2CheckBox cbLicense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEnd;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStart;
        private Guna.UI2.WinForms.Guna2TextBox txtLicense;
        private Guna.UI2.WinForms.Guna2DataGridView dgvdata;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2MessageDialog msg;
        private System.Windows.Forms.DataGridViewImageColumn cl_del;
        private System.Windows.Forms.DataGridViewImageColumn cl_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_dateRegistor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_licenseHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_licenseTail;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_weightIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_status;
    }
}