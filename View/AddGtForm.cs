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
    public partial class AddGtForm : Form
    {
        public GOITAP Result { get; private set; }
        private bool isEditMode = false;
        private GoiTapBLL bll = new GoiTapBLL(); 
        public AddGtForm()
        {
            InitializeComponent();
        }

        public void LoadData(GOITAP gt)
        {
            isEditMode = true;
            this.Text = "Sửa Gói Tập";
            Result = gt;

            textBox1.Text = gt.TenGoTap;
            textBox2.Text = gt.Gia.ToString();
            textBox3.Text = gt.ThoiLuong.ToString();
        }

        private bool IsValidData()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }

            if (!decimal.TryParse(textBox2.Text.Trim(), out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Giá tiền không hợp lệ. Vui lòng nhập giá lớn hơn 0.");
                return false;
            }

            if (!int.TryParse(textBox3.Text.Trim(), out int thoiLuong) || thoiLuong <= 0)
            {
                MessageBox.Show("Thời gian phải là số nguyên dương lớn hơn 0.");
                return false;
            }

            return true;
        }
        private decimal ParseGia(string giaText)
        {
            giaText = giaText.Replace(" VND", "").Replace(",", "").Trim();
            if (!decimal.TryParse(giaText, out decimal gia))
            {
                MessageBox.Show("Giá tiền không hợp lệ.");
                return 0;
            }

            return gia;
        }

        private void AddNewGoiTap(decimal gia, int thoiLuong)
        {
            GOITAP newGoiTap = new GOITAP
            {
                TenGoTap = textBox1.Text.Trim(),
                Gia = gia,
                ThoiLuong = thoiLuong
            };

            bll.Add(newGoiTap);
            MessageBox.Show("Thêm gói tập thành công!");
        }

        private void btnOKGt_Click(object sender, EventArgs e)
        {
            if (!IsValidData()) return;

            decimal gia = ParseGia(textBox2.Text);
            int thoiLuong = int.Parse(textBox3.Text.Trim());

            if (isEditMode)
            {
                Result.TenGoTap = textBox1.Text.Trim();
                Result.Gia = gia;
                Result.ThoiLuong = thoiLuong;


                bll.Update(Result);

                MessageBox.Show("Cập nhật gói tập thành công!");
            }
            else
            {
                AddNewGoiTap(gia, thoiLuong);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
