namespace D1_Modul1.Forms
{
    partial class TableSeatingDetailForm
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
            this.btnCancelTable = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCustName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPaxSize = new System.Windows.Forms.TextBox();
            this.tbWaitress = new System.Windows.Forms.TextBox();
            this.btnFinishTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelTable
            // 
            this.btnCancelTable.BackColor = System.Drawing.Color.Gold;
            this.btnCancelTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelTable.Location = new System.Drawing.Point(44, 177);
            this.btnCancelTable.Name = "btnCancelTable";
            this.btnCancelTable.Size = new System.Drawing.Size(133, 30);
            this.btnCancelTable.TabIndex = 14;
            this.btnCancelTable.Text = "Cancel Table";
            this.btnCancelTable.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pax Size";
            // 
            // tbCustName
            // 
            this.tbCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCustName.Enabled = false;
            this.tbCustName.Location = new System.Drawing.Point(218, 77);
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.Size = new System.Drawing.Size(272, 26);
            this.tbCustName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Waitress";
            // 
            // tbPaxSize
            // 
            this.tbPaxSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPaxSize.Enabled = false;
            this.tbPaxSize.Location = new System.Drawing.Point(218, 125);
            this.tbPaxSize.Name = "tbPaxSize";
            this.tbPaxSize.Size = new System.Drawing.Size(272, 26);
            this.tbPaxSize.TabIndex = 16;
            // 
            // tbWaitress
            // 
            this.tbWaitress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbWaitress.Enabled = false;
            this.tbWaitress.Location = new System.Drawing.Point(218, 29);
            this.tbWaitress.Name = "tbWaitress";
            this.tbWaitress.Size = new System.Drawing.Size(272, 26);
            this.tbWaitress.TabIndex = 17;
            // 
            // btnFinishTable
            // 
            this.btnFinishTable.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnFinishTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinishTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishTable.Location = new System.Drawing.Point(356, 177);
            this.btnFinishTable.Name = "btnFinishTable";
            this.btnFinishTable.Size = new System.Drawing.Size(134, 30);
            this.btnFinishTable.TabIndex = 15;
            this.btnFinishTable.Text = "Finish Table";
            this.btnFinishTable.UseVisualStyleBackColor = false;
            // 
            // TableSeatingDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 235);
            this.Controls.Add(this.tbWaitress);
            this.Controls.Add(this.tbPaxSize);
            this.Controls.Add(this.btnFinishTable);
            this.Controls.Add(this.btnCancelTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCustName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TableSeatingDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TableSeatingDetailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCustName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPaxSize;
        private System.Windows.Forms.TextBox tbWaitress;
        private System.Windows.Forms.Button btnFinishTable;
    }
}