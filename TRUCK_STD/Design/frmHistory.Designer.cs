
namespace TRUCK_STD.Design
{
    partial class frmHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuSnackbar1 = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.dgvHireWeight = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cl_hire_print = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_hire_del = new System.Windows.Forms.DataGridViewImageColumn();
            this.cl_hire_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_hire_dateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_hire_timeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_hire_wgh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_hire_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_hire_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_hire_carnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpEnd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbbTable = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReload = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cbbSearchCar = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnPrintAllReport = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cbbSearchCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSearchDate = new System.Windows.Forms.CheckBox();
            this.cbbSearchProduct = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSearchProduct = new System.Windows.Forms.CheckBox();
            this.cbSearchCar = new System.Windows.Forms.CheckBox();
            this.cbSearchCustomer = new System.Windows.Forms.CheckBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHireWeight)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuSnackbar1
            // 
            this.bunifuSnackbar1.AllowDragging = false;
            this.bunifuSnackbar1.AllowMultipleViews = true;
            this.bunifuSnackbar1.ClickToClose = true;
            this.bunifuSnackbar1.DoubleClickToClose = true;
            this.bunifuSnackbar1.DurationAfterIdle = 3000;
            this.bunifuSnackbar1.ErrorOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.ErrorOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.ErrorOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.ErrorOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.ErrorOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.ErrorOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.ErrorOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.ErrorOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(199)))));
            this.bunifuSnackbar1.ErrorOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.ErrorOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.ErrorOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon")));
            this.bunifuSnackbar1.ErrorOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.FadeCloseIcon = false;
            this.bunifuSnackbar1.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner;
            this.bunifuSnackbar1.InformationOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.InformationOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.InformationOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.InformationOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.InformationOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.InformationOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.InformationOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.InformationOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.InformationOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.InformationOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.InformationOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon1")));
            this.bunifuSnackbar1.InformationOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.Margin = 10;
            this.bunifuSnackbar1.MaximumSize = new System.Drawing.Size(0, 0);
            this.bunifuSnackbar1.MaximumViews = 7;
            this.bunifuSnackbar1.MessageRightMargin = 15;
            this.bunifuSnackbar1.MinimumSize = new System.Drawing.Size(0, 0);
            this.bunifuSnackbar1.ShowBorders = false;
            this.bunifuSnackbar1.ShowCloseIcon = false;
            this.bunifuSnackbar1.ShowIcon = true;
            this.bunifuSnackbar1.ShowShadows = true;
            this.bunifuSnackbar1.SuccessOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.SuccessOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.SuccessOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.SuccessOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.SuccessOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.SuccessOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.SuccessOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.SuccessOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(237)))));
            this.bunifuSnackbar1.SuccessOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.SuccessOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.SuccessOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon2")));
            this.bunifuSnackbar1.SuccessOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.ViewsMargin = 7;
            this.bunifuSnackbar1.WarningOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.WarningOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuSnackbar1.WarningOptions.ActionBorderRadius = 1;
            this.bunifuSnackbar1.WarningOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.bunifuSnackbar1.WarningOptions.ActionForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.WarningOptions.BackColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.WarningOptions.BorderColor = System.Drawing.Color.White;
            this.bunifuSnackbar1.WarningOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(143)))));
            this.bunifuSnackbar1.WarningOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bunifuSnackbar1.WarningOptions.ForeColor = System.Drawing.Color.Black;
            this.bunifuSnackbar1.WarningOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon3")));
            this.bunifuSnackbar1.WarningOptions.IconLeftMargin = 12;
            this.bunifuSnackbar1.ZoomCloseIcon = true;
            // 
            // dgvHireWeight
            // 
            this.dgvHireWeight.AllowUserToAddRows = false;
            this.dgvHireWeight.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvHireWeight.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHireWeight.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvHireWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvHireWeight.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHireWeight.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHireWeight.ColumnHeadersHeight = 37;
            this.dgvHireWeight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvHireWeight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_hire_print,
            this.Column1,
            this.Column2,
            this.cl_hire_del,
            this.cl_hire_order,
            this.cl_hire_dateIn,
            this.cl_hire_timeIn,
            this.cl_hire_wgh,
            this.cl_hire_product,
            this.cl_hire_customer,
            this.cl_hire_carnumber});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHireWeight.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHireWeight.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHireWeight.Location = new System.Drawing.Point(251, 67);
            this.dgvHireWeight.Name = "dgvHireWeight";
            this.dgvHireWeight.ReadOnly = true;
            this.dgvHireWeight.RowHeadersVisible = false;
            this.dgvHireWeight.RowTemplate.Height = 40;
            this.dgvHireWeight.Size = new System.Drawing.Size(932, 699);
            this.dgvHireWeight.TabIndex = 76;
            this.dgvHireWeight.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHireWeight.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHireWeight.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHireWeight.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHireWeight.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHireWeight.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHireWeight.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHireWeight.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHireWeight.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHireWeight.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHireWeight.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHireWeight.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvHireWeight.ThemeStyle.HeaderStyle.Height = 37;
            this.dgvHireWeight.ThemeStyle.ReadOnly = true;
            this.dgvHireWeight.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHireWeight.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHireWeight.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Athiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHireWeight.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHireWeight.ThemeStyle.RowsStyle.Height = 40;
            this.dgvHireWeight.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHireWeight.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHireWeight.Visible = false;
            this.dgvHireWeight.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHireWeight_CellContentClick);
            // 
            // cl_hire_print
            // 
            this.cl_hire_print.HeaderText = "";
            this.cl_hire_print.Image = ((System.Drawing.Image)(resources.GetObject("cl_hire_print.Image")));
            this.cl_hire_print.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.cl_hire_print.Name = "cl_hire_print";
            this.cl_hire_print.ReadOnly = true;
            this.cl_hire_print.Width = 40;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "comcode";
            this.Column1.HeaderText = "comcode";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "typecode";
            this.Column2.HeaderText = "typecode";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // cl_hire_del
            // 
            this.cl_hire_del.HeaderText = "";
            this.cl_hire_del.Image = ((System.Drawing.Image)(resources.GetObject("cl_hire_del.Image")));
            this.cl_hire_del.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.cl_hire_del.Name = "cl_hire_del";
            this.cl_hire_del.ReadOnly = true;
            this.cl_hire_del.Width = 40;
            // 
            // cl_hire_order
            // 
            this.cl_hire_order.DataPropertyName = "ORDERNUM";
            this.cl_hire_order.HeaderText = "เลขที่ออเดอร์";
            this.cl_hire_order.Name = "cl_hire_order";
            this.cl_hire_order.ReadOnly = true;
            this.cl_hire_order.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl_hire_order.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_hire_order.Width = 200;
            // 
            // cl_hire_dateIn
            // 
            this.cl_hire_dateIn.DataPropertyName = "DATE_IN";
            this.cl_hire_dateIn.HeaderText = "วันที่ชั่งเข้า";
            this.cl_hire_dateIn.Name = "cl_hire_dateIn";
            this.cl_hire_dateIn.ReadOnly = true;
            this.cl_hire_dateIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl_hire_dateIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_hire_dateIn.Width = 180;
            // 
            // cl_hire_timeIn
            // 
            this.cl_hire_timeIn.DataPropertyName = "TIME_IN";
            this.cl_hire_timeIn.HeaderText = "เวลาที่ชั่งเข้า";
            this.cl_hire_timeIn.Name = "cl_hire_timeIn";
            this.cl_hire_timeIn.ReadOnly = true;
            this.cl_hire_timeIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl_hire_timeIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_hire_timeIn.Width = 180;
            // 
            // cl_hire_wgh
            // 
            this.cl_hire_wgh.DataPropertyName = "WG";
            this.cl_hire_wgh.HeaderText = "น้ำหนักรวม";
            this.cl_hire_wgh.Name = "cl_hire_wgh";
            this.cl_hire_wgh.ReadOnly = true;
            this.cl_hire_wgh.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl_hire_wgh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_hire_wgh.Width = 180;
            // 
            // cl_hire_product
            // 
            this.cl_hire_product.DataPropertyName = "typedesc";
            this.cl_hire_product.HeaderText = "ชื่อสินค้า";
            this.cl_hire_product.Name = "cl_hire_product";
            this.cl_hire_product.ReadOnly = true;
            this.cl_hire_product.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl_hire_product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_hire_product.Width = 180;
            // 
            // cl_hire_customer
            // 
            this.cl_hire_customer.DataPropertyName = "comdesc";
            this.cl_hire_customer.HeaderText = "ชื่อลูกค้า";
            this.cl_hire_customer.Name = "cl_hire_customer";
            this.cl_hire_customer.ReadOnly = true;
            this.cl_hire_customer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl_hire_customer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_hire_customer.Width = 180;
            // 
            // cl_hire_carnumber
            // 
            this.cl_hire_carnumber.DataPropertyName = "CARNUM_H";
            this.cl_hire_carnumber.HeaderText = "ทะเบียนรถ";
            this.cl_hire_carnumber.Name = "cl_hire_carnumber";
            this.cl_hire_carnumber.ReadOnly = true;
            this.cl_hire_carnumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl_hire_carnumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cl_hire_carnumber.Width = 180;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.cbbTable);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.guna2GradientButton1);
            this.panel1.Controls.Add(this.cbbSearchCar);
            this.panel1.Controls.Add(this.btnPrintAllReport);
            this.panel1.Controls.Add(this.cbbSearchCustomer);
            this.panel1.Controls.Add(this.cbSearchDate);
            this.panel1.Controls.Add(this.cbbSearchProduct);
            this.panel1.Controls.Add(this.cbSearchProduct);
            this.panel1.Controls.Add(this.cbSearchCar);
            this.panel1.Controls.Add(this.cbSearchCustomer);
            this.panel1.Location = new System.Drawing.Point(2, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 714);
            this.panel1.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Athiti SemiBold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 39);
            this.label1.TabIndex = 48;
            this.label1.Text = "ค้นหารายการ";
            // 
            // dtpStart
            // 
            this.dtpStart.BorderRadius = 6;
            this.dtpStart.Checked = true;
            this.dtpStart.Enabled = false;
            this.dtpStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(8, 172);
            this.dtpStart.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStart.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(220, 36);
            this.dtpStart.TabIndex = 50;
            this.dtpStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpStart.Value = new System.DateTime(2024, 1, 30, 13, 56, 28, 359);
            // 
            // dtpEnd
            // 
            this.dtpEnd.BorderRadius = 6;
            this.dtpEnd.Checked = true;
            this.dtpEnd.Enabled = false;
            this.dtpEnd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(8, 239);
            this.dtpEnd.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEnd.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(220, 36);
            this.dtpEnd.TabIndex = 52;
            this.dtpEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpEnd.Value = new System.DateTime(2024, 1, 30, 13, 56, 28, 359);
            // 
            // cbbTable
            // 
            this.cbbTable.BackColor = System.Drawing.Color.Transparent;
            this.cbbTable.BorderColor = System.Drawing.Color.Black;
            this.cbbTable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTable.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbTable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbTable.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTable.ForeColor = System.Drawing.Color.Black;
            this.cbbTable.ItemHeight = 30;
            this.cbbTable.Location = new System.Drawing.Point(15, 42);
            this.cbbTable.Name = "cbbTable";
            this.cbbTable.Size = new System.Drawing.Size(213, 36);
            this.cbbTable.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbbTable.TabIndex = 72;
            this.cbbTable.DropDown += new System.EventHandler(this.cbbTable_DropDown);
            this.cbbTable.DropDownClosed += new System.EventHandler(this.cbbTable_DropDownClosed);
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 6;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSearch.FillColor2 = System.Drawing.Color.Navy;
            this.btnSearch.Font = new System.Drawing.Font("Athiti", 11.25F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnSearch.Location = new System.Drawing.Point(10, 500);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(220, 40);
            this.btnSearch.TabIndex = 53;
            this.btnSearch.Text = "ค้นหารายการ";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 71;
            this.label3.Text = "วันที่สิ้นสุด";
            // 
            // btnReload
            // 
            this.btnReload.BorderRadius = 6;
            this.btnReload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReload.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReload.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btnReload.FillColor2 = System.Drawing.Color.Navy;
            this.btnReload.Font = new System.Drawing.Font("Athiti", 11.25F);
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btnReload.Location = new System.Drawing.Point(9, 610);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(220, 40);
            this.btnReload.TabIndex = 54;
            this.btnReload.Text = "รีโหลดข้อมูล";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 70;
            this.label2.Text = "วันทีเริ่มต้น";
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.BorderRadius = 6;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.SeaGreen;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.Green;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Athiti", 11.25F);
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.guna2GradientButton1.Location = new System.Drawing.Point(9, 659);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(220, 40);
            this.guna2GradientButton1.TabIndex = 55;
            this.guna2GradientButton1.Text = "Export Excel";
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // cbbSearchCar
            // 
            this.cbbSearchCar.BackColor = System.Drawing.Color.Transparent;
            this.cbbSearchCar.BorderColor = System.Drawing.Color.Black;
            this.cbbSearchCar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSearchCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchCar.Enabled = false;
            this.cbbSearchCar.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbSearchCar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbSearchCar.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSearchCar.ForeColor = System.Drawing.Color.Black;
            this.cbbSearchCar.ItemHeight = 30;
            this.cbbSearchCar.Location = new System.Drawing.Point(11, 458);
            this.cbbSearchCar.Name = "cbbSearchCar";
            this.cbbSearchCar.Size = new System.Drawing.Size(213, 36);
            this.cbbSearchCar.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbbSearchCar.TabIndex = 68;
            this.cbbSearchCar.DropDown += new System.EventHandler(this.cbbSearchCar_DropDown);
            this.cbbSearchCar.DropDownClosed += new System.EventHandler(this.cbbSearchCar_DropDownClosed);
            // 
            // btnPrintAllReport
            // 
            this.btnPrintAllReport.BorderRadius = 6;
            this.btnPrintAllReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrintAllReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrintAllReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrintAllReport.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrintAllReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrintAllReport.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPrintAllReport.FillColor2 = System.Drawing.Color.Navy;
            this.btnPrintAllReport.Font = new System.Drawing.Font("Athiti", 11.25F);
            this.btnPrintAllReport.ForeColor = System.Drawing.Color.White;
            this.btnPrintAllReport.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnPrintAllReport.Location = new System.Drawing.Point(9, 564);
            this.btnPrintAllReport.Name = "btnPrintAllReport";
            this.btnPrintAllReport.Size = new System.Drawing.Size(220, 40);
            this.btnPrintAllReport.TabIndex = 56;
            this.btnPrintAllReport.Text = "พิมพ์รายงานทั้งหมด";
            this.btnPrintAllReport.Click += new System.EventHandler(this.btnPrintAllReport_Click);
            // 
            // cbbSearchCustomer
            // 
            this.cbbSearchCustomer.BackColor = System.Drawing.Color.Transparent;
            this.cbbSearchCustomer.BorderColor = System.Drawing.Color.Black;
            this.cbbSearchCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSearchCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchCustomer.Enabled = false;
            this.cbbSearchCustomer.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbSearchCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbSearchCustomer.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSearchCustomer.ForeColor = System.Drawing.Color.Black;
            this.cbbSearchCustomer.ItemHeight = 30;
            this.cbbSearchCustomer.Location = new System.Drawing.Point(10, 387);
            this.cbbSearchCustomer.Name = "cbbSearchCustomer";
            this.cbbSearchCustomer.Size = new System.Drawing.Size(213, 36);
            this.cbbSearchCustomer.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbbSearchCustomer.TabIndex = 67;
            this.cbbSearchCustomer.DropDown += new System.EventHandler(this.cbbSearchCustomer_DropDown);
            this.cbbSearchCustomer.DropDownClosed += new System.EventHandler(this.cbbSearchCustomer_DropDownClosed);
            // 
            // cbSearchDate
            // 
            this.cbSearchDate.AutoSize = true;
            this.cbSearchDate.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchDate.ForeColor = System.Drawing.Color.Black;
            this.cbSearchDate.Location = new System.Drawing.Point(17, 112);
            this.cbSearchDate.Name = "cbSearchDate";
            this.cbSearchDate.Size = new System.Drawing.Size(113, 29);
            this.cbSearchDate.TabIndex = 59;
            this.cbSearchDate.Text = "ค้นหาจากวันที่";
            this.cbSearchDate.UseVisualStyleBackColor = true;
            this.cbSearchDate.CheckedChanged += new System.EventHandler(this.cbSearchDate_CheckedChanged);
            // 
            // cbbSearchProduct
            // 
            this.cbbSearchProduct.BackColor = System.Drawing.Color.Transparent;
            this.cbbSearchProduct.BorderColor = System.Drawing.Color.Black;
            this.cbbSearchProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbSearchProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchProduct.Enabled = false;
            this.cbbSearchProduct.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbSearchProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbSearchProduct.Font = new System.Drawing.Font("Athiti", 12F);
            this.cbbSearchProduct.ForeColor = System.Drawing.Color.Black;
            this.cbbSearchProduct.ItemHeight = 30;
            this.cbbSearchProduct.Location = new System.Drawing.Point(11, 318);
            this.cbbSearchProduct.Name = "cbbSearchProduct";
            this.cbbSearchProduct.Size = new System.Drawing.Size(213, 36);
            this.cbbSearchProduct.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbbSearchProduct.TabIndex = 66;
            this.cbbSearchProduct.DropDown += new System.EventHandler(this.cbbSearchProduct_DropDown);
            this.cbbSearchProduct.DropDownClosed += new System.EventHandler(this.cbbSearchProduct_DropDownClosed);
            // 
            // cbSearchProduct
            // 
            this.cbSearchProduct.AutoSize = true;
            this.cbSearchProduct.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchProduct.ForeColor = System.Drawing.Color.Black;
            this.cbSearchProduct.Location = new System.Drawing.Point(18, 294);
            this.cbSearchProduct.Name = "cbSearchProduct";
            this.cbSearchProduct.Size = new System.Drawing.Size(136, 29);
            this.cbSearchProduct.TabIndex = 60;
            this.cbSearchProduct.Text = "ค้นหาจากชื่อสินค้า";
            this.cbSearchProduct.UseVisualStyleBackColor = true;
            this.cbSearchProduct.CheckedChanged += new System.EventHandler(this.cbSearchProduct_CheckedChanged);
            // 
            // cbSearchCar
            // 
            this.cbSearchCar.AutoSize = true;
            this.cbSearchCar.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchCar.ForeColor = System.Drawing.Color.Black;
            this.cbSearchCar.Location = new System.Drawing.Point(15, 429);
            this.cbSearchCar.Name = "cbSearchCar";
            this.cbSearchCar.Size = new System.Drawing.Size(151, 29);
            this.cbSearchCar.TabIndex = 62;
            this.cbSearchCar.Text = "ค้นหาจากทะเบียนรถ";
            this.cbSearchCar.UseVisualStyleBackColor = true;
            this.cbSearchCar.CheckedChanged += new System.EventHandler(this.cbSearchCar_CheckedChanged);
            // 
            // cbSearchCustomer
            // 
            this.cbSearchCustomer.AutoSize = true;
            this.cbSearchCustomer.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchCustomer.ForeColor = System.Drawing.Color.Black;
            this.cbSearchCustomer.Location = new System.Drawing.Point(18, 363);
            this.cbSearchCustomer.Name = "cbSearchCustomer";
            this.cbSearchCustomer.Size = new System.Drawing.Size(135, 29);
            this.cbSearchCustomer.TabIndex = 61;
            this.cbSearchCustomer.Text = "ค้นหาจากชื่อลูกค้า";
            this.cbSearchCustomer.UseVisualStyleBackColor = true;
            this.cbSearchCustomer.CheckedChanged += new System.EventHandler(this.cbSearchCustomer_CheckedChanged);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Athiti SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.label4.Location = new System.Drawing.Point(2, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 46);
            this.label4.TabIndex = 77;
            this.label4.Text = "ประวัติการชั่งทั้งหมด";
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 793);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvHireWeight);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Athiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHistory";
            this.Load += new System.EventHandler(this.frmHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHireWeight)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuSnackbar bunifuSnackbar1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEnd;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStart;
        private Guna.UI2.WinForms.Guna2GradientButton btnSearch;
        private Guna.UI2.WinForms.Guna2GradientButton btnReload;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2GradientButton btnPrintAllReport;
        private System.Windows.Forms.CheckBox cbSearchDate;
        private System.Windows.Forms.CheckBox cbSearchCar;
        private System.Windows.Forms.CheckBox cbSearchCustomer;
        private System.Windows.Forms.CheckBox cbSearchProduct;
        private Guna.UI2.WinForms.Guna2ComboBox cbbSearchProduct;
        private Guna.UI2.WinForms.Guna2ComboBox cbbSearchCar;
        private Guna.UI2.WinForms.Guna2ComboBox cbbSearchCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbbTable;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHireWeight;
        private System.Windows.Forms.DataGridViewImageColumn cl_hire_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn cl_hire_del;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_hire_order;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_hire_dateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_hire_timeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_hire_wgh;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_hire_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_hire_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_hire_carnumber;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label4;
    }
}