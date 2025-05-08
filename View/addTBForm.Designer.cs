namespace View
{
    partial class addTBForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtHong = new System.Windows.Forms.TextBox();
            this.txtGood = new System.Windows.Forms.TextBox();
            this.txtSl = new System.Windows.Forms.TextBox();
            this.txtTB = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "Số lượng bảo trì";
            // 
            // txtHong
            // 
            this.txtHong.Location = new System.Drawing.Point(212, 342);
            this.txtHong.Name = "txtHong";
            this.txtHong.Size = new System.Drawing.Size(167, 22);
            this.txtHong.TabIndex = 42;
            // 
            // txtGood
            // 
            this.txtGood.Location = new System.Drawing.Point(212, 283);
            this.txtGood.Name = "txtGood";
            this.txtGood.Size = new System.Drawing.Size(167, 22);
            this.txtGood.TabIndex = 41;
            // 
            // txtSl
            // 
            this.txtSl.Location = new System.Drawing.Point(212, 219);
            this.txtSl.Name = "txtSl";
            this.txtSl.Size = new System.Drawing.Size(167, 22);
            this.txtSl.TabIndex = 40;
            // 
            // txtTB
            // 
            this.txtTB.Location = new System.Drawing.Point(212, 162);
            this.txtTB.Name = "txtTB";
            this.txtTB.Size = new System.Drawing.Size(167, 22);
            this.txtTB.TabIndex = 39;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(262, 405);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(93, 39);
            this.btnHuy.TabIndex = 38;
            this.btnHuy.Text = "Cancel";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(76, 405);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 39);
            this.btnOK.TabIndex = 37;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "Số Lượng Hoạt Động";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Số Lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tên Thiết Bị";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 49);
            this.label1.TabIndex = 33;
            this.label1.Text = "Thiết Bị";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addTBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 502);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHong);
            this.Controls.Add(this.txtGood);
            this.Controls.Add(this.txtSl);
            this.Controls.Add(this.txtTB);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "addTBForm";
            this.Text = "addTBForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHong;
        private System.Windows.Forms.TextBox txtGood;
        private System.Windows.Forms.TextBox txtSl;
        private System.Windows.Forms.TextBox txtTB;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}