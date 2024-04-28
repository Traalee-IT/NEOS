using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhuTro.Model
{
    class QuanLyChiTieu
    {
        public int ID { get; set; }
        public int IdService { get; set; }
        public DateTime TimePayment { get; set; }
        public float TotalMoney { get; set; }
        public string Note { get; set; }
    }
}
