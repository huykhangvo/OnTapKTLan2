using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EC_tbl_SinhVien
    {
        //quét BD
        private string _MaSV;
        private string _HoSV;
        private string _TenSV;
        private string _Phai;
        private string _NgaySinh;
        private string _NoiSinh;
        private string _MaLop;
        //quét KT + tổ hợp phím  //Ctrl + (R + E) => Apply

        public string MaSV { get => _MaSV; set => _MaSV = value; }
        public string HoSV { get => _HoSV; set => _HoSV = value; }
        public string TenSV { get => _TenSV; set => _TenSV = value; }
        public string Phai { get => _Phai; set => _Phai = value; }
        public string NgaySinh { get => _NgaySinh; set => _NgaySinh = value; }
        public string NoiSinh { get => _NoiSinh; set => _NoiSinh = value; }
        public string MaLop { get => _MaLop; set => _MaLop = value; }
        
    }
}
