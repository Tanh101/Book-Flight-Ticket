using System;
using System.Collections.Generic;
using System.Text;

namespace Flight
{
    class Ve
    {
        public Ve()
        {
        }

        public Ve(string mave, string maChuyenBay, KhachHang thongTinKhachHang, int sttGhe)
        {
            this.mave = mave;
            this.maChuyenBay = maChuyenBay;
            this.thongTinKhachHang = thongTinKhachHang;
            this.sttGhe = sttGhe;
        }

        public String mave { get; set; }
        public String maChuyenBay { get; set; }

        public KhachHang thongTinKhachHang { get; set; }
        public int sttGhe { get; set; }

        public string[] getInfor()
        {
            string[] a = new string[] { mave, maChuyenBay, thongTinKhachHang.CMND, thongTinKhachHang.hoVaTen, sttGhe.ToString() };
            return a;
        }
    }
}
