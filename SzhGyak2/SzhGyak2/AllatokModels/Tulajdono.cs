using System;
using System.Collections.Generic;

#nullable disable

namespace SzhGyak2.AllatokModels
{
    public partial class Tulajdono
    {
        public Tulajdono()
        {
            Ingatlans = new HashSet<Ingatlan>();
        }

        public int TulajdonosSk { get; set; }
        public string Tulajdonosnev { get; set; }
        public string Emailcim { get; set; }
        public string Telefonszám { get; set; }
        public string SzemélyiIgazolványSzám { get; set; }
        public string Adószám { get; set; }

        public virtual ICollection<Ingatlan> Ingatlans { get; set; }
    }
}
