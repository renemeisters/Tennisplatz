using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.DAL
{
    class Reservation
    {
        public Reservation() { }
        [Key]
        public Int64 ReservationId { get; set; }
        [Required]
        public String Spielername { get; set; }
        [Required]
        public DateTime Startzeit { get; set; }
        [Required]
        public DateTime Endzeit { get; set; }
        [Required]
        public Boolean IstMitglied { get; set; }
        public Platz Platz { get; set; }
        [NotMapped]
        public Double Preis {
            get
            {
                Double result = 0;
                if (IstMitglied)
                {
                    result = (Endzeit - Startzeit).TotalHours * 25;
                }
                else
                {
                    result = (Endzeit - Startzeit).TotalHours * 35;
                }
                return result;
            }
        }
        public override string ToString()
        {
            return ReservationId.ToString(); // Für bessere Coded UI Test Erkennung
        }
    }
}
