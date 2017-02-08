using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Fordon
    {
        public string Typ { get; set; }
        public string RegNr { get; set; }
        public string Färg { get; set; }
        public string Märke { get; set; }
        public string Modell { get; set; }
        public int AntalHjul { get; set; }
    }
}