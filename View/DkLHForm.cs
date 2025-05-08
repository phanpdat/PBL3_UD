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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace View
{
    public partial class DkLHForm : Form
    {
        List<LichHocHV_View> lichHocList_View = new List<LichHocHV_View>();
        List<LICH_HOC> lichHocList = new List<LICH_HOC>();
        HOCVIEN hocVien = new HOCVIEN();
        private HocVienBLL hocVienBLL = new HocVienBLL();
        private LichHocBLL lichHocBLL = new LichHocBLL();
        private readonly PTBLL PTBLL = new PTBLL();
        public DkLHForm(HOCVIEN hocVien)
        {
            InitializeComponent();
            LoadThuComboBox();
            LoadBuoiComboBox();
            LoadPTToDataGridView();
            this.hocVien = hocVien;
        }

        private void LoadThuComboBox()
        {

            comboBox1.Items.Add("Thứ 2");
            comboBox1.Items.Add("Thứ 3");
            comboBox1.Items.Add("Thứ 4");
            comboBox1.Items.Add("Thứ 5");
            comboBox1.Items.Add("Thứ 6");
            comboBox1.Items.Add("Thứ 7");
            comboBox1.SelectedIndex = 0;
        }

        private void LoadBuoiComboBox()
        {

            comboBox2.Items.Add("Sáng");
            comboBox2.Items.Add("Chiều");
            comboBox2.Items.Add("Tối");
            comboBox2.SelectedIndex = 0;
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

        private void LoadPTToDataGridView()
        {

            var ptList = PTBLL.GetAllPT();


            dataGridView1.DataSource = ptList;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên hoặc mã PT để tìm kiếm.");
                return;
            }

            var result = hocVienBLL.GetHocVienList().Where(hv => hv.HoTen.ToLower().Contains(keyword) || hv.UserID.ToLower().Contains(keyword)).ToList();
            dataGridView1.DataSource = result;
            if (result.Count == 0) MessageBox.Show("Không tìm thấy PT.");
        }

        private void btndk_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int ptID = (int)selectedRow.Cells["PTID"].Value;
                string ptName = (string)selectedRow.Cells["HoTen"].Value;

                string thu = comboBox1.SelectedItem.ToString();
                string buoi = comboBox2.SelectedItem.ToString();
                DateTime ngayDangKy = DateTime.Now.Date;
                LichHocHV_View newLichHocHV = new LichHocHV_View
                (
                    hocVien.HoTen,
                    ptName,
                    thu,
                    buoi,
                    ngayDangKy,
                    GetGioHoc(buoi)

                );

                LICH_HOC newLichHoc = new LICH_HOC
                {
                    ThuHoc = thu,
                    BuoiHoc = buoi,
                    NgayDangKy = ngayDangKy,
                    HocVienID = hocVien.HocVienID,
                    PTID = ptID,

                };


                if (dataGridView2.DataSource != null)
                {
                    lichHocList_View = (List<LichHocHV_View>)dataGridView2.DataSource;
                }
                else
                {
                    lichHocList_View = new List<LichHocHV_View>();
                }


                bool isDuplicate = lichHocList_View.Any(lh => lh.ThuHoc == thu && lh.BuoiHoc == buoi);

                if (isDuplicate)
                {
                    MessageBox.Show("Lịch học đã được đăng ký trước đó. Vui lòng chọn lịch khác.");
                    return;
                }


                lichHocList_View.Add(newLichHocHV);
                lichHocList.Add(newLichHoc);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = lichHocList_View;
                hocVien.IsRegistered = true;
                hocVienBLL.UpdateHocVienStatus(hocVien);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {

                var selectedRow = dataGridView2.SelectedRows[0];

                string hoTenHV = (string)selectedRow.Cells["HoTenHV"].Value;
                string hoTenPT = (string)selectedRow.Cells["HoTenPT"].Value;
                string thuHoc = (string)selectedRow.Cells["ThuHoc"].Value;
                string buoiHoc = (string)selectedRow.Cells["BuoiHoc"].Value;
                DateTime ngayDangKy = (DateTime)selectedRow.Cells["NgayDangKy"].Value;

                var lichHocToRemove = lichHocList_View.FirstOrDefault(lh =>
                    lh.HoTenHV == hoTenHV &&
                    lh.HoTenPT == hoTenPT &&
                    lh.ThuHoc == thuHoc &&
                    lh.BuoiHoc == buoiHoc &&
                    lh.NgayDangKy == ngayDangKy);

                if (lichHocToRemove != null)
                {
                    lichHocList_View.Remove(lichHocToRemove);

                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = lichHocList_View;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lịch học để hủy.");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                lichHocBLL.SaveLichHocToDatabase(lichHocList);
                MessageBox.Show("Lịch học đã được đăng ký thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên hoặc mã PT để tìm kiếm.");
                return;
            }

            var result = PTBLL.GetAllPT().Where(pt => pt.HoTen.ToLower().Contains(keyword) || pt.UserID.ToLower().Contains(keyword)).ToList();
            dataGridView1.DataSource = result;
            if (result.Count == 0) MessageBox.Show("Không tìm thấy PT.");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
