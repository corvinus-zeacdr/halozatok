using System;
using System.Collections.Generic;

#nullable disable

namespace SzhGyak2.AllatokModels
{
    public partial class Ingatlan
    {
        public int IngatlanSk { get; set; }
        public int Alapterulet { get; set; }
        public decimal Ar { get; set; }
        public int Szobaszam { get; set; }
        public string Elhelyezkedes { get; set; }
        public bool? Ujepitesu { get; set; }
        public DateTime? Surgosseg { get; set; }
        public int IngatlanosFk { get; set; }
        public int TulajdonosFk { get; set; }
        public byte EmeletFk { get; set; }
        public byte AltipusFk { get; set; }

        public virtual Altipu AltipusFkNavigation { get; set; }
        public virtual Emelet EmeletFkNavigation { get; set; }
        public virtual Ingatlano IngatlanosFkNavigation { get; set; }
        public virtual Tulajdono TulajdonosFkNavigation { get; set; }
    }
}
