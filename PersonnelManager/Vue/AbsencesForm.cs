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
            AdditionAbsence();
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Modifier'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditionAbsence();
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Supprimer'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SuppressionAbsence();
        }

        /// <summary>
        /// Méthode événementielle qui gère la pression d'une touche à l'intérieur de la liste des absences du personnels
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void lstAbsences_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.E:
                    e.Handled = true;
                    EditionAbsence();
                    break;
                case Keys.Delete:
                case Keys.Subtract:
                    e.Handled = true;
                    SuppressionAbsence();
                    break;
                case Keys.Tab:
                    e.Handled = true;
                    btnAdd.Focus();
                    break;
                case Keys.A:
                case Keys.Add:
                    e.Handled = true;
                    AdditionAbsence();
                    break;
            }
        }

        /// <summary>
        /// Méthode qui gère l'addition d'une absence pour un personnel
        /// </summary>
        private void AdditionAbsence()
        {
            new AbsenceEditForm().ShowDialog();
        }
        
        /// <summary>
        /// Méthode qui gère l'edition d'une absence pour un personnel
        /// </summary>
        private void EditionAbsence()
        {
            new AbsenceEditForm().ShowDialog();
        }

        /// <summary>
        /// Méthode qui gère la suppression d'une absence pour un personnel
        /// </summary>
        private void SuppressionAbsence()
        {
            MessageBox.Show("Confirmer ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}