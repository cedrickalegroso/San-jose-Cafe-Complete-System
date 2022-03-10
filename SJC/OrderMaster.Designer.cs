
namespace SJC
{
    partial class OrderMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.OrderPatient = new System.Windows.Forms.TextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.OrderCash = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.dashbboardTopName = new System.Windows.Forms.Label();
            this.changeText = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.orderMod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.orderDetails = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Rubik", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Rubik", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(50, 55);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Rubik", 12F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.Size = new System.Drawing.Size(1100, 290);
            this.dataGridView1.TabIndex = 102;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SJC.Properties.Resources.Icon_feather_minimize_2;
            this.pictureBox1.Location = new System.Drawing.Point(1134, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 24);
            this.pictureBox1.TabIndex = 104;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SJC.Properties.Resources.Icon_ionic_md_close;
            this.pictureBox2.Location = new System.Drawing.Point(1168, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 24);
            this.pictureBox2.TabIndex = 103;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // OrderPatient
            // 
            this.OrderPatient.BackColor = System.Drawing.Color.White;
            this.OrderPatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OrderPatient.Font = new System.Drawing.Font("Rubik", 12F);
            this.OrderPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.OrderPatient.Location = new System.Drawing.Point(10, 10);
            this.OrderPatient.Margin = new System.Windows.Forms.Padding(10);
            this.OrderPatient.Name = "OrderPatient";
            this.OrderPatient.Size = new System.Drawing.Size(143, 19);
            this.OrderPatient.TabIndex = 2;
            this.OrderPatient.Text = "Customer ID";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.White;
            this.panel13.Controls.Add(this.OrderPatient);
            this.panel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.panel13.Location = new System.Drawing.Point(50, 373);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(167, 42);
            this.panel13.TabIndex = 105;
            // 
            // OrderCash
            // 
            this.OrderCash.BackColor = System.Drawing.Color.White;
            this.OrderCash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OrderCash.Font = new System.Drawing.Font("Rubik", 12F);
            this.OrderCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.OrderCash.Location = new System.Drawing.Point(10, 10);
            this.OrderCash.Margin = new System.Windows.Forms.Padding(10);
            this.OrderCash.Name = "OrderCash";
            this.OrderCash.Size = new System.Drawing.Size(174, 19);
            this.OrderCash.TabIndex = 2;
            this.OrderCash.Text = "Cash";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Controls.Add(this.OrderCash);
            this.panel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.panel14.Location = new System.Drawing.Point(223, 373);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(194, 42);
            this.panel14.TabIndex = 106;
            // 
            // dashbboardTopName
            // 
            this.dashbboardTopName.AutoSize = true;
            this.dashbboardTopName.Font = new System.Drawing.Font("Rubik SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashbboardTopName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.dashbboardTopName.Location = new System.Drawing.Point(46, 12);
            this.dashbboardTopName.Name = "dashbboardTopName";
            this.dashbboardTopName.Size = new System.Drawing.Size(179, 24);
            this.dashbboardTopName.TabIndex = 107;
            this.dashbboardTopName.Text = "Order Confimation";
            // 
            // changeText
            // 
            this.changeText.AutoSize = true;
            this.changeText.Font = new System.Drawing.Font("Rubik SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.changeText.Location = new System.Drawing.Point(988, 386);
            this.changeText.Name = "changeText";
            this.changeText.Size = new System.Drawing.Size(86, 24);
            this.changeText.TabIndex = 108;
            this.changeText.Text = "Change:";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Rubik SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.txtTotal.Location = new System.Drawing.Point(795, 386);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(61, 24);
            this.txtTotal.TabIndex = 109;
            this.txtTotal.Text = "Total:";
            // 
            // orderMod
            // 
            this.orderMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.orderMod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.orderMod.FormattingEnabled = true;
            this.orderMod.Items.AddRange(new object[] {
            "Cash",
            "Gcash",
            "Bank Transfer"});
            this.orderMod.Location = new System.Drawing.Point(427, 383);
            this.orderMod.Name = "orderMod";
            this.orderMod.Size = new System.Drawing.Size(147, 32);
            this.orderMod.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rubik SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.label3.Location = new System.Drawing.Point(423, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 19);
            this.label3.TabIndex = 111;
            this.label3.Text = "Mode of Payment";
            // 
            // orderDetails
            // 
            this.orderDetails.AutoSize = true;
            this.orderDetails.Font = new System.Drawing.Font("Rubik SemiBold", 8F, System.Drawing.FontStyle.Bold);
            this.orderDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.orderDetails.Location = new System.Drawing.Point(849, 410);
            this.orderDetails.Name = "orderDetails";
            this.orderDetails.Size = new System.Drawing.Size(57, 13);
            this.orderDetails.TabIndex = 112;
            this.orderDetails.Text = "+ 12% Vat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rubik SemiBold", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.label4.Location = new System.Drawing.Point(47, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "10% Discount on Patients";
            // 
            // Submit
            // 
            this.Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Submit.Location = new System.Drawing.Point(589, 382);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(98, 33);
            this.Submit.TabIndex = 114;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // OrderMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1208, 450);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.orderDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.orderMod);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.changeText);
            this.Controls.Add(this.dashbboardTopName);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderMaster";
            this.Load += new System.EventHandler(this.OrderMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox OrderPatient;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox OrderCash;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label dashbboardTopName;
        private System.Windows.Forms.Label changeText;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.ComboBox orderMod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label orderDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Submit;
    }
}