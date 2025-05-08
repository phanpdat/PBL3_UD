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
using System.Windows.Forms.DataVisualization.Charting;

namespace View
{
    public partial class AdminForm : Form
    {

        private GoiTapBLL bllGoiTap = new GoiTapBLL();
        private ThietBiBLL bllThietBi = new ThietBiBLL();
        private HocVienBLL hocVienBLL = new HocVienBLL();
        private PTBLL ptBLL = new PTBLL();
        private HoaDonBLL HoaDonBLL = new HoaDonBLL();
        public AdminForm()
        {
            InitializeComponent();
            LoadComboBoxGT();
            LoadComboBoxHV();
            LoadComboBoxpt();
            LoadAllGT();
            LoadAllTB();
            LoadAllHocVien();
            LoadAllPT();
            LoadAllHoaDon();
            LoadComboBoxTB();
            LoadDoanhThuTheoThang();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }


        //tab goi tap
        private decimal TryParseGia(string giaText)
        {
            decimal gia = 0;
            giaText = giaText.Replace(" VND", "").Replace(",", "").Trim();
            if (!decimal.TryParse(giaText, out gia))
            {
                MessageBox.Show("Giá tiền không hợp lệ.");
            }

            return gia;
        }

        private void LoadComboBoxGT()
        {
            cbbSortGt.Items.AddRange(new string[] { "Tên A-Z", "Tên Z-A", "Giá tăng dần", "Giá giảm dần", "Thời lượng tăng", "Thời lượng giảm" });
            cbbSortGt.SelectedIndex = 0;
        }

        private void LoadAllGT()
        {
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var allGoiTap = bllGoiTap.GetAll();
            dataGridView4.DataSource = allGoiTap;
        }

        private void btnAllGT_Click(object sender, EventArgs e)
        {
            LoadAllGT();
        }

        private void btnSearchGt_Click(object sender, EventArgs e)
        {
            string keyword = textBox3.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên thiết bị để tìm.");
                return;
            }
            var result = bllGoiTap.GetAll().Where(gt => gt.GoiTapName.ToLower().Contains(keyword) || gt.ThoiLuong.ToLower().Contains(keyword)).ToList();
            dataGridView4.DataSource = result;
        }

        private void btnAddGt_Click(object sender, EventArgs e)
        {
            AddGtForm form = new AddGtForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadAllGT();
            }
        }

        private void btnEditGt_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                var row = dataGridView4.SelectedRows[0];
                GOITAP gt = new GOITAP
                {
                    GoTapID = Convert.ToInt32(row.Cells["GoiTapID"].Value),
                    TenGoTap = row.Cells["GoiTapName"].Value.ToString(),
                    Gia = TryParseGia(row.Cells["Gia"].Value.ToString()),
                    ThoiLuong = int.Parse(row.Cells["ThoiLuong"].Value.ToString().Replace(" tháng", ""))
                };

                AddGtForm form = new AddGtForm();
                form.LoadData(gt);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    bllGoiTap.Update(form.Result);
                    LoadAllGT();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một gói tập để sửa.");
                }
            }
        }

        private void btnDeleteGt_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView4.SelectedRows[0].Cells["GoiTapID"].Value);
                string name = dataGridView4.SelectedRows[0].Cells["GoiTapName"].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xoá gói tập \"{name}\"?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bllGoiTap.Delete(id);
                    LoadAllGT();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một gói tập để xoá.");
            }
        }

        private void btnSortGt_Click(object sender, EventArgs e)
        {
            string criteria = cbbSortGt.Text;
            var list = bllGoiTap.GetAll();

            switch (criteria)
            {
                case "Tên A-Z":
                    list = list.OrderBy(g => g.GoiTapID).ToList();
                    break;
                case "Tên Z-A":
                    list = list.OrderByDescending(g => g.GoiTapName).ToList();
                    break;
                case "Giá tăng dần":
                    list = list.OrderBy(g => g.Gia).ToList();
                    break;
                case "Giá giảm dần":
                    list = list.OrderByDescending(g => g.Gia).ToList();
                    break;
                case "Thời lượng tăng":
                    list = list.OrderBy(g => g.ThoiLuong).ToList();
                    break;
                case "Thời lượng giảm":
                    list = list.OrderByDescending(g => g.ThoiLuong).ToList();
                    break;
            }

            dataGridView4.DataSource = list;
        }
        //tab goi tap


        //tab thiet bi
        private void LoadComboBoxTB()
        {
            cbbSort.Items.AddRange(new string[] { "Tên A-Z", "Tên Z-A", "Số lượng tăng dần", "Số lượng giảm dần", "Số lượng tốt tăng dần", "Số lượng hỏng tăng dần" });
            cbbSort.SelectedIndex = 0;
        }
        private void LoadAllTB()
        {
            dataGridView2.DataSource = bllThietBi.GetAll();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btngetall_Click(object sender, EventArgs e)
        {
            LoadAllTB();
        }

        private void btnLoi_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bllThietBi.GetAll()
           .Where(tb => tb.SoLuongHong > 0)
           .Select(tb => new
           {
               tb.ThietBiID,
               tb.TenThietBi,
               tb.SoLuong,
               tb.SoLuongHong
           }).ToList();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnGood_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bllThietBi.GetAll()
          .Where(tb => tb.SoLuongTot > 0)
          .Select(tb => new
          {
              tb.ThietBiID,
              tb.TenThietBi,
              tb.SoLuong,
              tb.SoLuongTot
          }).ToList();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSearchTB_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchTB.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên thiết bị để tìm.");
                return;
            }

            var result = bllThietBi.GetAll()
                .Where(tb => tb.TenThietBi.ToLower().Contains(keyword)).ToList();

            dataGridView2.DataSource = result;
        }

        private void btnaddtb_Click(object sender, EventArgs e)
        {
            addTBForm form = new addTBForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // bllThietBi.Add(form.Result);
                LoadAllTB();
                MessageBox.Show("Thêm thiết bị thành công!");
            }
        }

        private void btnEdittb_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var row = dataGridView2.SelectedRows[0];
                int ThietBiID = Convert.ToInt32(row.Cells["ThietBiID"].Value);
                var tb = bllThietBi.getTBbyID(ThietBiID);

                addTBForm form = new addTBForm();
                form.LoadDataForEdit(tb);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bllThietBi.Update(form.Result);
                    LoadAllTB();
                    MessageBox.Show("Đã cập nhật thiết bị.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thiết bị để sửa.");
            }
        }

        private void btndeleteAll_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ThietBiID"].Value);
                string name = dataGridView2.SelectedRows[0].Cells["TenThietBi"].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xoá thiết bị \"{name}\"?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bllThietBi.Delete(id);

                    LoadAllTB();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thiết bị để xoá.");
            }
        }

        private void btndeleteSl_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một thiết bị.");
                return;
            }

            if (!int.TryParse(textBox1.Text.Trim(), out int soLuongCanXoa) || soLuongCanXoa <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                return;
            }

            int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ThietBiID"].Value);
            var tb = bllThietBi.getTBbyID(id);

            string loaiXoa = cbbloaixoa.SelectedItem?.ToString();

            if (loaiXoa == null)
            {
                MessageBox.Show("Vui lòng chọn loại thiết bị cần xoá.");
                return;
            }


            if (loaiXoa == "thiết bị hoạt động")
            {
                if (soLuongCanXoa > tb.SoLuongTot)
                {
                    MessageBox.Show("Số lượng cần xoá lớn hơn số thiết bị hoạt động.");
                    return;
                }

                tb.SoLuongTot -= soLuongCanXoa;
                tb.SoLuong -= soLuongCanXoa;
            }
            else if (loaiXoa == "thiết bị hỏng")
            {
                if (soLuongCanXoa > tb.SoLuongHong)
                {
                    MessageBox.Show("Số lượng cần xoá lớn hơn số thiết bị hỏng.");
                    return;
                }

                tb.SoLuongHong -= soLuongCanXoa;
                tb.SoLuong -= soLuongCanXoa;
            }
            else
            {
                MessageBox.Show("Chỉ được phép chọn thiết bị hoạt động hoặc hỏng.");
                return;
            }

            bllThietBi.Update(tb);
            LoadAllTB();
        }
        //tab thiet bi

        //tab hoc vien

        private void LoadComboBoxHV()
        {
            cbbSort.Items.AddRange(new string[] { "Tên A-Z", "Tên Z-A", "Mã học viên tăng dần", "Mã học viên giảm dần", "Ngày sinh tăng dần", "Ngày sinh giảm dần" });
            cbbSort.SelectedIndex = 0;
        }
        private void LoadAllHocVien()
        {
            var hocViens = hocVienBLL.GetHocVienList();

            dataGridView1.DataSource = hocViens;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên học viên hoặc mã học viên để tìm kiếm.");
                return;
            }
            var result = hocVienBLL.GetHocVienList().Where(hv => hv.HoTen.ToLower().Contains(keyword) || hv.UserID.ToLower().Contains(keyword)).ToList();
            dataGridView1.DataSource = result;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadAllHocVien();
        }

        private void btncomplete_Click(object sender, EventArgs e)
        {
            var ListHocVienDaThanhToan = hocVienBLL.GetHocVienByPaymentStatus(true);
            dataGridView1.DataSource = ListHocVienDaThanhToan;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            var ListHocVienChuaThanhToan = hocVienBLL.GetHocVienByPaymentStatus(false);
            dataGridView1.DataSource = ListHocVienChuaThanhToan;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            rf.ShowDialog();
            LoadAllHocVien();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string userID = dataGridView1.SelectedRows[0].Cells["UserID"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa học viên {userID}?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    hocVienBLL.DeleteHocVienAndAccount(userID);
                    MessageBox.Show("Học viên đã được xóa.");
                    LoadAllHocVien();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn học viên để xóa.");
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int HVID = Convert.ToInt32(selectedRow.Cells["HocVienID"].Value);

                HOCVIEN hv = hocVienBLL.GetHocVienByID(HVID);
                USER user = hocVienBLL.GetUserByHocVienID(HVID);

                if (hv != null)
                {
                    QLHV_Form qlhvForm = new QLHV_Form(user, hv);
                    qlhvForm.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy PT với ID đã chọn.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn PT để xem chi tiết.");
            }
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            string criteria = cbbSort.SelectedItem.ToString();
            var list = hocVienBLL.GetHocVienList();

            switch (criteria)
            {
                case "Tên A-Z":
                    list = list.OrderBy(h => h.HoTen).ToList();
                    break;
                case "Tên Z-A":
                    list = list.OrderByDescending(h => h.HoTen).ToList();
                    break;
                case "Mã học viên tăng dần":
                    list = list.OrderBy(h => h.UserID).ToList();
                    break;
                case "Mã học viên giảm dần":
                    list = list.OrderByDescending(h => h.UserID).ToList();
                    break;
                case "Ngày sinh tăng dần":
                    list = list.OrderBy(h => h.NgaySinh).ToList();
                    break;
                case "Ngày sinh giảm dần":
                    list = list.OrderByDescending(h => h.NgaySinh).ToList();
                    break;
            }

            dataGridView1.DataSource = list;
        }



        //tab hoc vien

        //tab PT
        private void LoadComboBoxpt()
        {
            cbbSort.Items.AddRange(new string[] {
                "Tên A-Z", "Tên Z-A", "Mã PT tăng dần", "Mã PT giảm dần", "Ngày sinh tăng dần", "Ngày sinh giảm dần"
            });
            cbbSort.SelectedIndex = 0;
        }
        private void LoadAllPT()
        {
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var allPT = ptBLL.GetAllPT();
            dataGridView3.DataSource = allPT;
        }

        private void btnSearchPT_Click(object sender, EventArgs e)
        {
            string keyword = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên hoặc mã PT để tìm kiếm.");
                return;
            }
            var result = ptBLL.GetAllPT().Where(pt => pt.HoTen.ToLower().Contains(keyword) || pt.UserID.ToLower().Contains(keyword)).ToList();
            dataGridView3.DataSource = result;
        }

        private void btnAllPT_Click(object sender, EventArgs e)
        {
            LoadAllPT();
        }

        private void btnSearchPT_Click_1(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            rf.ShowDialog();
            LoadAllPT();
        }

        private void btnADDPT_Click(object sender, EventArgs e)
        {

        }

        private void btnDeletePT_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                string userID = dataGridView3.SelectedRows[0].Cells["UserID"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa PT này và tài khoản của họ?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    ptBLL.DeletePTAndAccount(userID);

                    LoadAllPT();
                    MessageBox.Show("Đã xóa PT và tài khoản người dùng thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn PT để xóa.");
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView3.SelectedRows[0];
                int ptID = Convert.ToInt32(selectedRow.Cells["PTID"].Value);

                PT pt = ptBLL.GetPTByID(ptID);
                USER user = ptBLL.GetUserByPTID(ptID);

                if (pt != null)
                {
                    QLPT_Form detailForm = new QLPT_Form(pt, user);
                    detailForm.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy PT với ID đã chọn.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn PT để xem chi tiết.");
            }
        }

        private void btnSortPT_Click(object sender, EventArgs e)
        {
            string criteria = cbbSort.SelectedItem.ToString();
            var ptList = ptBLL.GetAllPT();

            switch (criteria)
            {
                case "Tên A-Z":
                    ptList = ptList.OrderBy(pt => pt.HoTen).ToList();
                    break;
                case "Tên Z-A":
                    ptList = ptList.OrderByDescending(pt => pt.HoTen).ToList();
                    break;
                case "Mã PT tăng dần":
                    ptList = ptList.OrderBy(pt => pt.PTID).ToList();
                    break;
                case "Mã PT giảm dần":
                    ptList = ptList.OrderByDescending(pt => pt.PTID).ToList();
                    break;
                case "Ngày sinh tăng dần":
                    ptList = ptList.OrderBy(pt => pt.NgaySinh).ToList();
                    break;
                case "Ngày sinh giảm dần":
                    ptList = ptList.OrderByDescending(pt => pt.NgaySinh).ToList();
                    break;
            }

            dataGridView3.DataSource = ptList;
        }
        //tab PT


        //tab hoa don
        private void LoadAllHoaDon()
        {
            try
            {
                var hoaDonViews = HoaDonBLL.GetAllHoaDon();
                dataGridView5.DataSource = hoaDonViews;

                dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu hóa đơn: " + ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadAllHoaDon();
        }

        private void btnDetailHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView5.SelectedRows.Count > 0)
                {
                    int hoaDonID = Convert.ToInt32(dataGridView5.SelectedRows[0].Cells["hoaDonID"].Value);

                    var hocVien = HoaDonBLL.GetHocVienByHoaDonID(hoaDonID);

                    if (hocVien != null)
                    {
                        detailHDForm detailHDForm = new detailHDForm(hocVien);
                        detailHDForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy học viên.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        //tab doanh thu

        private void LoadDoanhThuTheoThang()
        {
            // Lấy doanh thu theo tháng từ BLL (ví dụ tháng 1/2023)
            var doanhThuTheoThang = HoaDonBLL.GetDoanhThuTheoThang(2025); // Lấy doanh thu cả năm 2023

            // Xóa các series và chart areas cũ để vẽ lại
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Tạo một ChartArea mới cho biểu đồ
            ChartArea chartArea = new ChartArea("ChartArea1")
            {
                BackColor = System.Drawing.Color.LightGray,
                AxisX = {
            Title = "Tháng", // Tiêu đề trục X
            IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months, // Thiết lập khoảng cách trục X là tháng
            Interval = 1 // Mỗi một khoảng trục X là một tháng
        },
                AxisY = {
            Title = "Doanh Thu (VND)", // Tiêu đề trục Y
            LabelStyle = { Format = "#,0" } // Hiển thị số định dạng có dấu phân cách nghìn
        }
            };

            // Thêm ChartArea vào biểu đồ
            chart1.ChartAreas.Add(chartArea);

            // Tạo một Series mới để vẽ biểu đồ cột
            Series series = new Series("Doanh Thu Theo Tháng")
            {
                ChartType = SeriesChartType.Column, // Loại biểu đồ cột
                IsValueShownAsLabel = true,         // Hiển thị giá trị trên các cột
                BorderWidth = 3,                   // Độ dày của viền cột
                LabelForeColor = System.Drawing.Color.Black, // Màu chữ hiển thị giá trị
                Color = System.Drawing.Color.Blue  // Màu của các cột
            };

            // Kiểm tra nếu danh sách doanh thu theo tháng có dữ liệu
            if (doanhThuTheoThang != null && doanhThuTheoThang.Count > 0)
            {
                foreach (var item in doanhThuTheoThang)
                {
                    // Thêm điểm dữ liệu vào biểu đồ cho mỗi tháng
                    series.Points.AddXY(item.Thang.ToString(), item.DoanhThu); // Trục X là tháng, trục Y là doanh thu
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu doanh thu cho tháng này!");
            }

            // Thêm Series vào biểu đồ
            chart1.Series.Add(series);
        }

    }
}
