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
    public partial class Change_LH_Form : Form
    {
        private int lichHocID;
        private List<LichHocHV_View> lichHocList;
        private PTBLL PTBLL = new PTBLL();
        private LichHocBLL lichHocBLL = new LichHocBLL();
        public Change_LH_Form(int lichHocID, List<LichHocHV_View> lichHocList)
        {
            InitializeComponent();
            this.lichHocID = lichHocID;
            this.lichHocList = lichHocList;
            LoadThuComboBox();
            LoadBuoiComboBox();
            LoadPTToDataGridView();
            LoadLichHocInfo();
        }

        private void LoadLichHocInfo()
        {
            textBox1.Text = lichHocID.ToString();
            var lichHoc = lichHocBLL.GetLichHocById(lichHocID);

            if (lichHoc != null)
            {

                comboBox1.SelectedItem = lichHoc.ThuHoc;
                comboBox2.SelectedItem = lichHoc.BuoiHoc;
            }
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



        private void LoadPTToDataGridView()
        {

            var ptList = PTBLL.GetAllPT();


            dataGridView1.DataSource = ptList;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            string thuHoc = comboBox1.SelectedItem.ToString();
            string buoiHoc = comboBox2.SelectedItem.ToString();
            DateTime ngayDangKy = DateTime.Now.Date;
            int ptID;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ptID = (int)dataGridView1.SelectedRows[0].Cells["PTID"].Value;
            }
            else
            {
                ptID = lichHocBLL.GetLichHocById(lichHocID).PTID.GetValueOrDefault();
            }

            bool isDuplicate = lichHocList.Any(lh => lh.ThuHoc == thuHoc && lh.BuoiHoc == buoiHoc);
            if (isDuplicate)
            {
                MessageBox.Show("Lịch học này đã tồn tại, vui lòng chọn lịch học khác.");
                return;
            }

            try
            {
                lichHocBLL.UpdateLichHoc(lichHocID, thuHoc, buoiHoc, ngayDangKy, ptID);
                MessageBox.Show("Lịch học đã được thay đổi thành công.");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
    }
}
