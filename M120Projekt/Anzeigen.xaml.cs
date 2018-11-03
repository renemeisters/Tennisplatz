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
    /// Interaktionslogik für Anzeigen.xaml
    /// </summary>
    public partial class Anzeigen : UserControl
    {

        private ScrollViewer gesamtAnsicht;
        private long id;
  

        public Anzeigen(long sid, string name, ScrollViewer inhalt)
        {
            InitializeComponent();
            gesamtAnsicht = inhalt;
            id = sid;
        
            if(name != null)
            {
                if (BLL.Reservation.LesenAttributWie(name).Count == 0)
                {
                    MessageBox.Show("Es sind keine Reservationen für den Namen:  vorhanden");
                    Reservieren reservation = new Reservieren(0, gesamtAnsicht);
                    gesamtAnsicht.Content = reservation;
                }
                else
                {
                    Reservationen.ItemsSource = BLL.Reservation.LesenAttributWie(name);
                }
            }
            if(name == null && id > 0)
            {
                
                // DAL.Reservation reserve;
                DAL.Platz plaetze;

                plaetze = BLL.Platz.LesenID(id);
                //reserve.Platz = plaetze;
              // Reservationen.ItemsSource = BLL.Platz.LesenID(id); 
              
              Reservationen.ItemsSource = BLL.Reservation.LesenFremdschluesselGleich(plaetze);
            }
            if(name == null && id == 0)
            {
                Reservationen.ItemsSource = BLL.Reservation.LesenAlle();
            }

         //  Reservationen.ItemsSource = BLL.Platz.LesenID();

        }

        private void Reservationen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(Reservationen.SelectedItem != null)
            {


                DAL.Reservation auswahl = (DAL.Reservation)Reservationen.SelectedItem;
                long id = auswahl.ReservationId;
                Reservieren reservation = new Reservieren(id, gesamtAnsicht);
                gesamtAnsicht.Content = reservation;
            }

        }
    }
}
