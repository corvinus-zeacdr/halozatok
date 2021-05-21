using System;
using System.Collections.Generic;

#nullable disable

namespace SzhGyak2.AllatokModels
{
    public partial class Altipu
    {
        public Altipu()
        {
            Ingatlans = new HashSet<Ingatlan>();
        }

        public byte AltipusId { get; set; }
        public string Tipus { get; set; }

        public virtual ICollection<Ingatlan> Ingatlans { get; set; }
    }
}
