using System;
using System.Collections.Generic;
using System.Text;

namespace Flight
{
    class ChuyenBay
    {
        public ChuyenBay(string maChuyenBay, string soHieu, DateTime ngayKhoiHanh, string sanBayDen, int trangThai, LinkedList<Ve> danhSachVe, LinkedList<int> danhSachGheTrong)
        {
            this.maChuyenBay = maChuyenBay;
            this.soHieu = soHieu;
            this.ngayKhoiHanh = ngayKhoiHanh;
            this.sanBayDen = sanBayDen;
            this.trangThai = trangThai;
            this.danhSachVe = danhSachVe;
            this.danhSachGheTrong = danhSachGheTrong;
        }

        public override string ToString()
        {
            return maChuyenBay + " " + soHieu + " " + ngayKhoiHanh.ToString("dd/MM/yyyy") + " " + 
                sanBayDen + " " + trangThai + " " + danhSachVe + " " + danhSachGheTrong;
        }
        public String maChuyenBay { get; set; }
        public String soHieu { get; set; }
        public DateTime ngayKhoiHanh { get; set; }

        public String sanBayDen { get; set; }
        public int trangThai { get; set; }

        public LinkedList<Ve> danhSachVe { get; set; }

        public LinkedList<int> danhSachGheTrong { get; set; }
    }
}
