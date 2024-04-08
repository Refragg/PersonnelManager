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
            SuppressionPersonnel();
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Absences'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnAbsences_Click(object sender, EventArgs e)
        {
            AbsencesPersonnel();
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
        /// Méthode événementielle qui gère la pression d'une touche à l'intérieur de la liste des personnels
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void lstPersonnels_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.E:
                    e.Handled = true;
                    EditionPersonnel();
                    break;
                case Keys.Delete:
                case Keys.Subtract:
                    e.Handled = true;
                    SuppressionPersonnel();
                    break;
                case Keys.Tab:
                    e.Handled = true;
                    btnAdd.Focus();
                    break;
                case Keys.A:
                case Keys.Add:
                    e.Handled = true;
                    AdditionPersonnel();
                    break;
                case Keys.Space:
                    e.Handled = true;
                    AbsencesPersonnel();
                    break;
            }
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

            PersonnelEditForm.PersonnelField selectedField = PersonnelEditForm.PersonnelField.None;

            switch (lstPersonnels.CurrentCell.ColumnIndex)
            {
                case 1:
                    selectedField = PersonnelEditForm.PersonnelField.Nom;
                    break;
                case 2:
                    selectedField = PersonnelEditForm.PersonnelField.Prenom;
                    break;
                case 3:
                    selectedField = PersonnelEditForm.PersonnelField.Tel;
                    break;
                case 4:
                    selectedField = PersonnelEditForm.PersonnelField.Mail;
                    break;
                case 5:
                    selectedField = PersonnelEditForm.PersonnelField.Service;
                    break;
            }
            
            Personnel personnel = (Personnel)((BindingSource)lstPersonnels.DataSource)[lstPersonnels.SelectedRows[0].Index];

            if (new PersonnelEditForm(personnel, selectedField).ShowDialog() == DialogResult.OK)
            {
                _controller.UpdatePersonnel(personnel);
                RefreshPersonnels();
            }
        }

        /// <summary>
        /// Méthode qui gère la suppression d'un personnel
        /// </summary>
        private void SuppressionPersonnel()
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
        /// Méthode qui gère l'affichage des absences d'un personnel
        /// </summary>
        private void AbsencesPersonnel()
        {
            if (lstPersonnels.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne");
                return;
            }

            Personnel personnel = (Personnel)((BindingSource)lstPersonnels.DataSource)[lstPersonnels.SelectedRows[0].Index];
            new AbsencesForm(personnel).ShowDialog();
        }
    }
}