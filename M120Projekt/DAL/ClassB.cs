using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.DAL
{
    class ClassB
    {
        public ClassB() { }
        [Key]
        public Int64 ClassBId { get; set; }
        [Required]
        public String TextAttribut { get; set; }
        [Required]
        public DateTime DatumAttribut { get; set; }
        [Required]
        public Boolean BooleanAttribut { get; set; }
        public ICollection<ClassA> FremdListeAttribut { get; set; }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public override string ToString()
        {
            return ClassBId.ToString(); // Für bessere Coded UI Test Erkennung
        }

    }
}
