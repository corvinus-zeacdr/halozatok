using System;
using System.Collections.Generic;

#nullable disable

namespace SzhGyak2.AllatokModels
{
    public partial class Ugyfel
    {
        public Ugyfel()
        {
            IngatlanosUgyfels = new HashSet<IngatlanosUgyfel>();
        }

        public int UgyfelSk { get; set; }
        public string Ugyfelnev { get; set; }
        public string Emailcim { get; set; }
        public string Telefonszam { get; set; }
        public string SzemélyiIgazolványSzám { get; set; }
        public string Adószám { get; set; }

        public virtual ICollection<IngatlanosUgyfel> IngatlanosUgyfels { get; set; }
    }
}
