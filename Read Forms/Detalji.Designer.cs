namespace Roba.Read_Forms
{
    partial class Detalji
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
            this.txtBox_Detalji = new System.Windows.Forms.RichTextBox();
            this.lbl_Detalji_Za = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_X = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Dodaj = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBox_Detalji
            // 
            this.txtBox_Detalji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.txtBox_Detalji.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_Detalji.Location = new System.Drawing.Point(134, 96);
            this.txtBox_Detalji.Name = "txtBox_Detalji";
            this.txtBox_Detalji.Size = new System.Drawing.Size(549, 267);
            this.txtBox_Detalji.TabIndex = 45;
            this.txtBox_Detalji.Text = "";
            // 
            // lbl_Detalji_Za
            // 
            this.lbl_Detalji_Za.AutoSize = true;
            this.lbl_Detalji_Za.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Detalji_Za.Font = new System.Drawing.Font("Elkwood", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Detalji_Za.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(80)))), ((int)(((byte)(1)))));
            this.lbl_Detalji_Za.Location = new System.Drawing.Point(97, 47);
            this.lbl_Detalji_Za.Name = "lbl_Detalji_Za";
            this.lbl_Detalji_Za.Size = new System.Drawing.Size(108, 20);
            this.lbl_Detalji_Za.TabIndex = 46;
            this.lbl_Detalji_Za.Text = "DETALJI ZA:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(91, 421);
            this.panel1.TabIndex = 47;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(91, 67);
            this.panel2.TabIndex = 2;
            // 
            // btn_X
            // 
            this.btn_X.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_X.FlatAppearance.BorderSize = 0;
            this.btn_X.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_X.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_X.Location = new System.Drawing.Point(39, -1);
            this.btn_X.Name = "btn_X";
            this.btn_X.Size = new System.Drawing.Size(36, 26);
            this.btn_X.TabIndex = 0;
            this.btn_X.UseVisualStyleBackColor = true;
            this.btn_X.Click += new System.EventHandler(this.btn_X_Click);
            this.btn_X.MouseEnter += new System.EventHandler(this.btn_X_MouseEnter);
            this.btn_X.MouseLeave += new System.EventHandler(this.btn_X_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_X);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(717, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(74, 421);
            this.panel3.TabIndex = 48;
            // 
            // btn_Dodaj
            // 
            this.btn_Dodaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(81)))), ((int)(((byte)(25)))));
            this.btn_Dodaj.FlatAppearance.BorderSize = 0;
            this.btn_Dodaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dodaj.Font = new System.Drawing.Font("Elkwood", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Dodaj.ForeColor = System.Drawing.Color.White;
            this.btn_Dodaj.Location = new System.Drawing.Point(582, 371);
            this.btn_Dodaj.Name = "btn_Dodaj";
            this.btn_Dodaj.Size = new System.Drawing.Size(129, 38);
            this.btn_Dodaj.TabIndex = 49;
            this.btn_Dodaj.Text = "SPREMI";
            this.btn_Dodaj.UseVisualStyleBackColor = false;
            this.btn_Dodaj.Click += new System.EventHandler(this.btn_Dodaj_Click);
            // 
            // Detalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(791, 421);
            this.Controls.Add(this.btn_Dodaj);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Detalji_Za);
            this.Controls.Add(this.txtBox_Detalji);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Detalji";
            this.Text = "Detalji";
            this.Load += new System.EventHandler(this.Detalji_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtBox_Detalji;
        private System.Windows.Forms.Label lbl_Detalji_Za;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_X;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Dodaj;
    }
}