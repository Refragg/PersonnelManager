using System;
using System.Windows.Forms;
using PersonnelManager.Vue;

namespace PersonnelManager
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée de l'application
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (o, e) => UnhandledException((Exception)e.ExceptionObject);
            Application.ThreadException += (o, e) => UnhandledException(e.Exception);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConnectionForm());
        }

        /// <summary>
        /// Cette méthode sera invoquée en cas d'erreur grave non gérée dans l'application, les utilisateurs reçevront un message d'explication avant que l'application s'arrête
        /// </summary>
        /// <param name="e">L'exception qui a été générée</param>
        private static void UnhandledException(Exception e)
        {
            MessageBox.Show(
                $"Une erreur irrécupérable est arrivée lors de l'exécution de l'application. L'application va maintenant quitter\r\n\r\nErreur : {e.Message}",
                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }
    }
}