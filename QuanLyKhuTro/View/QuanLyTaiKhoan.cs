using QuanLyKhuTro.CustomDesign;
using QuanLyKhuTro.DAO;
using QuanLyKhuTro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhuTro.View
{
    public partial class QuanLyTaiKhoan : Form
    {
        private Account account;
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        public QuanLyTaiKhoan(Account a)
        {
            this.account = a;
            InitializeComponent();
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            if (account != null)
            {
                txtUserName.Text = account.UserName;
                txtFullname.Text = account.Name;
               
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             
            //Nếu chỉ update FullName
            if(txtNewPass.Text == "")
            {
                if (txtOldPass.Text.Trim() == "" || txtFullname.Text.Trim() == "")
                {
                    CustomMessageBox.Show("Họ tên và Mật khẩu cũ không được để trống");
                }
                else
                {
                    account.Name = txtFullname.Text;
                   if (new AccountDao().Update(account))
                    {
                        CustomMessageBox.Show("Cập nhật thành công, Khởi động lại ứng dụng để reload");
                        View.Home.account.Name = txtFullname.Text;
                        
                    }
                    else
                    {
                        CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                            "Lỗi",
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error);
                    }
                }
            }//Nếu cập nhật pass
            else
            {
                if (txtOldPass.Text != account.Password)
                {
                    CustomMessageBox.Show("Mật khẩu cũ không chính xác");
                }else if(txtNewPass.Text.Trim() == "")
                {
                    CustomMessageBox.Show("Mật khẩu mới không được để trống");
                }
                else
                {
                    account.Password = txtNewPass.Text.Trim();
                    if (new AccountDao().Update(account))
                    {
                        CustomMessageBox.Show("Cập nhật thành công, Khởi động lại ứng dụng để reload");
                        View.Home.account.Password = txtNewPass.Text.Trim();
                        
                    }
                    else
                    {
                        CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                            "Lỗi",
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error);
                    }
                }
            }

            
        }
    }
}
