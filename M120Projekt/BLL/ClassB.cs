using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt.BLL
{
    static class ClassB
    {
        public static List<DAL.ClassB> LesenAlle()
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.ClassB select record).ToList();
            }
        }
        public static DAL.ClassB LesenID(Int64 ClassBId)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.ClassB where record.ClassBId == ClassBId select record).FirstOrDefault();
            }
        }
        public static List<DAL.ClassB> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.ClassB where record.TextAttribut == suchbegriff select record).ToList();
            }
        }
        public static List<DAL.ClassB> LesenAttributWie(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.ClassB where record.TextAttribut.Contains(suchbegriff) select record).ToList();
            }
        }
        //public static List<DAL.ClassB> LesenFremdschluesselGleich(DAL.ClassA suchschluessel)
        //{
        //    using (var context = new DAL.Context())
        //    {
        //        return (from record in context.ClassA where record.FremdschluesselAttribut == suchschluessel select record).ToList();
        //    }
        //}
        public static Int64 Erstellen(DAL.ClassB classB)
        {
            if (classB.TextAttribut == null || classB.TextAttribut == "") classB.TextAttribut = "leer";
            // Option mit Fehler statt Default Value
            // if (classB.TextAttribut == null) throw new Exception("Null ist ungültig");
            if (classB.DatumAttribut == null) classB.DatumAttribut = DateTime.MinValue;
            using (var context = new DAL.Context())
            {
                context.ClassB.Add(classB);
                context.SaveChanges();
                return classB.ClassBId;
            }
        }
        public static void Aktualisieren(DAL.ClassB classB)
        {
            using (var context = new DAL.Context())
            {
                //TODO null Checks?
                context.Entry(classB).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void Loeschen(DAL.ClassB classB)
        {
            using (var context = new DAL.Context())
            {
                context.ClassB.Remove(classB);
                context.SaveChanges();
            }
        }
    }
}
