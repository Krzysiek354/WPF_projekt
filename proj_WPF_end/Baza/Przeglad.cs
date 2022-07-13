using System;
using System.Collections.Generic;

namespace proj_WPF_end.Baza
{
    public partial class Przeglad
    {
        public Przeglad()
        {
            OsobaObslugujacas = new HashSet<OsobaObslugujaca>();
        }

        public int Idprzegladu { get; set; }
        public DateTime DataPrzegladu { get; set; }
        public string ZakresPrzegladu { get; set; } = null!;
        public string WykonujacyPrzegladImie { get; set; } = null!;
        public string WykonujacyPrzegladNazwisko { get; set; } = null!;
        public string? Zalecenia { get; set; }
        public int? Idmostu { get; set; }

        public virtual Most? IdmostuNavigation { get; set; }
        public virtual ICollection<OsobaObslugujaca> OsobaObslugujacas { get; set; }
    }
}
