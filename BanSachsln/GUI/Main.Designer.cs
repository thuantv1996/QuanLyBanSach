namespace GUI
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNhaXuatBan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTheLoai = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSach = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemKho = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNhapKho = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTonKho = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCongNo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemKhac = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemKhuyenMai = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuyDinh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTKNV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDanhMuc,
            this.menuItemKho,
            this.menuItemBanHang,
            this.menuItemBaoCao,
            this.menuItemKhac,
            this.menuItemLogout});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(801, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuItemDanhMuc
            // 
            this.menuItemDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNhaXuatBan,
            this.menuItemTheLoai,
            this.menuItemSach});
            this.menuItemDanhMuc.Name = "menuItemDanhMuc";
            this.menuItemDanhMuc.Size = new System.Drawing.Size(74, 20);
            this.menuItemDanhMuc.Text = "Danh mục";
            // 
            // menuItemNhaXuatBan
            // 
            this.menuItemNhaXuatBan.Name = "menuItemNhaXuatBan";
            this.menuItemNhaXuatBan.Size = new System.Drawing.Size(144, 22);
            this.menuItemNhaXuatBan.Text = "Nhà xuất bản";
            this.menuItemNhaXuatBan.Click += new System.EventHandler(this.menuItemNhaXuatBan_Click);
            // 
            // menuItemTheLoai
            // 
            this.menuItemTheLoai.Name = "menuItemTheLoai";
            this.menuItemTheLoai.Size = new System.Drawing.Size(144, 22);
            this.menuItemTheLoai.Text = "Thể loại";
            this.menuItemTheLoai.Click += new System.EventHandler(this.menuItemTheLoai_Click);
            // 
            // menuItemSach
            // 
            this.menuItemSach.Name = "menuItemSach";
            this.menuItemSach.Size = new System.Drawing.Size(144, 22);
            this.menuItemSach.Text = "Sách";
            this.menuItemSach.Click += new System.EventHandler(this.menuItemSach_Click);
            // 
            // menuItemKho
            // 
            this.menuItemKho.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNhapKho});
            this.menuItemKho.Name = "menuItemKho";
            this.menuItemKho.Size = new System.Drawing.Size(40, 20);
            this.menuItemKho.Text = "Kho";
            // 
            // menuItemNhapKho
            // 
            this.menuItemNhapKho.Name = "menuItemNhapKho";
            this.menuItemNhapKho.Size = new System.Drawing.Size(126, 22);
            this.menuItemNhapKho.Text = "Nhập kho";
            this.menuItemNhapKho.Click += new System.EventHandler(this.menuItemNhapKho_Click);
            // 
            // menuItemBanHang
            // 
            this.menuItemBanHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kháchHàngToolStripMenuItem,
            this.menuItemHoaDon,
            this.menuItemThanhToan});
            this.menuItemBanHang.Name = "menuItemBanHang";
            this.menuItemBanHang.Size = new System.Drawing.Size(69, 20);
            this.menuItemBanHang.Text = "Bán hàng";
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // menuItemHoaDon
            // 
            this.menuItemHoaDon.Name = "menuItemHoaDon";
            this.menuItemHoaDon.Size = new System.Drawing.Size(137, 22);
            this.menuItemHoaDon.Text = "Bán hàng";
            this.menuItemHoaDon.Click += new System.EventHandler(this.menuItemHoaDon_Click);
            // 
            // menuItemThanhToan
            // 
            this.menuItemThanhToan.Name = "menuItemThanhToan";
            this.menuItemThanhToan.Size = new System.Drawing.Size(137, 22);
            this.menuItemThanhToan.Text = "Thanh toán";
            this.menuItemThanhToan.Click += new System.EventHandler(this.menuItemThanhToan_Click);
            // 
            // menuItemBaoCao
            // 
            this.menuItemBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemTonKho,
            this.menuItemCongNo});
            this.menuItemBaoCao.Name = "menuItemBaoCao";
            this.menuItemBaoCao.Size = new System.Drawing.Size(61, 20);
            this.menuItemBaoCao.Text = "Báo cáo";
            // 
            // menuItemTonKho
            // 
            this.menuItemTonKho.Name = "menuItemTonKho";
            this.menuItemTonKho.Size = new System.Drawing.Size(120, 22);
            this.menuItemTonKho.Text = "Tồn kho";
            this.menuItemTonKho.Click += new System.EventHandler(this.menuItemTonKho_Click);
            // 
            // menuItemCongNo
            // 
            this.menuItemCongNo.Name = "menuItemCongNo";
            this.menuItemCongNo.Size = new System.Drawing.Size(120, 22);
            this.menuItemCongNo.Text = "Công nợ";
            this.menuItemCongNo.Click += new System.EventHandler(this.menuItemCongNo_Click);
            // 
            // menuItemKhac
            // 
            this.menuItemKhac.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemKhuyenMai,
            this.menuItemQuyDinh,
            this.menuItemNhanVien,
            this.menuItemTKNV});
            this.menuItemKhac.Name = "menuItemKhac";
            this.menuItemKhac.Size = new System.Drawing.Size(45, 20);
            this.menuItemKhac.Text = "Khác";
            // 
            // menuItemKhuyenMai
            // 
            this.menuItemKhuyenMai.Name = "menuItemKhuyenMai";
            this.menuItemKhuyenMai.Size = new System.Drawing.Size(145, 22);
            this.menuItemKhuyenMai.Text = "Khuyến mãi";
            this.menuItemKhuyenMai.Click += new System.EventHandler(this.menuItemKhuyenMai_Click);
            // 
            // menuItemQuyDinh
            // 
            this.menuItemQuyDinh.Name = "menuItemQuyDinh";
            this.menuItemQuyDinh.Size = new System.Drawing.Size(145, 22);
            this.menuItemQuyDinh.Text = "Quy định";
            this.menuItemQuyDinh.Click += new System.EventHandler(this.menuItemQuyDinh_Click);
            // 
            // menuItemNhanVien
            // 
            this.menuItemNhanVien.Name = "menuItemNhanVien";
            this.menuItemNhanVien.Size = new System.Drawing.Size(145, 22);
            this.menuItemNhanVien.Text = "Nhân viên";
            this.menuItemNhanVien.Click += new System.EventHandler(this.menuItemNhanVien_Click);
            // 
            // menuItemTKNV
            // 
            this.menuItemTKNV.Name = "menuItemTKNV";
            this.menuItemTKNV.Size = new System.Drawing.Size(145, 22);
            this.menuItemTKNV.Text = "Tài khoản NV";
            this.menuItemTKNV.Click += new System.EventHandler(this.menuItemTKNV_Click);
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Name = "menuItemLogout";
            this.menuItemLogout.Size = new System.Drawing.Size(57, 20);
            this.menuItemLogout.Text = "Logout";
            this.menuItemLogout.Click += new System.EventHandler(this.menuItemLogout_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainPanel.BackgroundImage")));
            this.MainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MainPanel.Location = new System.Drawing.Point(0, 27);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(801, 633);
            this.MainPanel.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 662);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem menuItemNhaXuatBan;
        private System.Windows.Forms.ToolStripMenuItem menuItemTheLoai;
        private System.Windows.Forms.ToolStripMenuItem menuItemSach;
        private System.Windows.Forms.ToolStripMenuItem menuItemKho;
        private System.Windows.Forms.ToolStripMenuItem menuItemNhapKho;
        private System.Windows.Forms.ToolStripMenuItem menuItemBanHang;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemHoaDon;
        private System.Windows.Forms.ToolStripMenuItem menuItemBaoCao;
        private System.Windows.Forms.ToolStripMenuItem menuItemTonKho;
        private System.Windows.Forms.ToolStripMenuItem menuItemCongNo;
        private System.Windows.Forms.ToolStripMenuItem menuItemKhac;
        private System.Windows.Forms.ToolStripMenuItem menuItemKhuyenMai;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuyDinh;
        private System.Windows.Forms.ToolStripMenuItem menuItemNhanVien;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogout;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStripMenuItem menuItemTKNV;
        private System.Windows.Forms.ToolStripMenuItem menuItemThanhToan;
    }
}