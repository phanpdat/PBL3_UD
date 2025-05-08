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
    public partial class addTBForm : Form
    {
        public THIETBI Result { get; private set; }
        private bool isEditMode = false;
        private readonly ThietBiBLL bll= new ThietBiBLL();
        public addTBForm()
        {
            InitializeComponent();
        }

        public void LoadDataForEdit(THIETBI tb)
        {
            isEditMode = true;
            Result = tb;


            txtTB.Text = tb.TenThietBi;
            txtSl.Text = tb.SoLuong.ToString();
            txtGood.Text = tb.SoLuongTot.ToString();
            txtHong.Text = tb.SoLuongHong.ToString();
        }

        private bool ValidateData(out int tong, out int tot, out int hong)
        {
            tong = 0; tot = 0; hong = 0;

            if (string.IsNullOrWhiteSpace(txtTB.Text))
            {
                MessageBox.Show("Tên thiết bị không được để trống.");
                return false;
            }

            if (!int.TryParse(txtSl.Text, out tong) || !int.TryParse(txtGood.Text, out tot) || !int.TryParse(txtHong.Text, out hong))
            {
                MessageBox.Show("Số lượng phải là số nguyên.");
                return false;
            }

            if (tot + hong != tong)
            {
                MessageBox.Show("Tổng số lượng thiết bị phải bằng số lượng tốt cộng số lượng hỏng.");
                return false;
            }

            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateData(out int tong, out int tot, out int hong)) return;

            if (Result == null) Result = new THIETBI();

            Result.TenThietBi = txtTB.Text.Trim();
            Result.SoLuong = tong;
            Result.SoLuongTot = tot;
            Result.SoLuongHong = hong;


            if (isEditMode)
            {
                bll.Update(Result);
            }
            else
            {
                bll.Add(Result);
                MessageBox.Show("Thêm thiết bị thành công!");
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
