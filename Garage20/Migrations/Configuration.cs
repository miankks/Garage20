namespace Garage20.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage20.DAL.Garage20Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage20.DAL.Garage20Context context)
        {
            var datetime = DateTime.Now;
           
            var medlemmar = new[]
            {
                new Medlem { Förnamn="Mikael", Efternamn="Gonzales"},
                new Medlem { Förnamn="Anna", Efternamn="Anka"},
                new Medlem { Förnamn="Zeta", Efternamn="Björn"},
                new Medlem { Förnamn="Bertil", Efternamn="Börjesson"},
                new Medlem { Förnamn="Christer", Efternamn="Carlsson"},
            };
            context.Medlemmar.AddOrUpdate(m=>m.Förnamn, medlemmar);
            context.SaveChanges();

            var fordonstyper = new[]
            {
                new Fordonstyp { Typ="Bil" },
                new Fordonstyp { Typ="Motorcykel" },
                new Fordonstyp { Typ="Buss" },
                new Fordonstyp { Typ="Båt" },
                new Fordonstyp { Typ="Flygplan" }
            };
            context.Fordonstyper.AddOrUpdate(m => m.Typ, fordonstyper);
            context.SaveChanges();

            var fordon = new[]
            {
                new Fordon { MedlemsId=medlemmar[0].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL111", Märke = "Volvo", Modell = "850", Färg = "Röd", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[1].MedlemsId,  FordonstypId=fordonstyper[1].FordonstypId , Tid=datetime,  RegNr = "BIL222", Märke = "Volvo", Modell = "850", Färg = "Gul", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[2].MedlemsId,  FordonstypId=fordonstyper[2].FordonstypId , Tid=datetime,  RegNr = "BIL333", Märke = "Volvo", Modell = "850", Färg = "Röd", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[3].MedlemsId,  FordonstypId=fordonstyper[3].FordonstypId , Tid=datetime,  RegNr = "BIL444", Märke = "Volvo", Modell = "850", Färg = "Röd", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[4].MedlemsId,  FordonstypId=fordonstyper[4].FordonstypId , Tid=datetime,  RegNr = "BIL555", Märke = "Volvo", Modell = "850", Färg = "Röd", AntalHjul = 4},
            };
            context.Fordons.AddOrUpdate(m => m.RegNr, fordon);
            context.SaveChanges();
        }
    }
    }

