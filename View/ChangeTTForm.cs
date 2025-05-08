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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace View
{
    public partial class ChangeTTForm : Form
    {
        private string userRole;
        private HOCVIEN hocVien;
        private PT pt;
        private HocVienBLL hocVienBLL = new HocVienBLL();
        private PTBLL ptBLL = new PTBLL();
        public ChangeTTForm()
        {
            InitializeComponent();
        }

        public void LoadData(object user, string role)
        {
            userRole = role;

            if (role == "HV")
            {

                hocVien = (HOCVIEN)user;
                txtRole.Text = role;
                txtRole.ReadOnly = true;
                txtuserid.Text = hocVien.UserID;
                txtHoten.Text = hocVien.HoTen;
                txtSDT.Text = hocVien.SDT;
                dateTimePicker1.Value = hocVien.NgaySinh ?? DateTime.Now;
                radioButton1.Checked = hocVien.Gender.GetValueOrDefault();
                radioButton2.Checked = !hocVien.Gender.GetValueOrDefault();
            }
            else if (role == "PT")
            {
                txtRole.Text = role;
                txtRole.ReadOnly = true;
                pt = (PT)user;
                txtuserid.Text = pt.UserID;
                txtHoten.Text = pt.HoTen;
                txtSDT.Text = pt.SDT;
                dateTimePicker1.Value = pt.NgaySinh ?? DateTime.Now;
                radioButton1.Checked = pt.Gender.GetValueOrDefault();
                radioButton2.Checked = !pt.Gender.GetValueOrDefault();
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            string userid = txtuserid.Text.Trim();
            string fullName = txtHoten.Text.Trim();
            string phone = txtSDT.Text.Trim();
            DateTime dob = dateTimePicker1.Value;
            bool gender = radioButton1.Checked;

            if (userRole == "HV")
            {

                hocVien.UserID = userid;
                hocVien.HoTen = fullName;
                hocVien.SDT = phone;
                hocVien.NgaySinh = dob;
                hocVien.Gender = gender;
                hocVienBLL.UpdateHocVien(hocVien);
                MessageBox.Show("Cập nhật thông tin học viên thành công!");
            }
            else if (userRole == "PT")
            {

                pt.UserID = userid;
                pt.HoTen = fullName;
                pt.SDT = phone;
                pt.NgaySinh = dob;
                pt.Gender = gender;
                ptBLL.UpdatePT(pt);
                MessageBox.Show("Cập nhật thông tin huấn luyện viên thành công!");
            }

            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
