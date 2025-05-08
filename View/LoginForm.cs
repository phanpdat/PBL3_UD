using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class LoginForm : Form
    {
        private UserGymBLL userGymBLL = new UserGymBLL();
        private HocVienBLL hocVienBLL = new HocVienBLL();
        private PTBLL ptBLL = new PTBLL();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = txtusername.Text;
                string password = txtPass.Text;

                if (userGymBLL.Login(userID, password))
                {
                    string role = userGymBLL.GetUserRole(userID);
                    HOCVIEN hocVien = null;
                    PT pt = null;
                    if (role == "HV")
                    {
                        hocVien = hocVienBLL.GetHocVienByUserID(userID);

                        HocVienForm hocVienForm = new HocVienForm(hocVien);
                        hocVienForm.Show();
                    }
                    else if (role == "PT")
                    {
                        pt = ptBLL.GetPTByUserID(userID);

                        PTForm ptForm = new PTForm(pt);
                        ptForm.Show();
                    }
                    else if (role == "Admin")
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

    }
}
