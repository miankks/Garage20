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
        [Required(ErrorMessage = "Fältet Förnamn krävs!")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\-\s*]+$", ErrorMessage = "Mata in endast bokstäver!")]
        [StringLength(30, ErrorMessage = "Fältet Förnamn kan inte vara längre än 30 tecken!")]
        public string Förnamn { get; set; }
        [Required(ErrorMessage = "Fältet EfterNamn krävs!")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\-\s*]+$", ErrorMessage = "Mata in endast bokstäver!")]
        [StringLength(30, ErrorMessage = "Fältet Efternamn kan inte vara längre än 30 tecken!")]
        public string Efternamn { get; set; }
        public string FullständigtNamn { get { return (Förnamn + " " + Efternamn).Trim(); } }

        //Navigation property
        public virtual ICollection<Fordon> Fordon { get; set; }
    }
}