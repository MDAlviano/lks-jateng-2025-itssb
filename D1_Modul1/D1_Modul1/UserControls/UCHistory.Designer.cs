namespace D1_Modul1.UserControls
{
    partial class UCHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgTransac = new System.Windows.Forms.DataGridView();
            this.dgTransacTId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTransacTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTransacCustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTransacDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTransacTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTableName = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgOrder = new System.Windows.Forms.DataGridView();
            this.dgOrderTransacId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOrderOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOrderOrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOderInputedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOrderNumOrderedItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dgOrderDetailOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOrderDetailOrderDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOrderDetailMenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOrderDetailQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOrderDetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransac)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrder)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgTransac);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(860, 124);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transaction";
            // 
            // dgTransac
            // 
            this.dgTransac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTransac.BackgroundColor = System.Drawing.Color.White;
            this.dgTransac.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgTransac.ColumnHeadersHeight = 34;
            this.dgTransac.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgTransacTId,
            this.dgTransacTableName,
            this.dgTransacCustName,
            this.dgTransacDate,
            this.dgTransacTotalPrice});
            this.dgTransac.Location = new System.Drawing.Point(22, 28);
            this.dgTransac.Name = "dgTransac";
            this.dgTransac.ReadOnly = true;
            this.dgTransac.RowHeadersVisible = false;
            this.dgTransac.RowHeadersWidth = 62;
            this.dgTransac.RowTemplate.Height = 28;
            this.dgTransac.Size = new System.Drawing.Size(816, 81);
            this.dgTransac.TabIndex = 0;
            // 
            // dgTransacTId
            // 
            this.dgTransacTId.HeaderText = "Transaction ID";
            this.dgTransacTId.MinimumWidth = 8;
            this.dgTransacTId.Name = "dgTransacTId";
            this.dgTransacTId.ReadOnly = true;
            // 
            // dgTransacTableName
            // 
            this.dgTransacTableName.HeaderText = "Table Name";
            this.dgTransacTableName.MinimumWidth = 8;
            this.dgTransacTableName.Name = "dgTransacTableName";
            this.dgTransacTableName.ReadOnly = true;
            // 
            // dgTransacCustName
            // 
            this.dgTransacCustName.HeaderText = "Customer Name";
            this.dgTransacCustName.MinimumWidth = 8;
            this.dgTransacCustName.Name = "dgTransacCustName";
            this.dgTransacCustName.ReadOnly = true;
            // 
            // dgTransacDate
            // 
            this.dgTransacDate.HeaderText = "Date";
            this.dgTransacDate.MinimumWidth = 8;
            this.dgTransacDate.Name = "dgTransacDate";
            this.dgTransacDate.ReadOnly = true;
            // 
            // dgTransacTotalPrice
            // 
            this.dgTransacTotalPrice.HeaderText = "Total Price";
            this.dgTransacTotalPrice.MinimumWidth = 8;
            this.dgTransacTotalPrice.Name = "dgTransacTotalPrice";
            this.dgTransacTotalPrice.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTableName);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 114);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // cbTableName
            // 
            this.cbTableName.FormattingEnabled = true;
            this.cbTableName.Location = new System.Drawing.Point(162, 68);
            this.cbTableName.Name = "cbTableName";
            this.cbTableName.Size = new System.Drawing.Size(208, 28);
            this.cbTableName.TabIndex = 6;
            this.cbTableName.Text = "All";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(162, 30);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(208, 26);
            this.dtpDate.TabIndex = 5;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnApply.Location = new System.Drawing.Point(398, 68);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(90, 26);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Table Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgOrder);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(18, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(860, 124);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order";
            // 
            // dgOrder
            // 
            this.dgOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgOrder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgOrder.ColumnHeadersHeight = 34;
            this.dgOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgOrderTransacId,
            this.dgOrderOrderId,
            this.dgOrderOrderTime,
            this.dgOderInputedBy,
            this.dgOrderNumOrderedItem});
            this.dgOrder.Location = new System.Drawing.Point(22, 28);
            this.dgOrder.Name = "dgOrder";
            this.dgOrder.ReadOnly = true;
            this.dgOrder.RowHeadersVisible = false;
            this.dgOrder.RowHeadersWidth = 62;
            this.dgOrder.RowTemplate.Height = 28;
            this.dgOrder.Size = new System.Drawing.Size(816, 81);
            this.dgOrder.TabIndex = 0;
            // 
            // dgOrderTransacId
            // 
            this.dgOrderTransacId.HeaderText = "Transaction ID";
            this.dgOrderTransacId.MinimumWidth = 8;
            this.dgOrderTransacId.Name = "dgOrderTransacId";
            this.dgOrderTransacId.ReadOnly = true;
            // 
            // dgOrderOrderId
            // 
            this.dgOrderOrderId.HeaderText = "Order ID";
            this.dgOrderOrderId.MinimumWidth = 8;
            this.dgOrderOrderId.Name = "dgOrderOrderId";
            this.dgOrderOrderId.ReadOnly = true;
            // 
            // dgOrderOrderTime
            // 
            this.dgOrderOrderTime.HeaderText = "Order Time";
            this.dgOrderOrderTime.MinimumWidth = 8;
            this.dgOrderOrderTime.Name = "dgOrderOrderTime";
            this.dgOrderOrderTime.ReadOnly = true;
            // 
            // dgOderInputedBy
            // 
            this.dgOderInputedBy.HeaderText = "Input By Waitress";
            this.dgOderInputedBy.MinimumWidth = 8;
            this.dgOderInputedBy.Name = "dgOderInputedBy";
            this.dgOderInputedBy.ReadOnly = true;
            // 
            // dgOrderNumOrderedItem
            // 
            this.dgOrderNumOrderedItem.HeaderText = "Number of Ordered Item";
            this.dgOrderNumOrderedItem.MinimumWidth = 8;
            this.dgOrderNumOrderedItem.Name = "dgOrderNumOrderedItem";
            this.dgOrderNumOrderedItem.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView3);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(18, 389);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(860, 124);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Order Detail";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView3.ColumnHeadersHeight = 34;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgOrderDetailOrderId,
            this.dgOrderDetailOrderDetailID,
            this.dgOrderDetailMenuName,
            this.dgOrderDetailQuantity,
            this.dgOrderDetailPrice});
            this.dataGridView3.Location = new System.Drawing.Point(22, 28);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowHeadersWidth = 62;
            this.dataGridView3.RowTemplate.Height = 28;
            this.dataGridView3.Size = new System.Drawing.Size(816, 81);
            this.dataGridView3.TabIndex = 0;
            // 
            // dgOrderDetailOrderId
            // 
            this.dgOrderDetailOrderId.HeaderText = "Order ID";
            this.dgOrderDetailOrderId.MinimumWidth = 8;
            this.dgOrderDetailOrderId.Name = "dgOrderDetailOrderId";
            this.dgOrderDetailOrderId.ReadOnly = true;
            // 
            // dgOrderDetailOrderDetailID
            // 
            this.dgOrderDetailOrderDetailID.HeaderText = "Order Detail ID";
            this.dgOrderDetailOrderDetailID.MinimumWidth = 8;
            this.dgOrderDetailOrderDetailID.Name = "dgOrderDetailOrderDetailID";
            this.dgOrderDetailOrderDetailID.ReadOnly = true;
            // 
            // dgOrderDetailMenuName
            // 
            this.dgOrderDetailMenuName.HeaderText = "Menu Name";
            this.dgOrderDetailMenuName.MinimumWidth = 8;
            this.dgOrderDetailMenuName.Name = "dgOrderDetailMenuName";
            this.dgOrderDetailMenuName.ReadOnly = true;
            // 
            // dgOrderDetailQuantity
            // 
            this.dgOrderDetailQuantity.HeaderText = "Quantity";
            this.dgOrderDetailQuantity.MinimumWidth = 8;
            this.dgOrderDetailQuantity.Name = "dgOrderDetailQuantity";
            this.dgOrderDetailQuantity.ReadOnly = true;
            // 
            // dgOrderDetailPrice
            // 
            this.dgOrderDetailPrice.HeaderText = "Price";
            this.dgOrderDetailPrice.MinimumWidth = 8;
            this.dgOrderDetailPrice.Name = "dgOrderDetailPrice";
            this.dgOrderDetailPrice.ReadOnly = true;
            // 
            // UCHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCHistory";
            this.Size = new System.Drawing.Size(897, 544);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransac)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrder)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgTransac;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cbTableName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgOrder;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTransacTId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTransacTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTransacCustName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTransacDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTransacTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOrderTransacId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOrderOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOrderOrderTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOderInputedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOrderNumOrderedItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOrderDetailOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOrderDetailOrderDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOrderDetailMenuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOrderDetailQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOrderDetailPrice;
    }
}
