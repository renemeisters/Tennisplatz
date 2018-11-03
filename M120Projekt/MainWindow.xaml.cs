using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String menu;
        public MainWindow()
        {
            InitializeComponent();
         // DemoErstellen();
          // DemoAbfragen();
        }
       #region Demo
       private void DemoErstellen()
        {
            // Platz (kurze Syntax)
            DAL.Platz platz1 = new DAL.Platz{ Name = "Platz 1 Halle", IstGedeckt = true};
            Int64 platz1Id = BLL.Platz.Erstellen(platz1);
            Debug.Print("Platz erstellt mit Id:" + platz1Id);
            DAL.Platz platz2 = new DAL.Platz { Name = "Platz A Aussen", IstGedeckt = false};
            Int64 platz2Id = BLL.Platz.Erstellen(platz2);
            Debug.Print("Platz erstellt mit Id:" + platz2Id);
            // Reservation (detaillierte Syntax)
            DAL.Reservation reservation1 = new DAL.Reservation();
            reservation1.Spielername = "Roger";
            reservation1.Startzeit = DateTime.Today.AddDays(5).AddHours(13);
            reservation1.Endzeit = reservation1.Startzeit.AddHours(2);
            reservation1.Platz = platz1;
            Int64 classA1Id = BLL.Reservation.Erstellen(reservation1);
            Debug.Print("Kunde erstellt mit Id:" + classA1Id);
        }
        private void DemoAbfragen()
        {
            String output = "";
            // Alle Records Reservation mit Details zu verknüpftem Record aus Platz
            output += Environment.NewLine + "Alle Records Reservation";
            foreach (DAL.Reservation reservation in BLL.Reservation.LesenAlle())
            {
                output += Environment.NewLine + "TextAttribut Spieler:" + reservation.Spielername;
                output += Environment.NewLine + "TextAttribut Name von Platz:" + reservation.Platz.Name;
            }
            output += Environment.NewLine + "------------------------------------------------------";
            // Alle Records ClassB
            output += Environment.NewLine + "Alle Records Plätze";
            foreach (DAL.Platz platz in BLL.Platz.LesenAlle())
            {
                output += Environment.NewLine + "TextAttribut Platz:" + platz.Name;
            }
            output += Environment.NewLine + "------------------------------------------------------";
            Debug.Print(output);
        }
        #endregion
    
        private void reservation_Click(object sender, RoutedEventArgs e)
        {
            if (menu != "resevation")
            {
                menu = "reservation";
                Reservieren reservieren = new Reservieren(0,inhalt);
                reservieren.HorizontalAlignment = HorizontalAlignment.Left;
                reservieren.VerticalAlignment = VerticalAlignment.Top;
                inhalt.Content = null;
                inhalt.Content = reservieren;
            }
        }

        private void anzeige_Click(object sender, RoutedEventArgs e)
        {
            if (menu != "anzeige")
            {
                menu = "anzeige";
                Anzeigen anzeige = new Anzeigen(0,null,inhalt);
                anzeige.HorizontalAlignment = HorizontalAlignment.Left;
                anzeige.VerticalAlignment = VerticalAlignment.Top;
                inhalt.Content = null;
                inhalt.Content = anzeige;
            }
        }

        private void plaetze_Click(object sender, RoutedEventArgs e)
        {
            if (menu != "platz")
            {
                menu = "platz";
                Platz plaetze = new Platz(inhalt);
                plaetze.HorizontalAlignment = HorizontalAlignment.Left;
                plaetze.VerticalAlignment = VerticalAlignment.Top;
                inhalt.Content = null;
                inhalt.Content = plaetze;

            }
        }
    }
}
