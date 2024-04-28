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
    public partial class LoadingAnimation : UserControl
    {
        private const int WS_EX_TRANSPARENT = 0x20;
        public LoadingAnimation()
        {

            InitializeComponent();

            SetStyle(ControlStyles.Opaque, true);

        }

        public LoadingAnimation(IContainer con)
        {

            con.Add(this);

            InitializeComponent();

        }
        private int opacity = 50;

        [DefaultValue(50)]
        public int Opacity
        {
            get
            {

                return this.opacity;

            }

            set
            {

                if (value < 0 || value > 100)


                    throw new ArgumentException("value must be between 0 and 100");


                this.opacity = value;
            }

        }
        protected override CreateParams CreateParams
        {

            get
            {

                CreateParams cpar = base.CreateParams;

                cpar.ExStyle = cpar.ExStyle | WS_EX_TRANSPARENT;

                return cpar;

            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {

            using (var brush = new SolidBrush(Color.FromArgb
               (this.opacity * 255 / 100, this.BackColor)))
            {

                e.Graphics.FillRectangle(brush, this.ClientRectangle);

            }

            base.OnPaint(e);
        }

        private void LoadingAnimation_Resize(object sender, EventArgs e)
        {
            CenterPictureBox();
        }
        private void CenterPictureBox()
        {
            int x = (this.Width - pictureBox1.Width) / 2;
            int y = (this.Height - pictureBox1.Height) / 2;

            pictureBox1.Location = new Point(x, y);
        }

        private void LoadingAnimation_Load(object sender, EventArgs e)
        {
            CenterPictureBox();
        }
    }
}
