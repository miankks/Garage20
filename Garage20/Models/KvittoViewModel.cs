using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class KvittoViewModel
    {
        public string Namn { get; set; }
        public string RegNr { get; set; }
        public DateTime Ankomsttid { get; set; }
        public DateTime Utcheckningstid { get; set; }
        public int Kostnad { get; set; }
    }
}