using BLL;
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
    public partial class DkGT_Form : Form
    {

        int HocVienID;
        private GoiTapBLL bllGoiTap = new GoiTapBLL();
        private HocVienBLL hocVienBLL = new HocVienBLL();
        HocVienForm hocVienForm;
        public DkGT_Form(int HocVienID, HocVienForm hocVienForm)
        {
            InitializeComponent();
            LoadGoiTapToComboBox();
            this.HocVienID = HocVienID;
            this.hocVienForm = hocVienForm;
        }
        private void LoadGoiTapToComboBox()
        {
            var goiTaps = bllGoiTap.GetAllGoiTapForComboBox();
            cbbGT.DataSource = goiTaps;
            cbbGT.DisplayMember = "TenGt";
            cbbGT.ValueMember = "Gia";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbbGT.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một gói tập.");
                return;
            }

            Cbb_Item_GT selectedGoiTap = (Cbb_Item_GT)cbbGT.SelectedItem;
            if (!selectedGoiTap.Gia.HasValue || !selectedGoiTap.ThoiGian.HasValue)
            {
                MessageBox.Show("Gói tập không hợp lệ. Vui lòng chọn lại.");
                return;
            }

            int goTapID = selectedGoiTap.GoTapID;
            decimal gia = selectedGoiTap.Gia.Value;
            int thoiGian = selectedGoiTap.ThoiGian.Value;

            DateTime ngayDangKy = DateTime.Now;
            DateTime ngayHetHan = ngayDangKy.AddMonths(thoiGian);
            hocVienBLL.RegisterGoiTap(HocVienID, goTapID, ngayDangKy, ngayHetHan);

            MessageBox.Show("Đăng ký gói tập thành công!");
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbGT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGT.SelectedItem != null)
            {

                Cbb_Item_GT selectedGoiTap = (Cbb_Item_GT)cbbGT.SelectedItem;

                txtGia.Text = selectedGoiTap.Gia.HasValue ? selectedGoiTap.Gia.Value.ToString("N0") + " VND" : "Giá không xác định";
                txtGia.ReadOnly = true;
                txtTG.Text = selectedGoiTap.ThoiGian.ToString() + " tháng";
                txtTG.ReadOnly = true;
            }
        }
    }
}
