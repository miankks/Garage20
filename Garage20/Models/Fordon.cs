﻿using System;
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
        //[Range(5,7)]
        [RegularExpression(pattern:"^[a-zA-Z]{3}[0-9]{3}", ErrorMessage = "Bara tre Bokstavar och 3 ")]
        public string RegNr { get; set; }
        [Required]
        public Typ Typ { get; set; }
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]+$", ErrorMessage = "Use letters only please")]
        public string Färg { get; set; }
        [Required]
        public string Märke { get; set; }
        [Required]
        public string Modell { get; set; }
        [Range(1, 30)]
        public int AntalHjul { get; set; }
        public DateTime Tid { get; set; }
        
    }
}