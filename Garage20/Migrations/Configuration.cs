namespace Garage20.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2._5.DAL.FordonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Garage2._5.DAL.FordonContext context)
        {
            var datetime = DateTime.Now;

            var medlemmar = new[]
            {
                new Medlem { F�rnamn="Mikael", Efternamn="Gonzales"},
                new Medlem { F�rnamn="Anna", Efternamn="Anka"},
                new Medlem { F�rnamn="Adam", Efternamn="Andersson"},
                new Medlem { F�rnamn="Bertil", Efternamn="B�rjesson"},
                new Medlem { F�rnamn="Christer", Efternamn="Carlsson"},
            };
            context.Medlemmar.AddRange(medlemmar);
            context.SaveChanges();

            var fordonstyper = new[]
            {
                new Fordonstyp { Typ="Bil" },
                new Fordonstyp { Typ="Motorcykel" },
                new Fordonstyp { Typ="B�t" },
                new Fordonstyp { Typ="Buss" },
                new Fordonstyp { Typ="Flygplan" }
            };
            context.Fordonstyp.AddRange(fordonstyper);
            context.SaveChanges();

            var fordon = new[]
            {
                new Fordon { MedlemsId=medlemmar[0].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL111", M�rke = "Volvo", Modell = "850", F�rg = "R�d", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[1].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL222", M�rke = "Volvo", Modell = "850", F�rg = "Gul", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[2].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL333", M�rke = "Volvo", Modell = "850", F�rg = "R�d", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[3].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL444", M�rke = "Volvo", Modell = "850", F�rg = "R�d", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[4].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL555", M�rke = "Volvo", Modell = "850", F�rg = "R�d", AntalHjul = 4},
            };
            context.Fordon.AddRange(fordon);
            context.SaveChanges();
        }
    }
}
