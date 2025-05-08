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
    public partial class RegisterForm : Form
    {
        private HocVienBLL hocVienBLL;
        private UserGymBLL userGymBLL;
        private PTBLL ptBLL;
        public RegisterForm()
        {
            InitializeComponent();
            userGymBLL = new UserGymBLL();
            hocVienBLL = new HocVienBLL();
            ptBLL = new PTBLL();
            cbbVaitro.Items.Add("HV");
            cbbVaitro.Items.Add("PT");
            cbbVaitro.SelectedIndex = 0;
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            try
            {
                string role = cbbVaitro.SelectedItem.ToString();
                string userID = txtuserid.Text;
                string fullName = txtHoten.Text;
                string phone = txtSDT.Text;
                DateTime dob = dateTimePicker1.Value;
                string password = txtPassword.Text;
                bool gender = radioButton1.Checked ? true : false;

                if (string.IsNullOrWhiteSpace(userID) || string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                userGymBLL.AddUser(userID, password, role);

                if (role == "HV")
                {
                    hocVienBLL.AddHocVien(new HOCVIEN
                    {
                        UserID = userID,
                        HoTen = fullName,
                        SDT = phone,
                        NgaySinh = dob,
                        Gender = gender,
                        IsRegistered = false,
                        IsPaid = false
                    });
                }
                else if (role == "PT")
                {
                    ptBLL.AddPT(new PT
                    {
                        UserID = userID,
                        HoTen = fullName,
                        SDT = phone,
                        NgaySinh = dob,
                        Gender = gender
                    });
                }

                MessageBox.Show("Đăng ký thành công!");

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
