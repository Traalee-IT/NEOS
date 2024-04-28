using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhuTro.Model
{
    public class LichSuThanhToan
    {
        public int ID { get; set; }
        public int IDRoom { get; set; }
        public string NguoiThanhToan { get; set; }
        public DateTime PayDate { get; set; }
        public float soDien { get; set; }
        public float soNuoc { get; set; }
        public string status { get; set; }
        public float totalMoney { get; set; }

    }
}