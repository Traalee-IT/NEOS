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
    public partial class Login : Form
    {
        private AccountDao accountDao;
        public Login()
        {
            InitializeComponent();
            accountDao = new AccountDao();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

       

        #region setUp
        public const int WM_NCLBUTTONDOWN = 0x112;
        public const int HT_CAPTION = 0xf012;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        //Custom hover control close - mini
        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.LightCoral;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Maroon;
        }

        private void btnMinisize_MouseHover(object sender, EventArgs e)
        {
            btnMinisize.BackColor = Color.DarkOrange;
        }

        private void btnMinisize_MouseLeave(object sender, EventArgs e)
        {
            btnMinisize.BackColor = Color.Maroon;
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {

            if (txtUserName.Text == "Tên đăng nhập")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.Black;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "Tên đăng nhập";
                txtUserName.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Mật khẩu")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Mật khẩu";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0';
            }
        }

        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtUserName.Text.Equals("Tên đăng nhập") || txtPassword.Text.Equals("Mật khẩu"))
            {
                CustomMessageBox.Show("Tài khoản và mật khẩu không được để trống");
            }else if(txtUserName.Text.Trim().Length > 20)
            {
                CustomMessageBox.Show("Tên tài khoản không được quá 20 kí tự");
            }
            else if (txtPassword.Text.Trim().Length < 6 && txtPassword.Text.Trim().Length > 20)
            {
                CustomMessageBox.Show("Mật khẩu tối thiểu ít nhất 6 kí tự và tối đa 20 kí tự");
            }
            else
            {
                Account a = accountDao.login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (a == null)
                {
                    CustomMessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                }
                else
                {
                    new Home(a).Show();
                    this.Hide();
                }
            }
            
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            // Thu nhỏ form
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
