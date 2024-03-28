using System;
using System.Windows.Forms;

namespace PersonnelManager.Vue
{
    public partial class PersonnelsForm : Form
    {
        public PersonnelsForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new PersonnelEditForm(true).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new PersonnelEditForm().ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Confirmer ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void btnAbsences_Click(object sender, EventArgs e)
        {
            new AbsencesForm().ShowDialog();
        }
    }
}