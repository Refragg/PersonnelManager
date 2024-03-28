using System;
using System.Windows.Forms;

namespace PersonnelManager.Vue
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            MessageBox.Show("on se connecte la");
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) => RefreshConnectionButtonStatus();
        private void txtPassword_TextChanged(object sender, EventArgs e) => RefreshConnectionButtonStatus();

        private void RefreshConnectionButtonStatus()
        {
            btnConnection.Enabled = !string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text);
        }
    }
}