using System;
using System.Windows.Forms;

namespace PersonnelManager.Vue
{
    public partial class AbsencesForm : Form
    {
        public AbsencesForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AbsenceEditForm(true).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new AbsenceEditForm().ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Confirmer ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}