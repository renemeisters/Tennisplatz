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
using M120Projekt.DAL;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Reservieren.xaml
    /// </summary>
    public partial class Reservieren : UserControl
    {

        private DAL.Reservation reservation;
    
        private long id;
        private Reservation reservierung;
        private DAL.Platz court;
        private ScrollViewer gesamtAnsicht;

        // private BLL.Reservation reservierung;

        public Reservieren(long sid,ScrollViewer inhalt)
        {
            InitializeComponent();
            platz.ItemsSource = BLL.Platz.LesenAlle();
            platz.DisplayMemberPath = "Name";
            platz.SelectedValuePath = "PlatzId";
            gesamtAnsicht = inhalt;
            id = sid;
            if(sid > 0)
            {
                aktivieren();
                vergebeWerte(sid);
            }
           
        }


        public void vergebeWerte(long sid)
        {

            reservierung = BLL.Reservation.LesenID(sid);
            kundenname.Text = reservierung.Spielername;
            preis.Content = reservierung.Preis;
            platz.SelectedValue = reservierung.Platz.PlatzId;
            // date.
         
            date.Text = reservierung.Startzeit.ToString();
            startzeit.Text = reservierung.Startzeit.TimeOfDay.ToString();
            endzeit.Text = reservierung.Endzeit.TimeOfDay.ToString();
        }

        public void vergebeNachName(string name)
        {
            ;
            Anzeigen anzeige = new Anzeigen(id,name, gesamtAnsicht);
            gesamtAnsicht.Content = anzeige;

        }

        private void neu_Click(object sender, RoutedEventArgs e)
        {
            if (kundenname.Text != "" || date.SelectedDate != null  || startzeit.SelectedTime != null || endzeit.SelectedTime != null || platz.SelectedItem != null)
            {
                if (MessageBox.Show("Änderungen gehen verloren, wirklich neu erstellen?", "Achtung!", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    werteLoeschen();
                    aktivieren();
                }

            }
            else
            {
                aktivieren();
            }
        }

        private void speichern_Click(object sender, RoutedEventArgs e)
        {
            if (kundenname.Text != "" && date.SelectedDate != null && startzeit.SelectedTime != null && endzeit.SelectedTime != null && platz.SelectedItem != null)
            {
                if (MessageBox.Show("Diesen Platz so reservieren", "Sicher!", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    if (id == 0)
                    {
                        erstellen();
                    }
                    else
                    {
                        update();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus!");
            }
        }

        private void update()
        {
            reservation = new DAL.Reservation();
            reservation.Spielername = kundenname.Text;
            // date.Year;
            //  startzeit.
            reservation.ReservationId = id;
            reservation.Startzeit = new DateTime(date.SelectedDate.Value.Year, date.SelectedDate.Value.Month, date.SelectedDate.Value.Day, startzeit.SelectedTime.Value.Hour, startzeit.SelectedTime.Value.Minute, startzeit.SelectedTime.Value.Second);
            reservation.Endzeit = new DateTime(date.SelectedDate.Value.Year, date.SelectedDate.Value.Month, date.SelectedDate.Value.Day, endzeit.SelectedTime.Value.Hour, endzeit.SelectedTime.Value.Minute, endzeit.SelectedTime.Value.Second);
            if (platz.SelectedValue != null)
            {
                reservation.Platz = BLL.Platz.LesenID((long)platz.SelectedValue);

            }

            BLL.Reservation.Aktualisieren(reservation);
        }

        private void delete()
        {
            DAL.Reservation r = BLL.Reservation.LesenID(id);
            BLL.Reservation.Loeschen(r);
        }

        private void loeschen_Click(object sender, RoutedEventArgs e)
        {
            if (kundenname.Text != "" || date.SelectedDate != null || startzeit.SelectedTime != null || endzeit.SelectedTime != null || platz.SelectedItem != null)
            {
                if (MessageBox.Show("Reservierung gehen verloren, wirklich löschen?", "Achtung!", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
              
                    delete();
                    deaktivieren();
                    werteLoeschen();
                }

            }
            else
            {
                deaktivieren();
            }
        }

        private void abbrechen_Click(object sender, RoutedEventArgs e)
        {
            if (kundenname.Text != "" || date.SelectedDate != null || startzeit.SelectedTime != null || endzeit.SelectedTime != null || platz.SelectedItem != null)
            {
                if (MessageBox.Show("Änderungen gehen verloren, wirklich abbrechen?", "Achtung!", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    werteLoeschen();
                    deaktivieren();
                }

            }
            else
            {
                deaktivieren();
            }
        }

        private void platz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           //preis.Content = platz.Name;
        }

        public void werteLoeschen()
        {
            kundenname.Text = "";
            date.SelectedDate = null;
            startzeit.SelectedTime = null;
            endzeit.SelectedTime = null;
            platz.SelectedItem = null;
     
        }

        public void aktivieren()
        {
            kundenname.IsEnabled = true;
            startzeit.IsEnabled = true;
            date.IsEnabled = true;
            endzeit.IsEnabled = true;
            platz.IsEnabled = true;
            searchID.IsEnabled = true;
            speichern.IsEnabled = true;
            abbrechen.IsEnabled = true;
            loeschen.IsEnabled = true;
            suchen.IsEnabled = true;
        }
        public void deaktivieren()
        {
            kundenname.IsEnabled = false;
            startzeit.IsEnabled = false;
            date.IsEnabled = false;
            endzeit.IsEnabled = false;
            platz.IsEnabled = false;
            searchID.IsEnabled = false;
            speichern.IsEnabled = false;
            abbrechen.IsEnabled = false;
            loeschen.IsEnabled = false;
            suchen.IsEnabled = false;
        }

        public void erstellen()
        {
            
            reservation = new DAL.Reservation();
            reservation.Spielername = kundenname.Text;
            // date.Year;
            //  startzeit.
          
            reservation.Startzeit = new DateTime(date.SelectedDate.Value.Year,date.SelectedDate.Value.Month, date.SelectedDate.Value.Day, startzeit.SelectedTime.Value.Hour, startzeit.SelectedTime.Value.Minute, startzeit.SelectedTime.Value.Second);
            reservation.Endzeit = new DateTime(date.SelectedDate.Value.Year, date.SelectedDate.Value.Month, date.SelectedDate.Value.Day, endzeit.SelectedTime.Value.Hour, endzeit.SelectedTime.Value.Minute, endzeit.SelectedTime.Value.Second);

            if (platz.SelectedValue != null)
            {
                reservation.Platz = BLL.Platz.LesenID((long)platz.SelectedValue);

            }




            BLL.Reservation.Erstellen(reservation);

        }

        private void suchen_Click(object sender, RoutedEventArgs e)
        {
            
            
            string name = searchID.Text;
            vergebeNachName(name);

        }
    }
}
