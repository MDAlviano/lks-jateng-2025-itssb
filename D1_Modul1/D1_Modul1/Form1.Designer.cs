namespace D1_Modul1
{
    partial class Form1
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
            this.bTableSeating = new System.Windows.Forms.Button();
            this.bMenu = new System.Windows.Forms.Button();
            this.bHistory = new System.Windows.Forms.Button();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // bTableSeating
            // 
            this.bTableSeating.AutoEllipsis = true;
            this.bTableSeating.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bTableSeating.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTableSeating.ForeColor = System.Drawing.Color.White;
            this.bTableSeating.Location = new System.Drawing.Point(49, 38);
            this.bTableSeating.Name = "bTableSeating";
            this.bTableSeating.Size = new System.Drawing.Size(120, 120);
            this.bTableSeating.TabIndex = 0;
            this.bTableSeating.Text = "TABLE SEATING";
            this.bTableSeating.UseVisualStyleBackColor = false;
            this.bTableSeating.Click += new System.EventHandler(this.bTableSeating_Click);
            // 
            // bMenu
            // 
            this.bMenu.AutoEllipsis = true;
            this.bMenu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMenu.ForeColor = System.Drawing.Color.White;
            this.bMenu.Location = new System.Drawing.Point(49, 209);
            this.bMenu.Name = "bMenu";
            this.bMenu.Size = new System.Drawing.Size(120, 120);
            this.bMenu.TabIndex = 1;
            this.bMenu.Text = "MENU";
            this.bMenu.UseVisualStyleBackColor = false;
            this.bMenu.Click += new System.EventHandler(this.bMenu_Click);
            // 
            // bHistory
            // 
            this.bHistory.AutoEllipsis = true;
            this.bHistory.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHistory.ForeColor = System.Drawing.Color.White;
            this.bHistory.Location = new System.Drawing.Point(49, 384);
            this.bHistory.Name = "bHistory";
            this.bHistory.Size = new System.Drawing.Size(120, 120);
            this.bHistory.TabIndex = 2;
            this.bHistory.Text = "HISTORY";
            this.bHistory.UseVisualStyleBackColor = false;
            this.bHistory.Click += new System.EventHandler(this.bHistory_Click);
            // 
            // flpMain
            // 
            this.flpMain.Location = new System.Drawing.Point(225, 0);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(900, 550);
            this.flpMain.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1128, 548);
            this.Controls.Add(this.flpMain);
            this.Controls.Add(this.bHistory);
            this.Controls.Add(this.bMenu);
            this.Controls.Add(this.bTableSeating);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HovSedhep POS System";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bTableSeating;
        private System.Windows.Forms.Button bMenu;
        private System.Windows.Forms.Button bHistory;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
    }
}

