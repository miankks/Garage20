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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Garage20.DAL.Garage20Context context)
        {
            var medlemmar = new[]
           {
                new Medlem {  MedlemsId=0,Förnamn="Mikael", Efternamn="Gonzales"},
                new Medlem { MedlemsId=1,Förnamn="Anna", Efternamn="Anka"},
                new Medlem { MedlemsId=2,Förnamn="Adam", Efternamn="Andersson"},
                new Medlem { MedlemsId=3,Förnamn="Bertil", Efternamn="Börjesson"},
                new Medlem { MedlemsId=4,Förnamn="Christer", Efternamn="Carlsson"},
            };
            context.Medlemmar.AddRange(medlemmar);
            context.SaveChanges();

            var fordonstyper = new[]
            {
                new Fordonstyp { FordonstypId=0,Typ="Bil" },
                new Fordonstyp { FordonstypId=1,Typ="Motorcykel" },
                new Fordonstyp { FordonstypId=2,Typ="Båt" },
                new Fordonstyp { FordonstypId=3,Typ="Buss" },
                new Fordonstyp { FordonstypId=4,Typ="Flygplan" }
            };
            context.Fordonstyper.AddRange(fordonstyper);
            context.SaveChanges();

            var fordon = new[]
            {
                new Fordon { Id, MedlemsId=medlemmar[0].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=DateTime.Now,  RegNr = "BIL111", Märke = "Volvo", Modell = "850", Färg = "Röd", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[1].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=DateTime.Now,  RegNr = "BIL222", Märke = "Volvo", Modell = "850", Färg = "Gul", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[2].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=DateTime.Now,  RegNr = "BIL333", Märke = "Volvo", Modell = "850", Färg = "Röd", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[3].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=DateTime.Now,  RegNr = "BIL444", Märke = "Volvo", Modell = "850", Färg = "Röd", AntalHjul = 4},
                new Fordon { MedlemsId=medlemmar[4].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=DateTime.Now,  RegNr = "BIL555", Märke = "Volvo", Modell = "850", Färg = "Röd", AntalHjul = 4},
            };
            context.Fordons.AddRange(fordon);
            context.SaveChanges();
        }
    }
}
