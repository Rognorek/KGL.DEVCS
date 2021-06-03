using System;
using System.Windows.Forms;

namespace WF_LOOTBOX
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            btnExit.Click += new EventHandler(Exit);
            btnOk.Click += new EventHandler(Open);
            txtUserName.Text = "admin";
        }

        public void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Open(object sender, EventArgs e)
        {
            string userstring = txtUserName.Text;
            txtUserName.Text = txtUserPassword.Text = "";
            if (userstring.ToUpper() == "ADMIN")
            {
                this.Hide();
                this.Enabled = false;

                Form frmAdmin = new FormAdmin();
                frmAdmin.ShowDialog(this);

                this.Show();
                this.Enabled = true;
            }
            else if (userstring.ToUpper() == "USER")
            {
                //this.Hide();
                //this.Enabled = false;

                //Form frmUser = new FormAdmin();// todo for client
                //frmUser.ShowDialog(this);

                //this.Show();
                //this.Enabled = true;
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
