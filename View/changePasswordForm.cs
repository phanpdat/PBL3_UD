using BLL;
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
    public partial class changePasswordForm : Form
    {
        private string userID;
        public changePasswordForm(string userID)
        {
            InitializeComponent();
            this.userID = userID;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userid = txtusername.Text.Trim();
            string password = txtPass.Text;
            string confirmPassword = txtComfirm.Text;
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtComfirm.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }
            if (userID != userid)
            {
                {
                    MessageBox.Show("Tên đăng nhập không đúng.");
                    return;
                }
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.");
                return;
            }
            UserGymBLL bll = new UserGymBLL();
            bool isUpdated = bll.ChangePassword(userID, password);

            if (isUpdated)
            {
                MessageBox.Show("Mật khẩu đã được thay đổi thành công.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể thay đổi mật khẩu.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
