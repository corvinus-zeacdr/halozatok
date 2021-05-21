using System;
using System.Collections.Generic;

#nullable disable

namespace SzhGyak2.AllatokModels
{
    public partial class IngatlanosUgyfel
    {
        public int IngatlanosUgyfelSk { get; set; }
        public int IngatlanosFk { get; set; }
        public int UgyfelFk { get; set; }

        public virtual Ingatlano IngatlanosFkNavigation { get; set; }
        public virtual Ugyfel UgyfelFkNavigation { get; set; }
    }
}
