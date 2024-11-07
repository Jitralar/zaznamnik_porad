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
        public DateTime Date { get; set; }
        public string Lokace { get; set; }
        public List<BodProgramu> BodyProgramu { get; set; }
    }

}
