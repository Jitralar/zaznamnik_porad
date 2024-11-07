using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikace_zaznamnik_porad.databaze
{
    public class Hlasovani
    {
        public int Id { get; set; }
        public int BodProgramuId { get; set; }
        public int OsobaId { get; set; }
        public DateTime DateTime { get; set; }
        public bool Hlasoval { get; set; }  // True for 'yes', False for 'no'
    }

}
