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
            string a = "";
            a += maChuyenBay + "#" + soHieu + "#" + ngayKhoiHanh.ToString("dd/MM/yyyy") + "#" +
                sanBayDen + "#" + trangThai + "#";
            int i = 1;
            foreach (Ve v in danhSachVe)
            {
                if (i < danhSachVe.Count)
                    a += v.mave + "-" + v.thongTinKhachHang.CMND + "-" + v.thongTinKhachHang.hoVaTen + "-" + v.sttGhe + "-";
                else
                    a += v.mave + "-" + v.thongTinKhachHang.CMND + "-" + v.thongTinKhachHang.hoVaTen + "-" + v.sttGhe;
                i++;
            }
            a += "#";
            if (danhSachGheTrong.Count < 1)
            {
                a += "0";
            }
            else
            {

                int j = 1;
                foreach (int k in danhSachGheTrong)
                {
                    if (j < danhSachGheTrong.Count)
                        a += k.ToString() + ";";
                    else
                        a += k.ToString();
                    j++;
                }
            }
            return a;
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
