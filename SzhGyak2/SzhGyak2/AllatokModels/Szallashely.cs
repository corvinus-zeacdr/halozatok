﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SzhGyak2.AllatokModels
{
    public partial class Szallashely
    {
        public Szallashely()
        {
            Szobas = new HashSet<Szoba>();
        }

        public int SzallasId { get; set; }
        public string SzallasNev { get; set; }
        public string Hely { get; set; }
        public int? CsillagokSzama { get; set; }
        public string Tipus { get; set; }
        public string Rogzitette { get; set; }
        public DateTime RogzIdo { get; set; }
        public string Cim { get; set; }

        public virtual ICollection<Szoba> Szobas { get; set; }
    }
}
