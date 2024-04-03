using System;
using System.Windows.Forms;

namespace PersonnelManager.Vue
{
    /// <summary>
    /// Fenêtre principale de l'application affichant les différents personnels
    /// </summary>
    public partial class PersonnelsForm : Form
    {
        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        public PersonnelsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Ajouter' 
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            new PersonnelEditForm().ShowDialog();
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Modifier'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            new PersonnelEditForm().ShowDialog();
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Supprimer'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Confirmer ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Absences'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnAbsences_Click(object sender, EventArgs e)
        {
            new AbsencesForm(null).ShowDialog();
        }
    }
}