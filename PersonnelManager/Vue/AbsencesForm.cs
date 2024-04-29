using System;
using System.Drawing;
using System.Linq;
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
            try { Icon = new Icon("icon.ico"); }
            catch { Console.WriteLine("Impossible de changer l'icône de la fenêtre"); }
            
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
                    .OrderByDescending(x => x.DateDebut)
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
            var form = new AbsenceEditForm(_personnel);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _controller.AddAbsence(form.Absence);
                RefreshAbsences();
            }
        }
        
        /// <summary>
        /// Méthode qui gère l'edition d'une absence pour un personnel
        /// </summary>
        private void EditionAbsence()
        {
            if (lstAbsences.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne");
                return;
            }

            AbsenceEditForm.AbsenceField selectedField = AbsenceEditForm.AbsenceField.None;

            switch (lstAbsences.CurrentCell.ColumnIndex)
            {
                case 1:
                    selectedField = AbsenceEditForm.AbsenceField.DateDebut;
                    break;
                case 2:
                    selectedField = AbsenceEditForm.AbsenceField.DateFin;
                    break;
                case 3:
                    selectedField = AbsenceEditForm.AbsenceField.Motif;
                    break;
            }
            
            Absence absence = (Absence)((BindingSource)lstAbsences.DataSource)[lstAbsences.SelectedRows[0].Index];

            DateTime dateDebutInitiale = absence.DateDebut;

            if (new AbsenceEditForm(_personnel, absence, selectedField).ShowDialog() == DialogResult.OK)
            {
                _controller.UpdateAbsence(absence, dateDebutInitiale);
                RefreshAbsences();
            }
        }

        /// <summary>
        /// Méthode qui gère la suppression d'une absence pour un personnel
        /// </summary>
        private void SuppressionAbsence()
        {
            if (lstAbsences.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne");
                return;
            }

            Absence absence = (Absence)((BindingSource)lstAbsences.DataSource)[lstAbsences.SelectedRows[0].Index];

            if (MessageBox.Show($"Voulez vous vraiment supprimer l'absence de '{absence.Personnel.Nom} {absence.Personnel.Prenom}' ayant commencé le {absence.DateDebut.ToShortDateString()} à {absence.DateDebut.ToShortTimeString()} ? ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;
            
            _controller.DeleteAbsence(absence);
            RefreshAbsences();
        }
    }
}