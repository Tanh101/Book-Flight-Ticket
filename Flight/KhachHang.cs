using System;
using System.Collections.Generic;
using System.Text;

namespace Flight
{
    class KhachHang
    {
        public KhachHang(string cMND, string hoVaTen)
        {
            CMND = cMND;
            this.hoVaTen = hoVaTen;
        }

        public KhachHang(string sTT, string cMND, string hoVaTen)
        {
            STT = sTT;
            CMND = cMND;
            this.hoVaTen = hoVaTen;
        }

        public override string ToString()
        {
            return STT + "#" + CMND + "#" + hoVaTen;
        }

        public String STT { get; set; }
        public String CMND { get; set; }
        public String hoVaTen { get; set; }
    }
}
