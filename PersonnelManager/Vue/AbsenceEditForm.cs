using System;
using System.Windows.Forms;
using PersonnelManager.Controller;
using PersonnelManager.Model;

namespace PersonnelManager.Vue
{
    /// <summary>
    /// Fenêtre d'édition (ou d'addition) d'une absence
    /// </summary>
    public partial class AbsenceEditForm : Form
    {
        /// <summary>
        /// Représente un des champs d'une absence
        /// </summary>
        public enum AbsenceField
        {
            None,
            DateDebut,
            DateFin,
            Motif
        }

        /// <summary>
        /// Le contrôleur pour cette fenêtre
        /// </summary>
        private AbsenceEditFormController _controller = new AbsenceEditFormController();
        
        /// <summary>
        /// Le personnel à qui l'absence doit appartenir
        /// </summary>
        private Personnel _personnel { get; }
        
        /// <summary>
        /// L'absence en cours d'édition ou d'addition, à récupérer à la fin de l'ajout
        /// </summary>
        public Absence Absence { get; private set; }
        
        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="personnel">Le personnel à qui l'absence appartient / doit appartenir</param>
        /// <param name="absence">L'absence à éditer, s'il faut ajouter une absence, utilisez null</param>
        /// <param name="startField">Le champ a focus en premier</param>
        public AbsenceEditForm(Personnel personnel, Absence absence = null, AbsenceField startField = AbsenceField.None)
        {
            InitializeComponent();
            RefreshMotifs();
            _personnel = personnel;
            Absence = absence;

            if (Absence is null)
            {
                Text = "Ajouter une absence";
                btnConfirm.Text = "Ajouter";
                cbxMotif.SelectedIndex = 0;
                return;
            }
            
            Text = "Modifier une absence";
            btnConfirm.Text = "Modifier";
            
            dtpDebut.Value = Absence.DateDebut;
            dtpFin.Value = Absence.DateFin;
            
            // Recherche et sélection du bon motif
            for (var i = 0; i < cbxMotif.Items.Count; i++)
            {
                if (((Motif)cbxMotif.Items[i]).IdMotif == Absence.Motif.IdMotif)
                {
                    cbxMotif.SelectedIndex = i;
                    break;
                }
            }
            
            Control toFocus = dtpDebut;
            
            switch (startField)
            {
                case AbsenceField.DateFin:
                    toFocus = dtpFin;
                    break;
                case AbsenceField.Motif:
                    toFocus = cbxMotif;
                    break;
            }
            
            Shown += (sender, args) => toFocus.Focus();
        }

        /// <summary>
        /// Méthode rafraichissant la liste des motifs
        /// </summary>
        private void RefreshMotifs()
        {
            cbxMotif.DataSource = new BindingSource
            {
                DataSource = _controller.GetMotifs()
            };
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton Ajouter / Modifier
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Absence is null)
            {
                Absence = new Absence(_personnel,
                    dtpDebut.Value,
                    dtpFin.Value,
                    (Motif)cbxMotif.SelectedItem);
                return;
            }

            var confirmation =
                MessageBox.Show(
                    $"Shouaitez vous vraiment modifier les informations de l'absence de '{Absence.Personnel.Nom} {Absence.Personnel.Prenom}' ayant commencé le {Absence.DateDebut.ToShortDateString()} à {Absence.DateDebut.ToShortTimeString()} ?",
                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (confirmation != DialogResult.OK)
                return;
            
            Absence.DateDebut = dtpDebut.Value;
            Absence.DateFin = dtpFin.Value;
            Absence.Motif = (Motif)cbxMotif.SelectedItem;
        }
    }
}