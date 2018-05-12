namespace GUI
{
    partial class QuyDinh
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTuoiToiThieu = new System.Windows.Forms.TextBox();
            this.txtNoToiDa = new System.Windows.Forms.TextBox();
            this.txtSoLuongBanSi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTonToiThieu = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tuổi tối thiểu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nợ tối đa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số lượng bán sĩ";
            // 
            // txtTuoiToiThieu
            // 
            this.txtTuoiToiThieu.Location = new System.Drawing.Point(16, 46);
            this.txtTuoiToiThieu.Name = "txtTuoiToiThieu";
            this.txtTuoiToiThieu.Size = new System.Drawing.Size(100, 20);
            this.txtTuoiToiThieu.TabIndex = 1;
            // 
            // txtNoToiDa
            // 
            this.txtNoToiDa.Location = new System.Drawing.Point(16, 100);
            this.txtNoToiDa.Name = "txtNoToiDa";
            this.txtNoToiDa.Size = new System.Drawing.Size(100, 20);
            this.txtNoToiDa.TabIndex = 2;
            // 
            // txtSoLuongBanSi
            // 
            this.txtSoLuongBanSi.Location = new System.Drawing.Point(15, 154);
            this.txtSoLuongBanSi.Name = "txtSoLuongBanSi";
            this.txtSoLuongBanSi.Size = new System.Drawing.Size(100, 20);
            this.txtSoLuongBanSi.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tồn tối thiểu";
            // 
            // txtTonToiThieu
            // 
            this.txtTonToiThieu.Location = new System.Drawing.Point(16, 208);
            this.txtTonToiThieu.Name = "txtTonToiThieu";
            this.txtTonToiThieu.Size = new System.Drawing.Size(100, 20);
            this.txtTonToiThieu.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(180, 106);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 45);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // QuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 256);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTonToiThieu);
            this.Controls.Add(this.txtSoLuongBanSi);
            this.Controls.Add(this.txtNoToiDa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTuoiToiThieu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "QuyDinh";
            this.Text = "QuyDinh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTuoiToiThieu;
        private System.Windows.Forms.TextBox txtNoToiDa;
        private System.Windows.Forms.TextBox txtSoLuongBanSi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTonToiThieu;
        private System.Windows.Forms.Button btnOk;
    }
}