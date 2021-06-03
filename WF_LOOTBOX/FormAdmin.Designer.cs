
namespace WF_LOOTBOX
{
    partial class FormAdmin
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
            this.dgvWorkers = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblMName = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblBoxSize = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.cmbBoxSize = new System.Windows.Forms.ComboBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWorkers
            // 
            this.dgvWorkers.AllowUserToAddRows = false;
            this.dgvWorkers.AllowUserToDeleteRows = false;
            this.dgvWorkers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvWorkers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PT Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkers.ColumnHeadersHeight = 48;
            this.dgvWorkers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cFname,
            this.cLname,
            this.cMname,
            this.cSpeed,
            this.cBoxSize});
            this.dgvWorkers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvWorkers.EnableHeadersVisualStyles = false;
            this.dgvWorkers.Location = new System.Drawing.Point(0, 336);
            this.dgvWorkers.Margin = new System.Windows.Forms.Padding(0);
            this.dgvWorkers.MultiSelect = false;
            this.dgvWorkers.Name = "dgvWorkers";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("PT Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorkers.RowHeadersWidth = 50;
            this.dgvWorkers.RowTemplate.Height = 41;
            this.dgvWorkers.Size = new System.Drawing.Size(1888, 672);
            this.dgvWorkers.TabIndex = 0;
            // 
            // cID
            // 
            this.cID.HeaderText = "ID";
            this.cID.MinimumWidth = 10;
            this.cID.Name = "cID";
            this.cID.Width = 92;
            // 
            // cFname
            // 
            this.cFname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cFname.FillWeight = 200F;
            this.cFname.HeaderText = "Имя";
            this.cFname.MinimumWidth = 10;
            this.cFname.Name = "cFname";
            this.cFname.Width = 120;
            // 
            // cLname
            // 
            this.cLname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cLname.HeaderText = "Фамилия";
            this.cLname.MinimumWidth = 10;
            this.cLname.Name = "cLname";
            this.cLname.Width = 189;
            // 
            // cMname
            // 
            this.cMname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cMname.HeaderText = "Отчество";
            this.cMname.MinimumWidth = 10;
            this.cMname.Name = "cMname";
            this.cMname.Width = 188;
            // 
            // cSpeed
            // 
            this.cSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cSpeed.HeaderText = "Скорость";
            this.cSpeed.MinimumWidth = 10;
            this.cSpeed.Name = "cSpeed";
            this.cSpeed.Width = 187;
            // 
            // cBoxSize
            // 
            this.cBoxSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cBoxSize.HeaderText = "Размер бандероли";
            this.cBoxSize.MinimumWidth = 10;
            this.cBoxSize.Name = "cBoxSize";
            this.cBoxSize.Width = 322;
            // 
            // lblFName
            // 
            this.lblFName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFName.Location = new System.Drawing.Point(16, 16);
            this.lblFName.Margin = new System.Windows.Forms.Padding(0);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(288, 48);
            this.lblFName.TabIndex = 1;
            this.lblFName.Text = "Имя:";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(1568, 16);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(310, 64);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblLName
            // 
            this.lblLName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLName.Location = new System.Drawing.Point(16, 80);
            this.lblLName.Margin = new System.Windows.Forms.Padding(0);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(288, 48);
            this.lblLName.TabIndex = 3;
            this.lblLName.Text = "Фамилия:";
            // 
            // lblMName
            // 
            this.lblMName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMName.Location = new System.Drawing.Point(16, 144);
            this.lblMName.Margin = new System.Windows.Forms.Padding(0);
            this.lblMName.Name = "lblMName";
            this.lblMName.Size = new System.Drawing.Size(288, 48);
            this.lblMName.TabIndex = 4;
            this.lblMName.Text = "Отчество:";
            // 
            // lblSpeed
            // 
            this.lblSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSpeed.Location = new System.Drawing.Point(16, 208);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(288, 48);
            this.lblSpeed.TabIndex = 5;
            this.lblSpeed.Text = "Скорость:";
            // 
            // lblBoxSize
            // 
            this.lblBoxSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBoxSize.Location = new System.Drawing.Point(16, 272);
            this.lblBoxSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblBoxSize.Name = "lblBoxSize";
            this.lblBoxSize.Size = new System.Drawing.Size(288, 48);
            this.lblBoxSize.TabIndex = 6;
            this.lblBoxSize.Text = "Класс бандеролей:";
            // 
            // txtFName
            // 
            this.txtFName.Font = new System.Drawing.Font("PT Sans", 11.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFName.Location = new System.Drawing.Point(320, 16);
            this.txtFName.Margin = new System.Windows.Forms.Padding(0);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(704, 48);
            this.txtFName.TabIndex = 0;
            // 
            // txtLName
            // 
            this.txtLName.Font = new System.Drawing.Font("PT Sans", 11.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLName.Location = new System.Drawing.Point(320, 80);
            this.txtLName.Margin = new System.Windows.Forms.Padding(0);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(704, 48);
            this.txtLName.TabIndex = 1;
            // 
            // txtMName
            // 
            this.txtMName.Font = new System.Drawing.Font("PT Sans", 11.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMName.Location = new System.Drawing.Point(320, 144);
            this.txtMName.Margin = new System.Windows.Forms.Padding(0);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(704, 48);
            this.txtMName.TabIndex = 2;
            // 
            // txtSpeed
            // 
            this.txtSpeed.Font = new System.Drawing.Font("PT Sans", 11.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSpeed.Location = new System.Drawing.Point(320, 208);
            this.txtSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(704, 48);
            this.txtSpeed.TabIndex = 3;
            // 
            // cmbBoxSize
            // 
            this.cmbBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBoxSize.Font = new System.Drawing.Font("PT Sans", 11.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbBoxSize.FormattingEnabled = true;
            this.cmbBoxSize.Location = new System.Drawing.Point(320, 272);
            this.cmbBoxSize.Margin = new System.Windows.Forms.Padding(0);
            this.cmbBoxSize.Name = "cmbBoxSize";
            this.cmbBoxSize.Size = new System.Drawing.Size(704, 47);
            this.cmbBoxSize.TabIndex = 4;
            // 
            // btnDel
            // 
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Location = new System.Drawing.Point(1568, 96);
            this.btnDel.Margin = new System.Windows.Forms.Padding(0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(310, 64);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "Удалить";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnList
            // 
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Location = new System.Drawing.Point(1568, 176);
            this.btnList.Margin = new System.Windows.Forms.Padding(0);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(310, 64);
            this.btnList.TabIndex = 7;
            this.btnList.Text = "Список";
            this.btnList.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1568, 256);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(310, 64);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1894, 1009);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.cmbBoxSize);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.txtMName);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.lblBoxSize);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblMName);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblFName);
            this.Controls.Add(this.dgvWorkers);
            this.Font = new System.Drawing.Font("PT Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "FormAdmin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkers;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblMName;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblBoxSize;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.ComboBox cmbBoxSize;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBoxSize;
    }
}