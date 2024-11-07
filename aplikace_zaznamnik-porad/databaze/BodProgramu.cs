using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikace_zaznamnik_porad.databaze
{
    public class BodProgramu
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public string Nazev { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public bool Dulezity { get; set; }
    }


}
