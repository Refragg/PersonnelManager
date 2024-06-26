﻿using System;
using System.Drawing;
using System.Windows.Forms;
using PersonnelManager.Controller;
using PersonnelManager.Model;

namespace PersonnelManager.Vue
{
    /// <summary>
    /// Fenêtre de connexion à l'application
    /// </summary>
    public partial class ConnectionForm : Form
    {
        /// <summary>
        /// Le contrôleur pour cette fenêtre
        /// </summary>
        private ConnectionFormController _controller = new ConnectionFormController();
        
        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        public ConnectionForm()
        {
            InitializeComponent();
            try { Icon = new Icon("icon.ico"); }
            catch { Console.WriteLine("Impossible de changer l'icône de la fenêtre"); }
        }

        /// <summary>
        /// Méthode événementielle quand on clique sur le bouton 'Se connecter'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (!_controller.ValidationIdentifiants(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Les identifiants donnés sont invalides, veuillez les revérifier avant de recommencer",
                    "Identifiants invalides", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            var mainForm = new PersonnelsForm();
            mainForm.Closed += (o, ev) => Close();
            mainForm.Show();
            Hide();
        }

        /// <summary>
        /// Méthode événementielle déclenchée quand on édite du texte dans la case 'Nom d'utilisateur :'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void txtUsername_TextChanged(object sender, EventArgs e) => RefreshConnectionButtonStatus();
        
        /// <summary>
        /// Méthode événementielle déclenchée quand on édite du texte dans la case 'Mot de passe :'
        /// </summary>
        /// <param name="sender">Paramètre inutilisé</param>
        /// <param name="e">Paramètre inutilisé</param>
        private void txtPassword_TextChanged(object sender, EventArgs e) => RefreshConnectionButtonStatus();

        /// <summary>
        /// Méthode qui met à jour l'état d'activation du bouton 'Se connecter' en fonction de l'état de remplissage des cases
        /// </summary>
        private void RefreshConnectionButtonStatus()
        {
            btnConnection.Enabled = !string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text);
        }
    }
}