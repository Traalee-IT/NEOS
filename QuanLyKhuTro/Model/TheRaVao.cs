using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhuTro.Model
{
    //Bảo lấy dữ liệu giống sql mà?
    class TheRaVao
    {
        public int MaThe { get; set; }

        public int MaKH { get; set; } //???
        public DateTime NgayTao { get; set; }
        public DateTime NgayHetHan { get; set; }

        public TheRaVao() { }

     
    }
}
