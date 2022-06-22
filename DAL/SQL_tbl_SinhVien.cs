using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL
{
    public class SQL_tbl_SinhVien
    {
        KetNoiDB cn = new KetNoiDB();
        public void ThemDuLieu(EC_tbl_SinhVien et)
        {
            cn.ThucThiCauLenhSQL(@"INSERT INTO SinhVien (MaSV, HoSV, TenSV, Phai, NgaySinh, NoiSinh, MaLop) VALUES ('" + et.MaSV + "',N'" + et.HoSV + "',N'" + et.TenSV + "',N'" + et.Phai + "',N'" + et.NgaySinh + "',N'" + et.NoiSinh + "','" + et.MaLop + "')");
        }
        public void SuaDuLieu(EC_tbl_SinhVien et)
        {
            cn.ThucThiCauLenhSQL(@"UPDATE SinhVien SET HoSV = N'" + et.HoSV + "', TenSV = N'" + et.TenSV + "', Phai = N'" + et.Phai + "', NgaySinh = N'" + et.NgaySinh + "', NoiSinh = N'" + et.NoiSinh + "', MaLop = '" + et.MaLop + "' WHERE MaSV = '" + et.MaSV + "'");
        }
        public void XoaDuLieu(EC_tbl_SinhVien et)
        {
            cn.ThucThiCauLenhSQL(@"DELETE FROM SinhVien WHERE MaSV='" + et.MaSV + "'");
        }

        public DataTable TaoBang(string DieuKien)
        {
            return cn.GetDataTable(@"select MaSV, HoSV ,TenSV ,Phai ,NgaySinh ,NoiSinh, lop.TenLop as TenLop  from SinhVien,lop " + DieuKien);
        }

        public DataTable Dodulieuvaocbb(string DieuKien)
        {
            return cn.GetDataTable(@"select distinct (TenLop) from lop" + DieuKien);
        }

        public DataTable TimKiem(string DieuKien)
        {
            return cn.GetDataTable(@"select * from SinhVien " + DieuKien);
        }
    }
}
