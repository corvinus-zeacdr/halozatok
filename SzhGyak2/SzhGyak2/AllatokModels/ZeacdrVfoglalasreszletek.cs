using System;
using System.Collections.Generic;

#nullable disable

namespace SzhGyak2.AllatokModels
{
    public partial class ZeacdrVfoglalasreszletek
    {
        public int FoglalásAzon { get; set; }
        public string Vendég { get; set; }
        public string Szállás { get; set; }
        public string Elhelyezkedés { get; set; }
        public DateTime Mettől { get; set; }
        public DateTime Meddig { get; set; }
        public string Szobaszám { get; set; }
    }
}
