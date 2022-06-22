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
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }
        BUS_tbl_SinhVien bus = new BUS_tbl_SinhVien();
        EC_tbl_SinhVien ec = new EC_tbl_SinhVien();
        bool themmoi;
        string gioitinh;
        void KhoaDieuKhien()
        {
            txtMSSV.Enabled = false;
            txtHoten.Enabled = false;
            groupBox1.Enabled = false;
            dtNgaySinh.Enabled = false;
            txtNoiSinh.Enabled = false;
            cbbTenLop.Enabled = false;

            btnAddNew.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        void MoDieuKhien()
        {
            txtMSSV.Enabled = true;
            txtHoten.Enabled = true;
            groupBox1.Enabled = true;
            dtNgaySinh.Enabled = true;
            txtNoiSinh.Enabled = true;
            cbbTenLop.Enabled = true;

            btnAddNew.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        void setnull()
        {
            txtMSSV.Text = "";
            txtHoten.Text = "";
            gioitinh = "NULL";
            dtNgaySinh.Text = "";
            txtNoiSinh.Text = "";
            cbbTenLop.Text = "";
        }
        void hienthi(string where)
        {
            dgvDS.DataSource = bus.TaoBang(where);
        }

        void loadcbb(string where)
        {
            cbbTenLop.DisplayMember = "TenLop";
            cbbTenLop.DataSource = bus.Dodulieuvaocbb(where);
            cbbTenLop.SelectedIndex = 0;
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            hienthi("where sinhvien.MaLop = lop.MaLop");
            loadcbb("");
            dtNgaySinh.Value = DateTime.Today; // Lấy ngày hiện tại
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            setnull();
            themmoi = true;
        }

        public bool kiemtra()
        {
            if (String.IsNullOrWhiteSpace(txtMSSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã số sinh viên \n Mã số sinh viên là bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMSSV.Focus();
                return false;
            }

            if (txtHoten.TextLength <= 2)
            {
                MessageBox.Show("Họ Tên phải ít nhất 2 từ");
                txtHoten.Focus();
                return false;
            }

            DateTime n = DateTime.Now;
            int age = n.Year - dtNgaySinh.Value.Year;

            if (age <= 18)
            {
                MessageBox.Show("Tuổi phải lớn hơn 18");
                dtNgaySinh.Focus();
                return false;
            }
            return true;
        } 

            private void btnSave_Click(object sender, EventArgs e)
        {
            if (themmoi == true)
            {
                try
                {
                    if (kiemtra())
                    {
                        ec.MaSV = txtMSSV.Text;
                        string[] hovaten = txtHoten.Text.Split(' ');
                        string ho = "";
                        for (int i = 0; i < hovaten.Length - 1; i++)
                        {
                            ho = ho + hovaten[i] + " ";
                        }
                        ho = ho.Trim();
                        string ten = hovaten[hovaten.Length - 1];


                        ec.HoSV = ho;
                        ec.TenSV = ten;

                        if (rbNam.Checked == true)
                            gioitinh = "Nam";
                        else
                            gioitinh = "Nữ";

                        ec.Phai = gioitinh;


                        ec.NgaySinh = dtNgaySinh.Text;



                        ec.NoiSinh = txtNoiSinh.Text;


                        int stt = cbbTenLop.SelectedIndex + 1;
                        ec.MaLop = stt.ToString();

                        bus.ThemDuLieu(ec);
                        MessageBox.Show("Đã thêm mới thành công");
                        setnull();
                        KhoaDieuKhien();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm không thành công" + ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    if (kiemtra())
                    {
                        ec.MaSV = txtMSSV.Text;

                        string[] hovaten = txtHoten.Text.Split(' ');
                        string ho = "";
                        for (int i = 0; i < hovaten.Length - 1; i++)
                        {
                            ho = ho + hovaten[i] + " ";
                        }
                        ho = ho.Trim();
                        string ten = hovaten[hovaten.Length - 1];


                        ec.HoSV = ho;
                        ec.TenSV = ten;

                        if (rbNam.Checked == true)
                            gioitinh = "Nam";
                        else
                            gioitinh = "Nữ";

                        ec.Phai = gioitinh;


                        ec.NgaySinh = dtNgaySinh.Text;
                        ec.NoiSinh = txtNoiSinh.Text;


                        int stt = cbbTenLop.SelectedIndex + 1;
                        ec.MaLop = stt.ToString();

                        bus.SuaDuLieu(ec);
                        MessageBox.Show("Đã sữa thành công");
                        setnull();
                        KhoaDieuKhien();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sữa không thành công" + ex.Message);
                    return;
                }
            }
            hienthi("where sinhvien.MaLop = lop.MaLop");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa", " Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == rs)
            {
                try
                {
                    ec.MaSV = txtMSSV.Text;
                    bus.XoaDuLieu(ec);
                    MessageBox.Show("Đã xoá thành công");
                    KhoaDieuKhien();
                    setnull();
                    hienthi("where sinhvien.MaLop = lop.MaLop");
                }
                catch
                {
                    MessageBox.Show("Lỗi Không thể xoá");
                }
            }
        }

        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                int i = e.RowIndex;
                string MaSV = dgvDS.Rows[i].Cells[0].Value.ToString().Trim();
                string HoSV = dgvDS.Rows[i].Cells[1].Value.ToString().Trim();
                string TenSV = dgvDS.Rows[i].Cells[2].Value.ToString().Trim();
                string Phai = dgvDS.Rows[i].Cells[3].Value.ToString().Trim();
                string NgaySinh = dgvDS.Rows[i].Cells[4].Value.ToString().Trim();
                string NoiSinh = dgvDS.Rows[i].Cells[5].Value.ToString().Trim();
                string MaLop = dgvDS.Rows[i].Cells[6].Value.ToString().Trim();


                txtMSSV.Text = MaSV;
                txtHoten.Text = HoSV + " " + TenSV;
                //gioitinh = "NULL";

                switch (Phai)
                {
                    case "Nam":
                        rbNam.Checked = true;
                        break;
                    case "Nữ":
                        rbNu.Checked = true;
                        break;
                }


                dtNgaySinh.Text = NgaySinh;
                txtNoiSinh.Text = NoiSinh;
                cbbTenLop.Text = MaLop;
            }
            catch
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            txtMSSV.Enabled = false;
            themmoi = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                frm.Close();
            this.Visible = false; // frm đầu đóng đi
            frmTimKiem fr = new frmTimKiem();
            fr.ShowDialog();
            this.Visible = true; // khi tắt sẽ mở 
        }
    }
}
