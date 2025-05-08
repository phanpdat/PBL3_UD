using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class LichDetailForm : Form
    {
        private LichHocBLL lichHocBLL = new LichHocBLL();
        public LichDetailForm(string hoTenPT, string thuHoc, string buoiHoc)
        {
            InitializeComponent();
            label6.Text = hoTenPT;
            label7.Text = thuHoc;
            label8.Text = buoiHoc;
            LoadDanhSachHocVien(hoTenPT, thuHoc, buoiHoc);
        }

        private void LoadDanhSachHocVien(string hoTenPT, string thuHoc, string buoiHoc)
        {
            var hocVienList = lichHocBLL.GetHocVienByLichHoc(hoTenPT, thuHoc, buoiHoc);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = hocVienList.Select(hv => new
            {
                hv.HocVienID,
                hv.HoTen,
                hv.SDT,
                GioiTinh = hv.Gender.GetValueOrDefault() ? "Nam" : "Nữ",
                hv.NgaySinh
            }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
