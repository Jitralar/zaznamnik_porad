using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikace_zaznamnik_porad.databaze
{
    public class Osoba
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string? ProstredniJmeno { get; set; }
        public string? Prezdivka { get; set; }

        // Přidáme pomocnou vlastnost pro označení přítomnosti
        public bool IsPresent { get; set; } = false; // Výchozí hodnota
    }

}
