using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt.BLL
{
    static class Platz
    {
        public static List<DAL.Platz> LesenAlle()
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Platz select record).ToList();
            }
        }
        public static DAL.Platz LesenID(Int64 platzId)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Platz where record.PlatzId == platzId select record).FirstOrDefault();
            }
        }
        public static List<DAL.Platz> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Platz where record.Name == suchbegriff select record).ToList();
            }
        }
        public static List<DAL.Platz> LesenAttributWie(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Platz where record.Name.Contains(suchbegriff) select record).ToList();
            }
        }
        public static Int64 Erstellen(DAL.Platz platz)
        {
            if (platz.Name == null || platz.Name == "") platz.Name = "leer";
            using (var context = new DAL.Context())
            {
                context.Platz.Add(platz);
                context.SaveChanges();
                return platz.PlatzId;
            }
        }
        public static void Aktualisieren(DAL.Platz platz)
        {
            using (var context = new DAL.Context())
            {
                //TODO null Checks?
                context.Entry(platz).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void Loeschen(DAL.Platz platz)
        {
            using (var context = new DAL.Context())
            {
                context.Platz.Remove(platz);
                context.SaveChanges();
            }
        }
    }
}
