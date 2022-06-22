using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTapKTLan2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void thôngTinSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                frm.Close();
            this.Visible = false; // frm đầu đóng đi
            frmSinhVien fr = new frmSinhVien();
            fr.ShowDialog();
            this.Visible = true; // khi tắt sẽ mở 
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
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
