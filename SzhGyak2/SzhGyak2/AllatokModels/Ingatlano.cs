using System;
using System.Collections.Generic;

#nullable disable

namespace SzhGyak2.AllatokModels
{
    public partial class Ingatlano
    {
        public Ingatlano()
        {
            IngatlanosUgyfels = new HashSet<IngatlanosUgyfel>();
            Ingatlans = new HashSet<Ingatlan>();
        }

        public int IngatlanosSk { get; set; }
        public string Ingatlanosnev { get; set; }
        public string Emailcim { get; set; }
        public string Telefonszam { get; set; }

        public virtual ICollection<IngatlanosUgyfel> IngatlanosUgyfels { get; set; }
        public virtual ICollection<Ingatlan> Ingatlans { get; set; }
    }
}
