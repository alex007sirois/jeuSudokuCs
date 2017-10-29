using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Logique d'interaction pour DialogueReprendre.xaml
    /// </summary>
    public partial class DialogueReprendre : Window
    {
        private long id = -1;

        

        public DialogueReprendre(List<Tuple<long, string>> liste)
        {
            InitializeComponent();

            foreach(Tuple<long, string> t in liste)
                listeDeParties.Items.Add(t);
        }

        private void reprendre_Click(object sender, RoutedEventArgs e)
        {
            if (listeDeParties.SelectedItem != null)
            {
                Tuple<long, string> partie = (Tuple<long, string>)listeDeParties.SelectedItem;
                id = partie.Item1;

                if (id != -1)
                    this.Close();
                else
                    throw new Exception("erreure au niveaude l'id de la partie selectionnée");
            }
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            id = -1;
            this.Close();
        }

        public long Id
        {
            get { return id; }
        }
       
    }
}
