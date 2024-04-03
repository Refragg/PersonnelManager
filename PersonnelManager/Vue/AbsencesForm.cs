using System;
using System.Windows.Forms;
using PersonnelManager.Model;

namespace PersonnelManager.Vue
{
    /// <summary>
    /// Fenêtre affichant les absences pour un personnel en particulier
    /// </summary>
    public partial class AbsencesForm : Form
    {
        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="personnel">Le personnel pour lequel afficher les absences</param>
        public AbsencesForm(Personnel personnel)
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
            new AbsenceEditForm().ShowDialog();
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Modifier'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            new AbsenceEditForm().ShowDialog();
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
    }
}