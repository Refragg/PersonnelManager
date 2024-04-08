using System;
using System.Linq;
using System.Windows.Forms;
using PersonnelManager.Controller;
using PersonnelManager.Model;

namespace PersonnelManager.Vue
{
    /// <summary>
    /// Fenêtre principale de l'application affichant les différents personnels
    /// </summary>
    public partial class PersonnelsForm : Form
    {
        /// <summary>
        /// Le contrôleur pour cette fenêtre
        /// </summary>
        private PersonnelsFormController _controller = new PersonnelsFormController();
        
        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        public PersonnelsForm()
        {
            InitializeComponent();
            RefreshPersonnels();
        }

        /// <summary>
        /// Méthode qui rafraichit la liste des personnels 
        /// </summary>
        public void RefreshPersonnels()
        {
            lstPersonnels.DataSource = new BindingSource
            {
                DataSource = _controller.GetPersonnels()
                    .OrderBy(x => x.Nom)
                    .ThenBy(x => x.Prenom)
            };
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Ajouter' 
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdditionPersonnel();
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Modifier'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditionPersonnel();
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Supprimer'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstPersonnels.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne");
                return;
            }

            Personnel personnel = (Personnel)((BindingSource)lstPersonnels.DataSource)[lstPersonnels.SelectedRows[0].Index];

            if (MessageBox.Show($"Voulez vous vraiment supprimer '{personnel.Nom} {personnel.Prenom}' ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;
            
            _controller.DeletePersonnel(personnel);
            RefreshPersonnels();
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Absences'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnAbsences_Click(object sender, EventArgs e)
        {
            if (lstPersonnels.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne");
                return;
            }

            Personnel personnel = (Personnel)((BindingSource)lstPersonnels.DataSource)[lstPersonnels.SelectedRows[0].Index];
            new AbsencesForm(personnel).ShowDialog();
        }

        /// <summary>
        /// Méthode événementielle quand on double clique sur une case de la liste des personnels
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void lstPersonnels_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditionPersonnel();
        }

        /// <summary>
        /// Méthode qui gère l'addition d'un personnel
        /// </summary>
        private void AdditionPersonnel()
        {
            var form = new PersonnelEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _controller.AddPersonnel(form.Personnel);
                RefreshPersonnels();
            }
        }
        
        /// <summary>
        /// Méthode qui gère l'édition d'un personnel
        /// </summary>
        private void EditionPersonnel()
        {
            if (lstPersonnels.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne");
                return;
            }
            
            Personnel personnel = (Personnel)((BindingSource)lstPersonnels.DataSource)[lstPersonnels.SelectedRows[0].Index];

            if (new PersonnelEditForm(personnel).ShowDialog() == DialogResult.OK)
            {
                _controller.UpdatePersonnel(personnel);
                RefreshPersonnels();
            }
        }
    }
}