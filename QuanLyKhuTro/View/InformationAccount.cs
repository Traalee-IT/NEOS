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
    public partial class InformationAccount : Form
    {
        private Account CurrentAccount;
        public InformationAccount()
        {
            InitializeComponent();
        }
        public InformationAccount(Account a)
        {
            InitializeComponent();
            CurrentAccount = a;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtOldPass.Text.Equals(CurrentAccount.Password))
            {
                CustomMessageBox.Show("Mật khẩu cũ không chính xác");
            }
            else
            if (!txtOldPass.Text.Equals(txtNewPass.Text))
            {
                CustomMessageBox.Show("Mật khẩu mới không được trùng với mật khẩu hiện tại");
            }
            else
            {
                Account a = new Account();
                a.UserName = CurrentAccount.UserName;
                a.Password = txtNewPass.Text.Trim();
                if(new AccountDao().Update(a))
                {
                    CustomMessageBox.Show("Cập nhật thành công!");
                    
                }
                else
                {
                    CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                                    "Error-Stop Icon",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if(txtNewPass.Text == "")
            {
                btnUpdate.Enabled = false;
            }
        }

        private void iconEye_Click(object sender, EventArgs e)
        {
            iconEye.IconChar = FontAwesome.Sharp.IconChar.Eye;
            iconEye1.IconChar = FontAwesome.Sharp.IconChar.Eye;
            txtNewPass.UseSystemPasswordChar = false;
            txtOldPass.UseSystemPasswordChar = false;
        }

        private void InformationAccount_Load(object sender, EventArgs e)
        {
            lbUserName.Text = CurrentAccount.UserName;
            txtFullName.Text = CurrentAccount.Name;
        }
    }
}
