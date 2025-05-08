using BLL;
using DAL;
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
    public partial class HoaDonForm : Form
    {

        HOCVIEN hocVien;
        private LichHocBLL lichHocBLL = new LichHocBLL();
        private HoaDonBLL HoaDonBLL = new HoaDonBLL();
        private HocVienBLL HocVienBLL = new HocVienBLL();
        public HoaDonForm(HOCVIEN hocVien)
        {
            InitializeComponent();
            this.hocVien = hocVien;
            loadTTHD();

        }
        void loadTTHD()
        {
            txtHoTen.Text = hocVien.HoTen;
            txtHoTen.ReadOnly = true;
            txtTenGT.Text = hocVien.GOITAP.TenGoTap;
            txtTenGT.ReadOnly = true;
            txtGiaGT.Text = (hocVien.GOITAP.Gia ?? 0).ToString("N0");
            txtGiaGT.ReadOnly = true;


            decimal gia1Buoi = 40000;
            txtGia1B.Text = gia1Buoi.ToString("N0");
            txtGia1B.ReadOnly = true;

            int soBuoiTap = lichHocBLL.GetSoBuoiTap(hocVien.HocVienID) * 4;
            txtBT.Text = soBuoiTap.ToString();
            txtBT.ReadOnly = true;


            decimal tongTien = soBuoiTap * gia1Buoi;
            txtTongGia.Text = tongTien.ToString("N0");
            txtTongGia.ReadOnly = true;



            decimal thanhTien = tongTien + (hocVien.GOITAP.Gia ?? 0);
            txtThanhTien.Text = thanhTien.ToString("N0");
            txtThanhTien.ReadOnly = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                decimal giaGoiTap = decimal.Parse(txtGiaGT.Text);
                int soBuoiTap = int.Parse(txtBT.Text);
                decimal tongTien = decimal.Parse(txtTongGia.Text);
                decimal thanhTien = decimal.Parse(txtThanhTien.Text);
                int adminID = 1;

                DateTime ngayDangKy = hocVien.NgayBatDau ?? DateTime.Now;

                HoaDonBLL.ThanhToan(hocVien.HocVienID, tongTien, soBuoiTap, adminID, ngayDangKy);
                HocVienBLL.UpdateIsPaid(hocVien.HocVienID);

                MessageBox.Show("Hóa đơn đã được thanh toán thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message + "\nInner Exception: " + ex.InnerException?.Message);
            }
        }
    }
}
