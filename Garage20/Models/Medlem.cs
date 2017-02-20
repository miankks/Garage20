using Garage20.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Garage20.Models
{
    public class Medlem
    {
        [Key]
        [DisplayName("Medlems id")]
        public int MedlemsId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string FullständigtNamn { get { return (Förnamn + " " + Efternamn).Trim(); } }

        //Navigation property
        public virtual ICollection<Fordon> Fordon { get; set; }
    }
}