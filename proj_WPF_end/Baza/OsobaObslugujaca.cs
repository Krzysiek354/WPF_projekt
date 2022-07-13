using System;
using System.Collections.Generic;

namespace proj_WPF_end.Baza
{
    public partial class OsobaObslugujaca
    {
        public OsobaObslugujaca()
        {
            Idmostus = new HashSet<Most>();
        }

        public int NumerKwalifikacji { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string? RodzajKwalifikacji { get; set; }
        public int? Idprzegladu { get; set; }

        public virtual Przeglad? IdprzegladuNavigation { get; set; }

        public virtual ICollection<Most> Idmostus { get; set; }
    }
}
