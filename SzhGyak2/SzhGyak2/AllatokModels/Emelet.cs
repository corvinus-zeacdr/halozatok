using System;
using System.Collections.Generic;

#nullable disable

namespace SzhGyak2.AllatokModels
{
    public partial class Emelet
    {
        public Emelet()
        {
            Ingatlans = new HashSet<Ingatlan>();
        }

        public byte EmeletId { get; set; }
        public string Szint { get; set; }

        public virtual ICollection<Ingatlan> Ingatlans { get; set; }
    }
}
