﻿
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
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(715, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(385, 449);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Rubik", 75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(789, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 126);
            this.label1.TabIndex = 1;
            this.label1.Text = "SJC";
            // 
            // SJCAUTHTXTUSER
            // 
            this.SJCAUTHTXTUSER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.SJCAUTHTXTUSER.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SJCAUTHTXTUSER.Font = new System.Drawing.Font("Rubik", 14F);
            this.SJCAUTHTXTUSER.ForeColor = System.Drawing.Color.White;
            this.SJCAUTHTXTUSER.Location = new System.Drawing.Point(10, 5);
            this.SJCAUTHTXTUSER.Margin = new System.Windows.Forms.Padding(10);
            this.SJCAUTHTXTUSER.Name = "SJCAUTHTXTUSER";
            this.SJCAUTHTXTUSER.Size = new System.Drawing.Size(251, 23);
            this.SJCAUTHTXTUSER.TabIndex = 2;
            // 
            // BTNAUTHLOGIN
            // 
            this.BTNAUTHLOGIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.BTNAUTHLOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNAUTHLOGIN.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNAUTHLOGIN.ForeColor = System.Drawing.Color.White;
            this.BTNAUTHLOGIN.Location = new System.Drawing.Point(771, 519);
            this.BTNAUTHLOGIN.Name = "BTNAUTHLOGIN";
            this.BTNAUTHLOGIN.Size = new System.Drawing.Size(275, 43);
            this.BTNAUTHLOGIN.TabIndex = 4;
            this.BTNAUTHLOGIN.Text = "LOGIN";
            this.BTNAUTHLOGIN.UseVisualStyleBackColor = false;
            this.BTNAUTHLOGIN.Click += new System.EventHandler(this.BTNAUTHLOGIN_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.SJCAUTHTXTUSER);
            this.panel1.Location = new System.Drawing.Point(771, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 42);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.SJCAUTHTXTPASS);
            this.panel2.Location = new System.Drawing.Point(771, 439);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 42);
            this.panel2.TabIndex = 7;
            // 
            // SJCAUTHTXTPASS
            // 
            this.SJCAUTHTXTPASS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.SJCAUTHTXTPASS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SJCAUTHTXTPASS.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.SJCAUTHTXTPASS.Font = new System.Drawing.Font("Rubik", 14F);
            this.SJCAUTHTXTPASS.ForeColor = System.Drawing.Color.White;
            this.SJCAUTHTXTPASS.Location = new System.Drawing.Point(11, 10);
            this.SJCAUTHTXTPASS.Margin = new System.Windows.Forms.Padding(10);
            this.SJCAUTHTXTPASS.Name = "SJCAUTHTXTPASS";
            this.SJCAUTHTXTPASS.PasswordChar = '*';
            this.SJCAUTHTXTPASS.Size = new System.Drawing.Size(251, 23);
            this.SJCAUTHTXTPASS.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rubik", 8F);
            this.label2.Location = new System.Drawing.Point(853, 619);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "San Jose Clinic 2022";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(869, 682);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "DEVMODE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SJCAUTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(1600, 900);
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
    }
}

