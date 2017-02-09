using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public enum Typ
    {
        Bil,
        Buss, 
        Motorcykel,
        Båt, 
        Flygplan
    }

    public class Fordon
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public Typ Typ { get; set; }
        public string Färg { get; set; }
        public string Märke { get; set; }
        public string Modell { get; set; }
        [Range(1, 30)]
        public int AntalHjul { get; set; }
    }
}