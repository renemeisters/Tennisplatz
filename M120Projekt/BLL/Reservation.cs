using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt.BLL
{
    static class Reservation
    {
        public static List<DAL.Reservation> LesenAlle()
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Reservation.Include("Platz") select record).ToList();
            }
        }
        public static DAL.Reservation LesenID(Int64 reservationId)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Reservation.Include("Platz") where record.ReservationId == reservationId select record).FirstOrDefault();
            }
        }
        public static List<DAL.Reservation> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Reservation.Include("Platz") where record.Spielername == suchbegriff select record).ToList();
            }
        }
        public static List<DAL.Reservation> LesenAttributWie(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Reservation.Include("Platz") where record.Spielername.Contains(suchbegriff) select record).ToList();
            }
        }
        public static List<DAL.Reservation> LesenFremdschluesselGleich(DAL.Platz suchschluessel)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Reservation.Include("Platz") where record.Platz.PlatzId == suchschluessel.PlatzId select record).ToList();
            }
        }
        public static Int64 Erstellen(DAL.Reservation reservation)
        {
            if (reservation.Spielername == null || reservation.Spielername == "") reservation.Spielername = "leer";
            if (reservation.Startzeit == null) reservation.Startzeit = DateTime.MinValue;
            if (reservation.Endzeit == null) reservation.Endzeit = DateTime.MinValue;
            using (var context = new DAL.Context())
            {
                context.Reservation.Add(reservation);
                //TODO Check ob mit null möglich, sonst throw Ex
                if (reservation.Platz != null) context.Platz.Attach(reservation.Platz);
                context.SaveChanges();
                return reservation.ReservationId;
            }
        }
        public static void Aktualisieren(DAL.Reservation reservation)
        {
            using (var context = new DAL.Context())
            {
                //TODO null Checks?
                context.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void Loeschen(DAL.Reservation reservation)
        {
            using (var context = new DAL.Context())
            {
                context.Reservation.Remove(reservation);
                context.SaveChanges();
            }
        }
    }
}
