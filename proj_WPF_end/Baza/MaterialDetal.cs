using System;
using System.Collections.Generic;

namespace proj_WPF_end.Baza
{
    public partial class MaterialDetal
    {
        public int Idmaterialu { get; set; }
        public int Idmostu { get; set; }
        public int? IloscMaterialu { get; set; }

        public virtual Material IdmaterialuNavigation { get; set; } = null!;
        public virtual Most IdmostuNavigation { get; set; } = null!;
    }
}
