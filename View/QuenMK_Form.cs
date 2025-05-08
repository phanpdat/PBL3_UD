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
    public partial class QuenMK_Form : Form
    {
        private USER user;
        private PT pt;
        private HOCVIEN hocvien;
        public QuenMK_Form(USER user, PT pt, HOCVIEN hocvien)
        {
            InitializeComponent();
            this.user = user;
            this.pt = pt;
            this.hocvien = hocvien;
            loadTT();
        }

        void loadTT()
        {
            if (pt != null)
            {
                loadTTpt();
            }
            else
            {

                loadTTHv();
            }
        }

        void loadTTHv()
        {
            txtPass.Text = user.Password;
            txtUsername.Text = user.UserID;
            txtTenPT.Text = hocvien.HoTen;
            txtPass.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtTenPT.ReadOnly = true;
        }

        void loadTTpt()
        {
            txtPass.Text = user.Password;
            txtUsername.Text = user.UserID;
            txtTenPT.Text = pt.HoTen;
            txtPass.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtTenPT.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
