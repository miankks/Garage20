using Garage20.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Fordonstyp
    {
        [DisplayName("Fordonstyp Id")]
        public int FordonstypId { get; set; }
        [Required(ErrorMessage = "Fältet Typ krävs!")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\-\s*]+$", ErrorMessage = "Mata in endast bokstäver!")]
        [StringLength(30, ErrorMessage = "Fältet Typ kan inte vara längre än 30 tecken!")]
        public string Typ { get; set; }

        //Navigation property
        public virtual ICollection<Fordon> Fordon { get; set; }
    }
}