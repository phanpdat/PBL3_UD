namespace View
{
    partial class QLPT_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLPT_Form));
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnDeTail = new System.Windows.Forms.Button();
            this.btnDoiTT = new System.Windows.Forms.Button();
            this.btnQuenMK = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.lblNDK = new System.Windows.Forms.Label();
            this.lblGT = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblNS = new System.Windows.Forms.Label();
            this.lblgender = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblhoten = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(809, 533);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(141, 39);
            this.btnLogout.TabIndex = 86;
            this.btnLogout.Text = "Thoát";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnDeTail
            // 
            this.btnDeTail.Location = new System.Drawing.Point(590, 533);
            this.btnDeTail.Name = "btnDeTail";
            this.btnDeTail.Size = new System.Drawing.Size(131, 39);
            this.btnDeTail.TabIndex = 85;
            this.btnDeTail.Text = "Xem Chi Tiết";
            this.btnDeTail.UseVisualStyleBackColor = true;
            this.btnDeTail.Click += new System.EventHandler(this.btnDeTail_Click);
            // 
            // btnDoiTT
            // 
            this.btnDoiTT.Location = new System.Drawing.Point(366, 536);
            this.btnDoiTT.Name = "btnDoiTT";
            this.btnDoiTT.Size = new System.Drawing.Size(143, 38);
            this.btnDoiTT.TabIndex = 84;
            this.btnDoiTT.Text = "Đổi Thông Tin";
            this.btnDoiTT.UseVisualStyleBackColor = true;
            this.btnDoiTT.Click += new System.EventHandler(this.btnDoiTT_Click);
            // 
            // btnQuenMK
            // 
            this.btnQuenMK.Location = new System.Drawing.Point(156, 536);
            this.btnQuenMK.Name = "btnQuenMK";
            this.btnQuenMK.Size = new System.Drawing.Size(123, 37);
            this.btnQuenMK.TabIndex = 83;
            this.btnQuenMK.Text = "Quên Mật Khẩu";
            this.btnQuenMK.UseVisualStyleBackColor = true;
            this.btnQuenMK.Click += new System.EventHandler(this.btnQuenMK_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(156, 280);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(794, 229);
            this.dataGridView1.TabIndex = 82;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(360, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(404, 35);
            this.label10.TabIndex = 81;
            this.label10.Text = "Lịch Dạy Huấn Luyện Viên";
            // 
            // lblNDK
            // 
            this.lblNDK.AutoSize = true;
            this.lblNDK.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNDK.Location = new System.Drawing.Point(850, 160);
            this.lblNDK.Name = "lblNDK";
            this.lblNDK.Size = new System.Drawing.Size(29, 15);
            this.lblNDK.TabIndex = 80;
            this.lblNDK.Text = "N/A";
            // 
            // lblGT
            // 
            this.lblGT.AutoSize = true;
            this.lblGT.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGT.Location = new System.Drawing.Point(850, 121);
            this.lblGT.Name = "lblGT";
            this.lblGT.Size = new System.Drawing.Size(83, 15);
            this.lblGT.TabIndex = 79;
            this.lblGT.Text = "Thứ 2 - Thứ 7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(654, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 16);
            this.label8.TabIndex = 78;
            this.label8.Text = "Tổng Học Viên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(654, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 18);
            this.label7.TabIndex = 77;
            this.label7.Text = "Lịch Làm Việc";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(376, 186);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(51, 16);
            this.lblSDT.TabIndex = 76;
            this.lblSDT.Text = "label11";
            // 
            // lblNS
            // 
            this.lblNS.AutoSize = true;
            this.lblNS.Location = new System.Drawing.Point(376, 149);
            this.lblNS.Name = "lblNS";
            this.lblNS.Size = new System.Drawing.Size(51, 16);
            this.lblNS.TabIndex = 75;
            this.lblNS.Text = "label10";
            // 
            // lblgender
            // 
            this.lblgender.AutoSize = true;
            this.lblgender.Location = new System.Drawing.Point(376, 111);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(44, 16);
            this.lblgender.TabIndex = 74;
            this.lblgender.Text = "label9";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Location = new System.Drawing.Point(376, 77);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(81, 16);
            this.lblusername.TabIndex = 73;
            this.lblusername.Text = "lblusername";
            // 
            // lblhoten
            // 
            this.lblhoten.AutoSize = true;
            this.lblhoten.Location = new System.Drawing.Point(376, 48);
            this.lblhoten.Name = "lblhoten";
            this.lblhoten.Size = new System.Drawing.Size(54, 16);
            this.lblhoten.TabIndex = 72;
            this.lblhoten.Text = "lblhoten";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(242, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 71;
            this.label6.Text = "SĐT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(242, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 70;
            this.label5.Text = "Ngày Sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(242, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 69;
            this.label4.Text = "Giới Tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(242, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "Họ Tên:";
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(510, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 54);
            this.label1.TabIndex = 66;
            this.label1.Text = "Huấn Luyện Viên GYM";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(73, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 158);
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // QLPT_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 613);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnDeTail);
            this.Controls.Add(this.btnDoiTT);
            this.Controls.Add(this.btnQuenMK);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblNDK);
            this.Controls.Add(this.lblGT);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblNS);
            this.Controls.Add(this.lblgender);
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.lblhoten);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "QLPT_Form";
            this.Text = "QLPT_Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnDeTail;
        private System.Windows.Forms.Button btnDoiTT;
        private System.Windows.Forms.Button btnQuenMK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblNDK;
        private System.Windows.Forms.Label lblGT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblNS;
        private System.Windows.Forms.Label lblgender;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblhoten;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}