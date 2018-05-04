using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt.BLL
{
    static class ClassA
    {
        public static List<DAL.ClassA> LesenAlle()
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.ClassA.Include("FremdschluesselAttribut") select record).ToList();
            }
        }
        public static DAL.ClassA LesenID(Int64 ClassAId)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.ClassA.Include("FremdschluesselAttribut") where record.ClassAId == ClassAId select record).FirstOrDefault();
            }
        }
        public static List<DAL.ClassA> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.ClassA.Include("FremdschluesselAttribut") where record.TextAttribut == suchbegriff select record).ToList();
            }
        }
        public static List<DAL.ClassA> LesenAttributWie(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.ClassA.Include("FremdschluesselAttribut") where record.TextAttribut.Contains(suchbegriff) select record).ToList();
            }
        }
        public static List<DAL.ClassA> LesenFremdschluesselGleich(DAL.ClassB suchschluessel)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.ClassA.Include("FremdschluesselAttribut") where record.FremdschluesselAttribut == suchschluessel select record).ToList();
            }
        }
        public static Int64 Erstellen(DAL.ClassA classA)
        {
            if (classA.TextAttribut == null || classA.TextAttribut == "") classA.TextAttribut = "leer";
            // Option mit Fehler statt Default Value
            // if (classA.TextAttribut == null) throw new Exception("Null ist ungültig");
            if (classA.DatumAttribut == null) classA.DatumAttribut = DateTime.MinValue;
            using (var context = new DAL.Context())
            {
                context.ClassA.Add(classA);
                //TODO Check ob mit null möglich, sonst throw Ex
                if (classA.FremdschluesselAttribut != null) context.ClassB.Attach(classA.FremdschluesselAttribut);
                context.SaveChanges();
                return classA.ClassAId;
            }
        }
        public static void Aktualisieren(DAL.ClassA classA)
        {
            using (var context = new DAL.Context())
            {
                //TODO null Checks?
                context.Entry(classA).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void Loeschen(DAL.ClassA classA)
        {
            using (var context = new DAL.Context())
            {
                context.ClassA.Remove(classA);
                context.SaveChanges();
            }
        }
    }
}
