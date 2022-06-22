using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Entity;

namespace OnTapKTLan2
{
    public partial class frmTimKiem : Form
    {
        public frmTimKiem()
        {
            InitializeComponent();
        }
        BUS_tbl_SinhVien bus = new BUS_tbl_SinhVien();
        EC_tbl_SinhVien ec = new EC_tbl_SinhVien();

        void hienthi(string where)
        {
            dgvDS.DataSource = bus.TaoBang(where);
        }

        void loadcbb(string where)
        {
            cbbTenLop.DisplayMember = "TenLop";
            cbbTenLop.DataSource = bus.Dodulieuvaocbb(where);
        }

        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            hienthi("where sinhvien.MaLop = lop.MaLop");
            loadcbb("");
        }

        void timkiem(string where)
        {
            dgvDS.DataSource = bus.TimKiem(where);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string MaSV = txtMSSV.Text;
            string HoSV = txtHo.Text;
            string TenSV = txtTen.Text;

            string gioitinh;
            if (rbNam.Checked == true)
                gioitinh = "Nam";
            else if((rbNu.Checked == true))
                gioitinh = "Nữ";
            else
                gioitinh = "";

            string NgaySinh = txtNgaySinh.Text;
            string NoiSinh = txtNoiSinh.Text;

            int stt = cbbTenLop.SelectedIndex + 1;
            string MaLop = stt.ToString();

            timkiem("WHERE MaSV like '%" + MaSV.Trim() + "%' AND HoSV like '%" + HoSV.Trim() + "%' AND TenSV like '%" + TenSV.Trim() + "%' AND Phai like N'%" + gioitinh.Trim() + "%' AND NgaySinh like N'%" + NgaySinh.Trim() + "%' AND NoiSinh like N'%" + NoiSinh.Trim() + "%' AND MaLop like N'%" + MaLop.Trim() + "%'");
        }

        private void bltLoad_Click(object sender, EventArgs e)
        {
            hienthi("where sinhvien.MaLop = lop.MaLop");
            loadcbb("");
        }
    }
}
