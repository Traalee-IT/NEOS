
namespace QuanLyKhuTro.View
{
    partial class RoomManagerForm
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
            this.main = new System.Windows.Forms.TableLayoutPanel();
            this.containerLeft = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.leftTop = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutRoom = new System.Windows.Forms.FlowLayoutPanel();
            this.containerRight = new System.Windows.Forms.TableLayoutPanel();
            this.gridViewMember = new System.Windows.Forms.DataGridView();
            this.checkBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.containerFunction = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLichSuThanhToan = new System.Windows.Forms.Button();
            this.btnRemoveMember = new System.Windows.Forms.Button();
            this.btnQlDichVu = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nbDienTich = new System.Windows.Forms.NumericUpDown();
            this.nbPrice = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbListStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameRoom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdRoom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.main.SuspendLayout();
            this.containerLeft.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.leftTop.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.containerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMember)).BeginInit();
            this.containerFunction.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbDienTich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // main
            // 
            this.main.ColumnCount = 2;
            this.main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.62017F));
            this.main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.37983F));
            this.main.Controls.Add(this.containerLeft, 0, 0);
            this.main.Controls.Add(this.containerRight, 1, 0);
            this.main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main.Location = new System.Drawing.Point(0, 0);
            this.main.Name = "main";
            this.main.RowCount = 1;
            this.main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.main.Size = new System.Drawing.Size(1527, 726);
            this.main.TabIndex = 0;
            // 
            // containerLeft
            // 
            this.containerLeft.ColumnCount = 1;
            this.containerLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.containerLeft.Controls.Add(this.groupBoxSearch, 0, 1);
            this.containerLeft.Controls.Add(this.leftTop, 0, 0);
            this.containerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.containerLeft.Location = new System.Drawing.Point(3, 3);
            this.containerLeft.Name = "containerLeft";
            this.containerLeft.RowCount = 2;
            this.containerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.5F));
            this.containerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.containerLeft.Size = new System.Drawing.Size(599, 720);
            this.containerLeft.TabIndex = 0;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.BackColor = System.Drawing.Color.Snow;
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.txtSearch);
            this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxSearch.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSearch.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBoxSearch.Location = new System.Drawing.Point(3, 637);
            this.groupBoxSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSearch.Size = new System.Drawing.Size(593, 81);
            this.groupBoxSearch.TabIndex = 5;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Tìm kiếm phòng";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::QuanLyKhuTro.Properties.Resources.icons8_search_24;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(305, 23);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSearch.Size = new System.Drawing.Size(97, 46);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(53, 32);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(247, 33);
            this.txtSearch.TabIndex = 0;
            // 
            // leftTop
            // 
            this.leftTop.ColumnCount = 1;
            this.leftTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftTop.Controls.Add(this.panelHeader, 0, 0);
            this.leftTop.Controls.Add(this.panel1, 0, 1);
            this.leftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTop.Location = new System.Drawing.Point(3, 3);
            this.leftTop.Name = "leftTop";
            this.leftTop.RowCount = 2;
            this.leftTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.leftTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftTop.Size = new System.Drawing.Size(593, 624);
            this.leftTop.TabIndex = 6;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(3, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(587, 106);
            this.panelHeader.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(185, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANH SÁCH PHÒNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackgroundImage = global::QuanLyKhuTro.Properties.Resources.icons8_home_60;
            this.pictureBox1.Location = new System.Drawing.Point(118, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tomato;
            this.panel1.Controls.Add(this.flowLayoutRoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 506);
            this.panel1.TabIndex = 10;
            // 
            // flowLayoutRoom
            // 
            this.flowLayoutRoom.AutoScroll = true;
            this.flowLayoutRoom.BackColor = System.Drawing.Color.FloralWhite;
            this.flowLayoutRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flowLayoutRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutRoom.ForeColor = System.Drawing.Color.DarkRed;
            this.flowLayoutRoom.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutRoom.Name = "flowLayoutRoom";
            this.flowLayoutRoom.Size = new System.Drawing.Size(587, 506);
            this.flowLayoutRoom.TabIndex = 10;
            // 
            // containerRight
            // 
            this.containerRight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.containerRight.ColumnCount = 1;
            this.containerRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.containerRight.Controls.Add(this.gridViewMember, 0, 1);
            this.containerRight.Controls.Add(this.containerFunction, 0, 0);
            this.containerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerRight.Location = new System.Drawing.Point(608, 3);
            this.containerRight.Name = "containerRight";
            this.containerRight.RowCount = 2;
            this.containerRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.02778F));
            this.containerRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.97222F));
            this.containerRight.Size = new System.Drawing.Size(916, 720);
            this.containerRight.TabIndex = 1;
            // 
            // gridViewMember
            // 
            this.gridViewMember.AllowUserToAddRows = false;
            this.gridViewMember.BackgroundColor = System.Drawing.Color.Snow;
            this.gridViewMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkBoxColumn});
            this.gridViewMember.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridViewMember.Location = new System.Drawing.Point(3, 535);
            this.gridViewMember.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridViewMember.Name = "gridViewMember";
            this.gridViewMember.RowHeadersWidth = 51;
            this.gridViewMember.RowTemplate.Height = 24;
            this.gridViewMember.Size = new System.Drawing.Size(910, 183);
            this.gridViewMember.TabIndex = 4;
            this.gridViewMember.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewMember_CellValueChanged);
            // 
            // checkBoxColumn
            // 
            this.checkBoxColumn.HeaderText = "Chọn";
            this.checkBoxColumn.MinimumWidth = 6;
            this.checkBoxColumn.Name = "checkBoxColumn";
            this.checkBoxColumn.Width = 55;
            // 
            // containerFunction
            // 
            this.containerFunction.BackColor = System.Drawing.SystemColors.Control;
            this.containerFunction.ColumnCount = 1;
            this.containerFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.containerFunction.Controls.Add(this.groupBox4, 0, 1);
            this.containerFunction.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.containerFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerFunction.Location = new System.Drawing.Point(3, 3);
            this.containerFunction.Name = "containerFunction";
            this.containerFunction.RowCount = 2;
            this.containerFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.16319F));
            this.containerFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.83681F));
            this.containerFunction.Size = new System.Drawing.Size(910, 527);
            this.containerFunction.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.btnLichSuThanhToan);
            this.groupBox4.Controls.Add(this.btnRemoveMember);
            this.groupBox4.Controls.Add(this.btnQlDichVu);
            this.groupBox4.Controls.Add(this.btnThanhToan);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 435);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(904, 90);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dịch vụ";
            // 
            // btnLichSuThanhToan
            // 
            this.btnLichSuThanhToan.Enabled = false;
            this.btnLichSuThanhToan.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSuThanhToan.Image = global::QuanLyKhuTro.Properties.Resources.icons8_payment_24;
            this.btnLichSuThanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichSuThanhToan.Location = new System.Drawing.Point(401, 31);
            this.btnLichSuThanhToan.Margin = new System.Windows.Forms.Padding(11, 0, 15, 0);
            this.btnLichSuThanhToan.Name = "btnLichSuThanhToan";
            this.btnLichSuThanhToan.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLichSuThanhToan.Size = new System.Drawing.Size(229, 50);
            this.btnLichSuThanhToan.TabIndex = 10;
            this.btnLichSuThanhToan.Text = "Lịch sử thanh toán";
            this.btnLichSuThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLichSuThanhToan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLichSuThanhToan.UseVisualStyleBackColor = true;
            this.btnLichSuThanhToan.Click += new System.EventHandler(this.btnLichSuThanhToan_Click);
            // 
            // btnRemoveMember
            // 
            this.btnRemoveMember.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRemoveMember.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveMember.Image = global::QuanLyKhuTro.Properties.Resources.icons8_delete_24;
            this.btnRemoveMember.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveMember.Location = new System.Drawing.Point(675, 30);
            this.btnRemoveMember.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveMember.Name = "btnRemoveMember";
            this.btnRemoveMember.Padding = new System.Windows.Forms.Padding(10, 0, 19, 0);
            this.btnRemoveMember.Size = new System.Drawing.Size(208, 50);
            this.btnRemoveMember.TabIndex = 11;
            this.btnRemoveMember.Text = "Xóa thành viên";
            this.btnRemoveMember.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveMember.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveMember.UseVisualStyleBackColor = true;
            this.btnRemoveMember.Visible = false;
            this.btnRemoveMember.Click += new System.EventHandler(this.btnRemoveMember_Click_1);
            // 
            // btnQlDichVu
            // 
            this.btnQlDichVu.Enabled = false;
            this.btnQlDichVu.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlDichVu.Image = global::QuanLyKhuTro.Properties.Resources.icons8_add_24;
            this.btnQlDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQlDichVu.Location = new System.Drawing.Point(228, 31);
            this.btnQlDichVu.Margin = new System.Windows.Forms.Padding(11, 0, 15, 0);
            this.btnQlDichVu.Name = "btnQlDichVu";
            this.btnQlDichVu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQlDichVu.Size = new System.Drawing.Size(145, 50);
            this.btnQlDichVu.TabIndex = 9;
            this.btnQlDichVu.Text = "Dịch vụ";
            this.btnQlDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQlDichVu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQlDichVu.UseVisualStyleBackColor = true;
            this.btnQlDichVu.Click += new System.EventHandler(this.btnQlDichVu_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Enabled = false;
            this.btnThanhToan.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Image = global::QuanLyKhuTro.Properties.Resources.icons8_payment_24;
            this.btnThanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThanhToan.Location = new System.Drawing.Point(37, 31);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(11, 0, 15, 0);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThanhToan.Size = new System.Drawing.Size(160, 50);
            this.btnThanhToan.TabIndex = 8;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThanhToan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.58407F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.41593F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(904, 427);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.btnRemove);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(622, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(279, 423);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::QuanLyKhuTro.Properties.Resources.icons8_restart_24;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(43, 262);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5, 0, 20, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnRefresh.Size = new System.Drawing.Size(131, 50);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::QuanLyKhuTro.Properties.Resources.updated;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(43, 111);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(11, 0, 19, 0);
            this.btnUpdate.Size = new System.Drawing.Size(131, 50);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::QuanLyKhuTro.Properties.Resources.icons8_delete_24;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(43, 183);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Padding = new System.Windows.Forms.Padding(11, 0, 19, 0);
            this.btnRemove.Size = new System.Drawing.Size(131, 50);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::QuanLyKhuTro.Properties.Resources.icons8_add_24;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(43, 38);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.btnAdd.Size = new System.Drawing.Size(131, 50);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.nbDienTich);
            this.groupBox2.Controls.Add(this.nbPrice);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbListStatus);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNameRoom);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtIdRoom);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(613, 423);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(363, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 22);
            this.label8.TabIndex = 14;
            this.label8.Text = "đồng";
            // 
            // nbDienTich
            // 
            this.nbDienTich.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbDienTich.Location = new System.Drawing.Point(157, 225);
            this.nbDienTich.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nbDienTich.Name = "nbDienTich";
            this.nbDienTich.Size = new System.Drawing.Size(120, 33);
            this.nbDienTich.TabIndex = 2;
            // 
            // nbPrice
            // 
            this.nbPrice.DecimalPlaces = 2;
            this.nbPrice.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbPrice.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nbPrice.Location = new System.Drawing.Point(157, 175);
            this.nbPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nbPrice.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nbPrice.Name = "nbPrice";
            this.nbPrice.Size = new System.Drawing.Size(197, 33);
            this.nbPrice.TabIndex = 1;
            this.nbPrice.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(285, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "m2";
            // 
            // cbListStatus
            // 
            this.cbListStatus.DropDownHeight = 100;
            this.cbListStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListStatus.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListStatus.FormattingEnabled = true;
            this.cbListStatus.IntegralHeight = false;
            this.cbListStatus.ItemHeight = 25;
            this.cbListStatus.Location = new System.Drawing.Point(157, 276);
            this.cbListStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbListStatus.Name = "cbListStatus";
            this.cbListStatus.Size = new System.Drawing.Size(143, 33);
            this.cbListStatus.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Trạng thái:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Diện tích:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giá phòng:";
            // 
            // txtNameRoom
            // 
            this.txtNameRoom.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameRoom.Location = new System.Drawing.Point(157, 124);
            this.txtNameRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNameRoom.Name = "txtNameRoom";
            this.txtNameRoom.Size = new System.Drawing.Size(231, 33);
            this.txtNameRoom.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên phòng:";
            // 
            // txtIdRoom
            // 
            this.txtIdRoom.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdRoom.Location = new System.Drawing.Point(157, 74);
            this.txtIdRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdRoom.Name = "txtIdRoom";
            this.txtIdRoom.ReadOnly = true;
            this.txtIdRoom.Size = new System.Drawing.Size(151, 33);
            this.txtIdRoom.TabIndex = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã phòng:";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            // 
            // RoomManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1527, 726);
            this.Controls.Add(this.main);
            this.Name = "RoomManagerForm";
            this.Text = "Quản lý phòng";
            this.Load += new System.EventHandler(this.RoomManagerForm_Load);
            this.main.ResumeLayout(false);
            this.containerLeft.ResumeLayout(false);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.leftTop.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.containerRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMember)).EndInit();
            this.containerFunction.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbDienTich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main;
        private System.Windows.Forms.TableLayoutPanel containerLeft;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TableLayoutPanel leftTop;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutRoom;
        private System.Windows.Forms.TableLayoutPanel containerRight;
        private System.Windows.Forms.DataGridView gridViewMember;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkBoxColumn;
        private System.Windows.Forms.TableLayoutPanel containerFunction;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLichSuThanhToan;
        private System.Windows.Forms.Button btnQlDichVu;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnRemoveMember;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nbDienTich;
        private System.Windows.Forms.NumericUpDown nbPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbListStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNameRoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}