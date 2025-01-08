using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikace_zaznamnik_porad.databaze
{
    public class ProgramPorady
    {
        public int Id { get; set; }
        public string Date { get; set; } //zmenono z datetime na string
        public string Lokace { get; set; }
        //public List<BodProgramu> BodyProgramu { get; set; }
        //FIXME: Je tohle tady potřeba????
    }

}
