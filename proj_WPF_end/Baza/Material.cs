using System;
using System.Collections.Generic;

namespace proj_WPF_end.Baza
{
    public partial class Material
    {
        public Material()
        {
            MaterialDetals = new HashSet<MaterialDetal>();
        }

        public int Idmaterialu { get; set; }
        public string RodzajMaterialu { get; set; } = null!;

        public virtual ICollection<MaterialDetal> MaterialDetals { get; set; }
    }
}
