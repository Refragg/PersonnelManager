using System;
using System.Windows.Forms;
using PersonnelManager.Controller;
using PersonnelManager.Model;

namespace PersonnelManager.Vue
{
    /// <summary>
    /// Fenêtre affichant les absences pour un personnel en particulier
    /// </summary>
    public partial class AbsencesForm : Form
    {
        /// <summary>
        /// Le contrôleur pour cette fenêtre
        /// </summary>
        private AbsencesFormController _controller = new AbsencesFormController();
        
        /// <summary>
        /// Le personnel en question
        /// </summary>
        private Personnel _personnel;
        
        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="personnel">Le personnel pour lequel afficher les absences</param>
        public AbsencesForm(Personnel personnel)
        {
            _personnel = personnel;
            
            InitializeComponent();
            RefreshAbsences();

            lstAbsences.Columns["Personnel"].Visible = false;

            Text = $"Absences pour '{_personnel.Nom} {_personnel.Prenom}'";
        }
        
        /// <summary>
        /// Méthode qui rafraichit la liste des absences pour un personnel 
        /// </summary>
        public void RefreshAbsences()
        {
            lstAbsences.DataSource = new BindingSource
            {
                DataSource = _controller.GetAbsences(_personnel)
            };
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