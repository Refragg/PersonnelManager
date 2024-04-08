using System;
using System.Windows.Forms;
using PersonnelManager.Controller;
using PersonnelManager.Model;

namespace PersonnelManager.Vue
{
    /// <summary>
    /// Fenêtre d'édition (ou d'addition) d'un personnel
    /// </summary>
    public partial class PersonnelEditForm : Form
    {
        /// <summary>
        /// Représente un des champs d'un personnel
        /// </summary>
        public enum PersonnelField
        {
            None,
            Nom,
            Prenom,
            Mail,
            Tel,
            Service
        }
        
        /// <summary>
        /// Le contrôleur pour cette fenêtre
        /// </summary>
        private PersonnelEditFormController _controller = new PersonnelEditFormController();
        
        /// <summary>
        /// Le personnel en cours d'édition ou d'addition, à récupérer à la fin de l'ajout
        /// </summary>
        public Personnel Personnel { get; private set; }
        
        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="personnel">Le personnel à éditer, s'il faut ajouter un personnel, utilisez null</param>
        /// <param name="startField">Le champ a focus en premier</param>
        public PersonnelEditForm(Personnel personnel = null, PersonnelField startField = PersonnelField.None)
        {
            InitializeComponent();
            RefreshServices();
            Personnel = personnel;

            if (Personnel is null)
            {
                Text = "Ajouter un personnel";
                btnConfirm.Text = "Ajouter";
                cbxService.SelectedIndex = 0;
                return;
            }
            
            Text = "Modifier un personnel";
            btnConfirm.Text = "Modifier";
            
            txtNom.Text = Personnel.Nom;
            txtPrenom.Text = Personnel.Prenom;
            txtTel.Text = Personnel.Telephone;
            txtMail.Text = Personnel.Mail;
            txtNom.Text = Personnel.Nom;
            
            // Recherche et sélection du bon service
            for (var i = 0; i < cbxService.Items.Count; i++)
            {
                if (((Service)cbxService.Items[i]).IdService == Personnel.Service.IdService)
                {
                    cbxService.SelectedIndex = i;
                    break;
                }
            }
            
            Control toFocus = txtNom;
            
            switch (startField)
            {
                case PersonnelField.Prenom:
                    toFocus = txtPrenom;
                    break;
                case PersonnelField.Mail:
                    toFocus = txtMail;
                    break;
                case PersonnelField.Tel:
                    toFocus = txtTel;
                    break;
                case PersonnelField.Service:
                    toFocus = cbxService;
                    break;
            }
            
            Shown += (sender, args) => toFocus.Focus();
        }
        
        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton Ajouter / Modifier
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Personnel is null)
            {
                Personnel = new Personnel(0,
                    txtNom.Text,
                    txtPrenom.Text,
                    txtTel.Text,
                    txtMail.Text,
                    (Service)cbxService.SelectedItem);
                return;
            }

            var confirmation =
                MessageBox.Show(
                    $"Shouaitez vous vraiment modifier les informations de '{Personnel.Nom} {Personnel.Prenom}' ?",
                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (confirmation != DialogResult.OK)
                return;
            
            Personnel.Nom = txtNom.Text;
            Personnel.Prenom = txtPrenom.Text;
            Personnel.Telephone = txtTel.Text;
            Personnel.Mail = txtMail.Text;
            Personnel.Service = (Service)cbxService.SelectedItem;
        }

        /// <summary>
        /// Méthode rafraichissant la liste des services
        /// </summary>
        private void RefreshServices()
        {
            cbxService.DataSource = new BindingSource
            {
                DataSource = _controller.GetServices()
            };
        }

        /// <summary>
        /// Méthode événementielle déclenchée quand on édite du texte dans la case 'Nom :'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void txtNom_TextChanged(object sender, EventArgs e) => RefreshConfirmButtonStatus();

        /// <summary>
        /// Méthode événementielle déclenchée quand on édite du texte dans la case 'Prénom :'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void txtPrenom_TextChanged(object sender, EventArgs e) => RefreshConfirmButtonStatus();

        /// <summary>
        /// Méthode événementielle déclenchée quand on édite du texte dans la case 'Mail :'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void txtMail_TextChanged(object sender, EventArgs e) => RefreshConfirmButtonStatus();

        /// <summary>
        /// Méthode événementielle déclenchée quand on édite du texte dans la case 'Téléphone :'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void txtTel_TextChanged(object sender, EventArgs e) => RefreshConfirmButtonStatus();

        /// <summary>
        /// Méthode qui met à jour l'état d'activation du bouton 'Ajouter'/'Modifier' en fonction de l'état de remplissage des cases
        /// </summary>
        private void RefreshConfirmButtonStatus()
        {
            btnConfirm.Enabled = !string.IsNullOrWhiteSpace(txtNom.Text) &&
                                 !string.IsNullOrWhiteSpace(txtPrenom.Text) &&
                                 !string.IsNullOrWhiteSpace(txtMail.Text) &&
                                 !string.IsNullOrWhiteSpace(txtTel.Text);
        }
    }
}