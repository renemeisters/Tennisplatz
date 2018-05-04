using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.DAL
{
    class ClassA
    {
        public ClassA() { }
        [Key]
        public Int64 ClassAId { get; set; }
        [Required]
        public String TextAttribut { get; set; }
        [Required]
        public DateTime DatumAttribut { get; set; }
        [Required]
        public Boolean BooleanAttribut { get; set; }
        public ClassB FremdschluesselAttribut { get; set; }
        [NotMapped]
        public String BerechnetesAttribut {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public override string ToString()
        {
            return ClassAId.ToString(); // Für bessere Coded UI Test Erkennung
        }
    }
}
