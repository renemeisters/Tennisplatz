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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Platz.xaml
    /// </summary>
    public partial class Platz : UserControl
    {

        private ScrollViewer gesamtAnsicht;
        private DateTime zeit;
      

        public Platz(ScrollViewer inhalt)
        {

            InitializeComponent();
            
            gesamtAnsicht = inhalt;
            PlatzAnzeige.ItemsSource = BLL.Platz.LesenAlle();
        }

        private void PlatzAnzeige_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        //    DAL.Reservation auswahl2 = (DAL.Reservation)PlatzAnzeige.SelectedItem;
            DAL.Platz auswahl = (DAL.Platz)PlatzAnzeige.SelectedItem;
            long id = auswahl.PlatzId;
            //Reservieren reservation = new Reservieren(id, gesamtAnsicht);
            Anzeigen anzeige = new Anzeigen(id,null,gesamtAnsicht);
            gesamtAnsicht.Content = anzeige;

           
        }
    }
}
