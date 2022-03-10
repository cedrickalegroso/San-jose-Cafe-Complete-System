
namespace SJC
{
    partial class SJCAUTH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SJCAUTH));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SJCAUTHTXTUSER = new System.Windows.Forms.TextBox();
            this.BTNAUTHLOGIN = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SJCAUTHTXTPASS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(569, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(385, 449);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Rubik", 75F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.label1.Location = new System.Drawing.Point(642, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 126);
            this.label1.TabIndex = 1;
            this.label1.Text = "SJC";
            // 
            // SJCAUTHTXTUSER
            // 
            this.SJCAUTHTXTUSER.BackColor = System.Drawing.Color.White;
            this.SJCAUTHTXTUSER.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SJCAUTHTXTUSER.Font = new System.Drawing.Font("Rubik", 14F);
            this.SJCAUTHTXTUSER.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.SJCAUTHTXTUSER.Location = new System.Drawing.Point(29, 10);
            this.SJCAUTHTXTUSER.Margin = new System.Windows.Forms.Padding(10);
            this.SJCAUTHTXTUSER.Name = "SJCAUTHTXTUSER";
            this.SJCAUTHTXTUSER.Size = new System.Drawing.Size(251, 23);
            this.SJCAUTHTXTUSER.TabIndex = 2;
            this.SJCAUTHTXTUSER.Text = "Username";
            // 
            // BTNAUTHLOGIN
            // 
            this.BTNAUTHLOGIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.BTNAUTHLOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNAUTHLOGIN.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNAUTHLOGIN.ForeColor = System.Drawing.Color.White;
            this.BTNAUTHLOGIN.Location = new System.Drawing.Point(625, 522);
            this.BTNAUTHLOGIN.Name = "BTNAUTHLOGIN";
            this.BTNAUTHLOGIN.Size = new System.Drawing.Size(275, 43);
            this.BTNAUTHLOGIN.TabIndex = 4;
            this.BTNAUTHLOGIN.Text = "LOGIN";
            this.BTNAUTHLOGIN.UseVisualStyleBackColor = false;
            this.BTNAUTHLOGIN.Click += new System.EventHandler(this.BTNAUTHLOGIN_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SJCAUTHTXTUSER);
            this.panel1.Location = new System.Drawing.Point(625, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 42);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SJCAUTHTXTPASS);
            this.panel2.Location = new System.Drawing.Point(625, 442);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 42);
            this.panel2.TabIndex = 7;
            // 
            // SJCAUTHTXTPASS
            // 
            this.SJCAUTHTXTPASS.BackColor = System.Drawing.Color.White;
            this.SJCAUTHTXTPASS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SJCAUTHTXTPASS.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SJCAUTHTXTPASS.Font = new System.Drawing.Font("Rubik", 14F);
            this.SJCAUTHTXTPASS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.SJCAUTHTXTPASS.Location = new System.Drawing.Point(30, 10);
            this.SJCAUTHTXTPASS.Margin = new System.Windows.Forms.Padding(10);
            this.SJCAUTHTXTPASS.Name = "SJCAUTHTXTPASS";
            this.SJCAUTHTXTPASS.PasswordChar = '*';
            this.SJCAUTHTXTPASS.Size = new System.Drawing.Size(251, 23);
            this.SJCAUTHTXTPASS.TabIndex = 2;
            this.SJCAUTHTXTPASS.Text = "123";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.label2.Font = new System.Drawing.Font("Rubik", 8F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.label2.Location = new System.Drawing.Point(707, 622);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "San Jose Clinic 2022";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.button2.Location = new System.Drawing.Point(727, 687);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "DEVMODE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SJC.Properties.Resources.Icon_ionic_md_close;
            this.pictureBox2.Location = new System.Drawing.Point(1560, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 24);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SJC.Properties.Resources.Mask_Group_1;
            this.pictureBox1.Location = new System.Drawing.Point(1030, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(570, 798);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SJC.Properties.Resources.Icon_feather_minimize_2;
            this.pictureBox3.Location = new System.Drawing.Point(1526, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 24);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // SJCAUTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTNAUTHLOGIN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SJCAUTH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SJC";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SJCAUTHTXTUSER;
        private System.Windows.Forms.Button BTNAUTHLOGIN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox SJCAUTHTXTPASS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

