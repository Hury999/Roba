namespace Roba.Edit
{
    partial class Edit_Menu
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
            this.lbl_Edit = new System.Windows.Forms.Label();
            this.lbl_Strelica = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Design = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Edit
            // 
            this.lbl_Edit.AutoSize = true;
            this.lbl_Edit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Edit.Font = new System.Drawing.Font("Elkwood", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(80)))), ((int)(((byte)(1)))));
            this.lbl_Edit.Location = new System.Drawing.Point(4, 18);
            this.lbl_Edit.Name = "lbl_Edit";
            this.lbl_Edit.Size = new System.Drawing.Size(44, 20);
            this.lbl_Edit.TabIndex = 33;
            this.lbl_Edit.Text = "Edit";
            // 
            // lbl_Strelica
            // 
            this.lbl_Strelica.AutoSize = true;
            this.lbl_Strelica.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Strelica.Font = new System.Drawing.Font("EngraversGothic BT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Strelica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(80)))), ((int)(((byte)(1)))));
            this.lbl_Strelica.Location = new System.Drawing.Point(3, 4);
            this.lbl_Strelica.Name = "lbl_Strelica";
            this.lbl_Strelica.Size = new System.Drawing.Size(32, 22);
            this.lbl_Strelica.TabIndex = 34;
            this.lbl_Strelica.Text = "^";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Design);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 243);
            this.panel1.TabIndex = 35;
            // 
            // btn_Design
            // 
            this.btn_Design.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(81)))), ((int)(((byte)(25)))));
            this.btn_Design.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Design.FlatAppearance.BorderSize = 0;
            this.btn_Design.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Design.Font = new System.Drawing.Font("Elkwood", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Design.ForeColor = System.Drawing.Color.White;
            this.btn_Design.Location = new System.Drawing.Point(0, 0);
            this.btn_Design.Name = "btn_Design";
            this.btn_Design.Size = new System.Drawing.Size(232, 38);
            this.btn_Design.TabIndex = 32;
            this.btn_Design.Text = "DESIGN";
            this.btn_Design.UseVisualStyleBackColor = false;
            this.btn_Design.Click += new System.EventHandler(this.btn_Design_Click);
            // 
            // Edit_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(232, 284);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Edit);
            this.Controls.Add(this.lbl_Strelica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Edit_Menu";
            this.Text = "Edit_Menu";
            this.Load += new System.EventHandler(this.Edit_Menu_Load);
            this.Leave += new System.EventHandler(this.Edit_Menu_Leave);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Edit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Design;
        public System.Windows.Forms.Label lbl_Strelica;
    }
}