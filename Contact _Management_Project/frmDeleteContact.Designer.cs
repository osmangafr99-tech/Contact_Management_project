namespace WindowsFormsApp1
{
    partial class frmDeleteContact
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDeleteContact = new System.Windows.Forms.Label();
            this.dgvSingleResult = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYesDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSingleResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeleteContact
            // 
            this.lblDeleteContact.AutoSize = true;
            this.lblDeleteContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleteContact.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDeleteContact.Location = new System.Drawing.Point(436, 22);
            this.lblDeleteContact.Name = "lblDeleteContact";
            this.lblDeleteContact.Size = new System.Drawing.Size(221, 33);
            this.lblDeleteContact.TabIndex = 0;
            this.lblDeleteContact.Text = "Delete Contact";
            // 
            // dgvSingleResult
            // 
            this.dgvSingleResult.AllowUserToAddRows = false;
            this.dgvSingleResult.AllowUserToDeleteRows = false;
            this.dgvSingleResult.AllowUserToOrderColumns = true;
            this.dgvSingleResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvSingleResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSingleResult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSingleResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSingleResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSingleResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSingleResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Perpetua", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSingleResult.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSingleResult.Location = new System.Drawing.Point(27, 258);
            this.dgvSingleResult.Name = "dgvSingleResult";
            this.dgvSingleResult.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSingleResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSingleResult.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSingleResult.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSingleResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSingleResult.Size = new System.Drawing.Size(998, 51);
            this.dgvSingleResult.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(288, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(502, 33);
            this.label1.TabIndex = 17;
            this.label1.Text = "Do you want to delete this contact?";
            // 
            // btnYesDelete
            // 
            this.btnYesDelete.BackColor = System.Drawing.Color.Maroon;
            this.btnYesDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYesDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYesDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnYesDelete.Location = new System.Drawing.Point(596, 392);
            this.btnYesDelete.Name = "btnYesDelete";
            this.btnYesDelete.Size = new System.Drawing.Size(150, 50);
            this.btnYesDelete.TabIndex = 45;
            this.btnYesDelete.Text = "Yes";
            this.btnYesDelete.UseVisualStyleBackColor = false;
            this.btnYesDelete.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(272, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 50);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // frmDeleteContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(1053, 567);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnYesDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSingleResult);
            this.Controls.Add(this.lblDeleteContact);
            this.Name = "frmDeleteContact";
            this.Text = "frmDeleteContact";
            this.Load += new System.EventHandler(this.frmDeleteContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSingleResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeleteContact;
        private System.Windows.Forms.DataGridView dgvSingleResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYesDelete;
        private System.Windows.Forms.Button btnClose;
    }
}