using BLL;
using DAL;
using DTO;
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
    public partial class QLHV_Form : Form
    {
        private USER user;
        private HOCVIEN hocVien;
        private LichHocBLL lichHocBLL = new LichHocBLL();
        private HocVienBLL hocVienBLL = new HocVienBLL();
        public QLHV_Form(USER user, HOCVIEN hocVien)
        {
            InitializeComponent();
            this.user = user;
            this.hocVien = hocVien;
            LoadLichHoc();
            LoadInforHV();
        }

        public void LoadInforHV()
        {
            lblhoten.Text = hocVien.HoTen;
            lblusername.Text = hocVien.UserID;
            lblgender.Text = hocVien.Gender.GetValueOrDefault() ? "Nam" : "Nữ";
            lblNS.Text = hocVien.NgaySinh.HasValue ? hocVien.NgaySinh.Value.ToString("dd/MM/yyyy") : "N/A";
            lblSDT.Text = hocVien.SDT;
            var goiTap = hocVienBLL.GetGoiTapByID(hocVien.GoTapID ?? 0);
            if (hocVien.GoTapID > 0)
            {
                lblGT.Text = goiTap?.TenGoTap ?? "Chưa đăng ký";
                lblNDK.Text = hocVien.NgayBatDau.HasValue ? hocVien.NgayBatDau.Value.ToString("dd/MM/yyyy") : "N/A";
                lblNHH.Text = hocVien.NgayHetHan.HasValue ? hocVien.NgayHetHan.Value.ToString("dd/MM/yyyy") : "N/A";
            }
            else
            {
                lblGT.Text = "Chưa đăng ký";
                lblNDK.Text = "N/A";
                lblNHH.Text = "N/A";
            }

            if (hocVien.IsPaid.GetValueOrDefault() && goiTap?.TenGoTap != null)
            {
                lblThanhToan.Text = "Đã thanh toán";
                lblThanhToan.ForeColor = Color.Blue;
            }
            else
            {
                lblThanhToan.Text = "Chưa thanh toán";
                lblThanhToan.ForeColor = Color.Red;
            }


            if (hocVien.IsPaid.GetValueOrDefault() && hocVien.IsRegistered.GetValueOrDefault())
            {
                lblThanhToanPT.Text = "Đã thanh toán";
                lblThanhToanPT.ForeColor = Color.Blue;
            }
            else
            {
                lblThanhToanPT.Text = "Chưa thanh toán";
                lblThanhToanPT.ForeColor = Color.Red;
            }
            var lichHoc = lichHocBLL.GetLichHocByHocVienID(hocVien.HocVienID);
            LichHocHV_View firstLichHoc = lichHoc.FirstOrDefault();

            if (firstLichHoc != null)
            {

                lblBD.Text = firstLichHoc.NgayDangKy.HasValue ? firstLichHoc.NgayDangKy.Value.ToString("dd/MM/yyyy") : "N/A";

                DateTime? ngayKetThuc = firstLichHoc.NgayDangKy?.AddMonths(1);
                lblKT.Text = ngayKetThuc.HasValue ? ngayKetThuc.Value.ToString("dd/MM/yyyy") : "N/A";
            }
            else
            {
                lblBD.Text = "N/A";
                lblKT.Text = "N/A";
            }
        }

        private string GetGioHoc(string buoiHoc)
        {
            switch (buoiHoc)
            {
                case "Sáng":
                    return "07:00";
                case "Chiều":
                    return "14:00";
                case "Tối":
                    return "19:00";
                default:
                    return "N/A";
            }
        }
        public void LoadLichHoc()
        {
            var lichHocList = lichHocBLL.GetLichHocByHocVienIDChange(hocVien.HocVienID);

            dataGridViewLichhoc.DataSource = lichHocList
                .Select(lh => new
                {
                    lh.id,
                    lh.HoTenHV,
                    lh.HoTenPT,
                    lh.ThuHoc,
                    lh.BuoiHoc,
                    NgayDangKy = lh.NgayDangKy.HasValue ? lh.NgayDangKy.Value.ToString("dd/MM/yyyy") : "N/A",
                    Giohoc = GetGioHoc(lh.BuoiHoc)
                })
                .ToList();
            dataGridViewLichhoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Close();
            QLHV_Form qlHVForm = new QLHV_Form(user, hocVien);
            qlHVForm.Show();
        }

        private void btnQuenPass_Click(object sender, EventArgs e)
        {
            QuenMK_Form quenpassForm = new QuenMK_Form(user, null, hocVien);
            quenpassForm.ShowDialog();
        }

        private void btnDoiTT_Click(object sender, EventArgs e)
        {
            ChangeTTForm changeTTForm = new ChangeTTForm();
            changeTTForm.LoadData(hocVien, "HV");
            changeTTForm.ShowDialog();
            LoadInforHV();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            HoaDonForm hoaDonForm = new HoaDonForm(hocVien);
            hoaDonForm.ShowDialog();
            hocVien.IsPaid = true;
            LoadInforHV();
        }

        private void btnDKPT_Click(object sender, EventArgs e)
        {
            if (dataGridViewLichhoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewLichhoc.SelectedRows[0];
                int lichHocID = (int)selectedRow.Cells["id"].Value;
                var lichHocList = lichHocBLL.GetLichHocByHocVienID(hocVien.HocVienID);
                Change_LH_Form change_LH_Form = new Change_LH_Form(lichHocID, lichHocList);
                change_LH_Form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lịch học để thay đổi.");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
