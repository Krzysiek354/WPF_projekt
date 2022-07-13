using System;
using System.Collections.Generic;

namespace proj_WPF_end.Baza
{
    public partial class Most
    {
        public Most()
        {
            MaterialDetals = new HashSet<MaterialDetal>();
            Przeglads = new HashSet<Przeglad>();
            NumerKwalifikacjis = new HashSet<OsobaObslugujaca>();
        }

        public int Idmostu { get; set; }
        public string? WspolrzedneDl { get; set; }
        public string? WspolrzedneSzer { get; set; }
        public string DaneTechniczne { get; set; } = null!;
        public DateTime? DataPowstania { get; set; }
        public string TypMostu { get; set; } = null!;
        public string NazwaMostu { get; set; } = null!;
        public int? NumerProjektu { get; set; }
        public string Miasto { get; set; } = null!;
        public string Ulica { get; set; } = null!;

        public virtual Projekt? NumerProjektuNavigation { get; set; }
        public virtual ICollection<MaterialDetal> MaterialDetals { get; set; }
        public virtual ICollection<Przeglad> Przeglads { get; set; }

        public virtual ICollection<OsobaObslugujaca> NumerKwalifikacjis { get; set; }
    }
}
