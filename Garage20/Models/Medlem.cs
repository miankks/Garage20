using Garage20.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Garage20.Models
{
    public class Medlem
    {
        [Key]
        public int MedlemsId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string FullName { get { return (Förnamn + ", " + Efternamn).Trim(); } }
        public string adress { get; set; }
        public string Ort { get; set; }
        public int AntalBil { get; set; }
        //Navigation property
        public virtual ICollection<Fordon> Fordon { get;set; }
    }
}