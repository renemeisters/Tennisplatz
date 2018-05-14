using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.DAL
{
    class Platz
    {
        public Platz() { }
        [Key]
        public Int64 PlatzId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Boolean IstGedeckt { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
        [NotMapped]
        public Int64 AnzahlReservationen
        {
            get
            {
                return Reservation.LongCount();
            }
        }
        public override string ToString()
        {
            return PlatzId.ToString(); // Für bessere Coded UI Test Erkennung
        }

    }
}
