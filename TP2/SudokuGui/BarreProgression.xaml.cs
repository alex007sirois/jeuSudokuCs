using Sudoku.Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sudoku.Gui
{
    /// <summary>
    /// Logique d'interaction pour BarreProgression.xaml
    /// </summary>
    public partial class BarreProgression : Window, IObserverResolution
    {
        private JeuSudoku jeu;
        private BackgroundWorker bw;
        private DateTime derniereUpdate;

        public BarreProgression(JeuSudoku jeu)
        {
            InitializeComponent();

            this.jeu = jeu;

            bw = new BackgroundWorker();

            bw.WorkerReportsProgress = true;

            bw.DoWork += new DoWorkEventHandler(bw_faireLeTravail);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_mettreAjourLeGui);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_faitCaAlaFinDuProcessus);

            bw.RunWorkerAsync();
        }

        private void bw_faireLeTravail(object sender, DoWorkEventArgs e)
        {
            jeu.resoudre(this);
        }

        private void bw_mettreAjourLeGui(object sender, ProgressChangedEventArgs e)
        {
            this.barre.Value = e.ProgressPercentage;
        }

        private void bw_faitCaAlaFinDuProcessus(object sender, RunWorkerCompletedEventArgs e)
        {
            
            this.barre.Value = 100;
            this.progression.Text = "Résolution de la grille completée";
            this.fermer.Visibility = Visibility.Visible;
        }

        public void progressionResolution(int pourcentage)
        {
            if (derniereUpdate == null || (DateTime.Now - derniereUpdate).TotalMilliseconds > 200)
            {
                derniereUpdate = DateTime.Now;
                bw.ReportProgress(pourcentage);
            }
        }

        private void fermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
