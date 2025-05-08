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
    public partial class PTForm : Form
    {
        private PT pt;
        private LichHocBLL lichHocBLL = new LichHocBLL();
        public PTForm(PT pt)
        {
            InitializeComponent();
            
            this.pt = pt;
        }
        private void PTForm_Load(object sender, EventArgs e)
        {
            LoadLichHoc();
            LoadTTPT();
        }

        void LoadTTPT()
        {
            lblhoten.Text = pt.HoTen;
            lblusername.Text = pt.UserID;
            lblgender.Text = pt.Gender.GetValueOrDefault() ? "Nam" : "Nữ";
            lblNS.Text = pt.NgaySinh.HasValue ? pt.NgaySinh.Value.ToString("dd/MM/yyyy") : "N/A";
            lblSDT.Text = pt.SDT;

        }

        private void LoadLichHoc()
        {

            var lichHocList = lichHocBLL.GetAllLichPTByPTID(pt.PTID);


            dataGridView1.DataSource = lichHocList.Select(lh => new
            {
                lh.HoTenPT,
                lh.ThuHoc,
                lh.BuoiHoc,
                lh.SoLuongHocVien,
                lh.GioHoc
            }).ToList();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            changePasswordForm changePasswordForm = new changePasswordForm(pt.UserID);
            changePasswordForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnDoiTT_Click(object sender, EventArgs e)
        {

            ChangeTTForm changeTTForm = new ChangeTTForm();
            changeTTForm.LoadData(pt, "PT");
            changeTTForm.ShowDialog();
            LoadTTPT();
        }

        private void btnDeTail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                var selectedRow = dataGridView1.SelectedRows[0];
                string hoTenPT = (string)selectedRow.Cells["HoTenPT"].Value;
                string thuHoc = (string)selectedRow.Cells["ThuHoc"].Value;
                string buoiHoc = (string)selectedRow.Cells["BuoiHoc"].Value;

                LichDetailForm lichDetailForm = new LichDetailForm(hoTenPT, thuHoc, buoiHoc);
                lichDetailForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lịch học để xem chi tiết.");
            }
        }
    }
}
