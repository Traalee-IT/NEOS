
namespace QuanLyKhuTro.View
{
    partial class InformationAccount
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
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.iconEye = new FontAwesome.Sharp.IconButton();
            this.iconEye1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.ForeColor = System.Drawing.Color.DarkGray;
            this.txtFullName.Location = new System.Drawing.Point(270, 147);
            this.txtFullName.MaxLength = 20;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(283, 36);
            this.txtFullName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(121, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 35);
            this.label1.TabIndex = 12;
            this.label1.Text = "THÔNG TIN TÀI KHOẢN ĐĂNG NHẬP";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPass.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOldPass.Location = new System.Drawing.Point(270, 209);
            this.txtOldPass.MaxLength = 20;
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(283, 36);
            this.txtOldPass.TabIndex = 13;
            this.txtOldPass.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNewPass.Location = new System.Drawing.Point(270, 273);
            this.txtNewPass.MaxLength = 20;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(283, 36);
            this.txtNewPass.TabIndex = 14;
            this.txtNewPass.UseSystemPasswordChar = true;
            this.txtNewPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Họ tên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 26);
            this.label4.TabIndex = 17;
            this.label4.Text = "Mật khẩu cũ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 26);
            this.label5.TabIndex = 18;
            this.label5.Text = "Mật khẩu mới:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(265, 97);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(82, 27);
            this.lbUserName.TabIndex = 19;
            this.lbUserName.Text = "abc123";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightCoral;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(419, 386);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(156, 42);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // iconEye
            // 
            this.iconEye.FlatAppearance.BorderSize = 0;
            this.iconEye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.iconEye.IconColor = System.Drawing.Color.Black;
            this.iconEye.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconEye.IconSize = 30;
            this.iconEye.Location = new System.Drawing.Point(559, 216);
            this.iconEye.Name = "iconEye";
            this.iconEye.Size = new System.Drawing.Size(45, 29);
            this.iconEye.TabIndex = 21;
            this.iconEye.Text = "   ";
            this.iconEye.UseVisualStyleBackColor = true;
            this.iconEye.Click += new System.EventHandler(this.iconEye_Click);
            // 
            // iconEye1
            // 
            this.iconEye1.FlatAppearance.BorderSize = 0;
            this.iconEye1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconEye1.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.iconEye1.IconColor = System.Drawing.Color.Black;
            this.iconEye1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconEye1.IconSize = 30;
            this.iconEye1.Location = new System.Drawing.Point(559, 280);
            this.iconEye1.Name = "iconEye1";
            this.iconEye1.Size = new System.Drawing.Size(45, 29);
            this.iconEye1.TabIndex = 22;
            this.iconEye1.Text = "   ";
            this.iconEye1.UseVisualStyleBackColor = true;
            // 
            // InformationAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(648, 464);
            this.Controls.Add(this.iconEye1);
            this.Controls.Add(this.iconEye);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFullName);
            this.Name = "InformationAccount";
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.InformationAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Button btnUpdate;
        private FontAwesome.Sharp.IconButton iconEye;
        private FontAwesome.Sharp.IconButton iconEye1;
    }
}