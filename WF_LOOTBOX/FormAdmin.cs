using IPLootbox;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace WF_LOOTBOX
{
    public partial class FormAdmin : Form
    {
        public static Color txtdefaultcolor;

        public FormAdmin()
        {
            InitializeComponent();
            txtdefaultcolor = txtFName.BackColor;
            //txtFName.LostFocus += new EventHandler(CheckName);
            //txtLName.LostFocus += new EventHandler(CheckName);
            //txtMName.LostFocus += new EventHandler(CheckName);

            txtFName.TextChanged += new EventHandler(CheckName);
            txtLName.TextChanged += new EventHandler(CheckName);
            txtMName.TextChanged += new EventHandler(CheckName);
            txtSpeed.TextChanged += new EventHandler(CheckSpeed);

            txtFName.MaxLength = Lootbox.MAX_LEN_STRING_FOR_NAME;
            txtLName.MaxLength = Lootbox.MAX_LEN_STRING_FOR_NAME;
            txtMName.MaxLength = Lootbox.MAX_LEN_STRING_FOR_NAME;

            cmbBoxSize.DataSource = Enum.GetValues(typeof(BoxSize));

            dgvWorkers.CellDoubleClick += DgvWorkers_CellDoubleClick;
            dgvWorkers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWorkers.Hide();
            dgvWorkers.ReadOnly = true;
            dgvWorkers.Rows.AddRange(Lootbox.FillGridWorkers().ToArray());

            this.CancelButton = btnClose;
            btnClose.Click += new EventHandler(Close);
            btnList.Click += new EventHandler(Click_btnList);
            btnDel.Click += new EventHandler(Click_btnDel);
            btnAdd.Click += new EventHandler(Click_btnAdd);
        }

        private void DgvWorkers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvWorkers.SelectedRows.Count == 1)
            {
                var row = dgvWorkers.SelectedRows;
                txtFName.Text = row[0].Cells["cfname"].Value.ToString();
                txtLName.Text = row[0].Cells["clname"].Value.ToString();
                txtMName.Text = row[0].Cells["cmname"].Value.ToString();
                txtSpeed.Text = row[0].Cells["cspeed"].Value.ToString();
                cmbBoxSize.Text = row[0].Cells["cboxsize"].Value.ToString();
            }
        }

        private void Click_btnAdd(object sender, EventArgs e)
        {
            this.Enabled = false;

            if ((bool)(txtFName.Tag ?? false) &&
                (bool)(txtLName.Tag ?? false) &&
                (bool)(txtMName.Tag ?? false) &&
                (bool)(txtSpeed.Tag ?? false))
            {
                string message = "";
                message += txtFName.Text.Trim() + " ";
                message += txtLName.Text.Trim() + " ";
                message += txtMName.Text.Trim();
                var res = MessageBox.Show($"Будет добавлен работник {message}",
                                              "Внимание",
                                              MessageBoxButtons.OKCancel,
                                              MessageBoxIcon.Exclamation);
                if (res == DialogResult.OK)
                {
                    string fname = txtFName.Text.Trim();
                    string lname = txtLName.Text.Trim();
                    string mname = txtMName.Text.Trim();
                    float speed = float.Parse(txtSpeed.Text.Trim());
                    int boxsize = (int)Enum.Parse(typeof(BoxSize), cmbBoxSize.Text.Trim(), true);

                    Lootbox.AddWorker(fname, lname, mname, speed, boxsize);
                    dgvWorkers.Rows.Clear();
                    dgvWorkers.Rows.AddRange(Lootbox.FillGridWorkers().ToArray());
                    ResetUserControls();
                }
            }
            else
            {
                MessageBox.Show($"Данные не коректны или не предоставлены.\nИли исправьте подсвеченные поля.",
                                "Внимание",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            
            this.Enabled = true;
        }
        private void Click_btnDel(object sender, EventArgs e)
        {
            string message = "";
            if (dgvWorkers.SelectedRows.Count == 1)
            {
                this.Enabled = false;
                var row = dgvWorkers.SelectedRows;
                message += row[0].Cells["cfname"].Value.ToString() + " ";
                message += row[0].Cells["clname"].Value.ToString() + " ";
                message += row[0].Cells["cmname"].Value.ToString();
                btnDel.Tag = row[0].Cells["cid"].Value.ToString();

                var res = MessageBox.Show($"Будет удален работник {message}",
                                          "Внимание",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                if (res == DialogResult.OK)
                {
                    Lootbox.DelWorker(int.Parse(btnDel.Tag.ToString()));
                }
                dgvWorkers.Rows.Clear();
                dgvWorkers.Rows.AddRange(Lootbox.FillGridWorkers().ToArray());
                ResetUserControls();
            }
            btnDel.Tag = "";
            
            this.Enabled = true;
        }
        private void Click_btnList(object sender, EventArgs e)
        {
            dgvWorkers.Visible = !dgvWorkers.Visible;
            if (!dgvWorkers.Visible) dgvWorkers.ClearSelection();
        }

        private void ResetUserControls()
        {

            txtFName.TextChanged -= new EventHandler(CheckName);
            txtLName.TextChanged -= new EventHandler(CheckName);
            txtMName.TextChanged -= new EventHandler(CheckName);
            txtSpeed.TextChanged -= new EventHandler(CheckSpeed);

            txtFName.Text="";
            txtLName.Text="";
            txtMName.Text="";
            txtSpeed.Text="";
            cmbBoxSize.SelectedIndex = 0;

            txtFName.Tag = null;
            txtLName.Tag = null;
            txtMName.Tag = null;
            txtSpeed.Tag = null;

            txtFName.TextChanged += new EventHandler(CheckName);
            txtLName.TextChanged += new EventHandler(CheckName);
            txtMName.TextChanged += new EventHandler(CheckName);
            txtSpeed.TextChanged += new EventHandler(CheckSpeed);
        }
        private void CheckSpeed(object sender, EventArgs e)
        {
            TextBox objevent = sender as TextBox;
            if (!Lootbox.TryInputFloat(objevent.Text, out var none))
            {
                objevent.BackColor = Color.FromArgb(210, 180, 150);
                objevent.Tag = false;
            }
            else
            {
                objevent.BackColor = txtdefaultcolor;
                objevent.Tag = true;
            }
        }
        private void CheckName(object sender, EventArgs e)
        {
            TextBox objevent = sender as TextBox;
            if (!Lootbox.TryInputString(objevent.Text))
            {
                objevent.BackColor = Color.FromArgb(210, 180, 150);
                objevent.Tag = false;
            }
            else
            {
                objevent.BackColor = txtdefaultcolor;
                objevent.Tag = true;
            }
        }
        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
