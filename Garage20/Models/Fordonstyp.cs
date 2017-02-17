using Garage20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Fordonstyp
    {
        public int FordonstypId { get; set; }
        public string Typ { get; set; }

        //Navigation property
        public virtual ICollection<Fordon> Fordon { get; set; }
    }
}