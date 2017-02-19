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



            var fordonstyper = new[]
            {
                new Fordonstyp { FordonstypId=1,Typ="Bil" },
                new Fordonstyp { FordonstypId=2,Typ="Motorcykel" },
                new Fordonstyp { FordonstypId=3,Typ="Båt" },
                new Fordonstyp { FordonstypId=4,Typ="Buss" },
                new Fordonstyp { FordonstypId=5,Typ="Flygplan" }
            };
            context.Fordonstyp.AddRange(fordonstyper);
            context.SaveChanges();

            var medlemmar = new[]
           {
                new Medlem { MedlemsId=1,Förnamn="Mikael", Efternamn="Gonzales", adress="abc123, 12345", Ort="Stockholm"},
                new Medlem { MedlemsId=2,Förnamn="Anna", Efternamn="Anka", adress="xyz123, 12899", Ort="Stockholm"},
                new Medlem { MedlemsId=3,Förnamn="Adam", Efternamn="Andersson", adress="abc456, 15678", Ort="Stockholm"},
                new Medlem { MedlemsId=4,Förnamn="Bertil", Efternamn="Börjesson", adress="sdf543, 98765", Ort="Stockholm"},
                new Medlem { MedlemsId=5,Förnamn="Christer", Efternamn="Carlsson", adress="fsg644, 56874", Ort="Stockholm"},
            };
            context.Medlemmar.AddRange(medlemmar);
            context.SaveChanges();
            var fordon = new[]
            {
                new Fordon { Id=1,MedlemsId=medlemmar[0].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL111", Märke = "Volvo", Modell = "850", Färg = "Röd", AntalHjul = 4},
                new Fordon { Id=2,MedlemsId=medlemmar[1].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL222", Märke = "BMW", Modell = "550", Färg = "Gul", AntalHjul = 4},
                new Fordon { Id=3,MedlemsId=medlemmar[2].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL333", Märke = "Audi", Modell = "A7", Färg = "Röd", AntalHjul = 4},
                new Fordon { Id=4,MedlemsId=medlemmar[3].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL444", Märke = "Toyota", Modell = "Lexus", Färg = "Vit", AntalHjul = 4},
                new Fordon { Id=5,MedlemsId=medlemmar[4].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL555", Märke = "Mercedes", Modell = "S550", Färg = "Silver", AntalHjul = 4},
            };
            context.Fordon.AddRange(fordon);
            context.SaveChanges();
        }
    }
}
