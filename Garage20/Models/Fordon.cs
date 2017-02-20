using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Fordon
    {
        [DisplayName("Fordons Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fältet Registreringsnummer krävs!")]
        [RegularExpression(pattern: "^[a-zA-Z]{3}[0-9]{3}", ErrorMessage = "Mata in 3 bokstäver och 3 siffror!")]
        [DisplayName("Registreringsnummer")]
        public string RegNr { get; set; }

        [Required(ErrorMessage = "Fältet Färg krävs!")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\-\s*]+$", ErrorMessage = "Mata in endast bokstäver!")]
        [StringLength(30, ErrorMessage = "Fältet Färg kan inte vara längre än 30 tecken!")]
        public string Färg { get; set; }

        [Required(ErrorMessage = "Fältet Märke krävs!")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\-\s*]+$", ErrorMessage = "Mata in endast bokstäver!")]
        [StringLength(30, ErrorMessage = "Fältet Märke kan inte vara längre än 30 tecken!")]
        public string Märke { get; set; }

        [Required(ErrorMessage = "Fältet Modell krävs!")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ0-9\-\s*]+$", ErrorMessage = "Mata in endast bokstäver!")]
        [StringLength(30, ErrorMessage = "Fältet Modell kan inte vara längre än 30 tecken!")]
        public string Modell { get; set; }

        [Required(ErrorMessage = "Fältet Antal hjul krävs!")]
        [Range(0, 30)]
        [DisplayName("Antal hjul")]
        //Skapa valideringstext för antal hjul.
        public int AntalHjul { get; set; }

        [DisplayName("In-checkningstid")]
        public DateTime Tid { get; set; }

        [DisplayName("Medlems Id")]
        public int MedlemsId { get; set; }
        [DisplayName("Fordonstyp Id")]
        public int FordonstypId { get; set; }

        //Navigation property
        public virtual Fordonstyp Fordonstyper { get; set; }
        public virtual Medlem Medlemmar { get; set; }
    }
}