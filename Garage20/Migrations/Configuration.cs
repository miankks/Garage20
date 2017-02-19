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
                new Fordonstyp { FordonstypId=3,Typ="B�t" },
                new Fordonstyp { FordonstypId=4,Typ="Buss" },
                new Fordonstyp { FordonstypId=5,Typ="Flygplan" }
            };
            context.Fordonstyp.AddRange(fordonstyper);
            context.SaveChanges();

            var medlemmar = new[]
           {
                new Medlem { MedlemsId=1,F�rnamn="Mikael", Efternamn="Gonzales", adress="abc123, 12345", Ort="Stockholm"},
                new Medlem { MedlemsId=2,F�rnamn="Anna", Efternamn="Anka", adress="xyz123, 12899", Ort="Stockholm"},
                new Medlem { MedlemsId=3,F�rnamn="Adam", Efternamn="Andersson", adress="abc456, 15678", Ort="Stockholm"},
                new Medlem { MedlemsId=4,F�rnamn="Bertil", Efternamn="B�rjesson", adress="sdf543, 98765", Ort="Stockholm"},
                new Medlem { MedlemsId=5,F�rnamn="Christer", Efternamn="Carlsson", adress="fsg644, 56874", Ort="Stockholm"},
            };
            context.Medlemmar.AddRange(medlemmar);
            context.SaveChanges();
            var fordon = new[]
            {
                new Fordon { Id=1,MedlemsId=medlemmar[0].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL111", M�rke = "Volvo", Modell = "850", F�rg = "R�d", AntalHjul = 4},
                new Fordon { Id=2,MedlemsId=medlemmar[1].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL222", M�rke = "BMW", Modell = "550", F�rg = "Gul", AntalHjul = 4},
                new Fordon { Id=3,MedlemsId=medlemmar[2].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL333", M�rke = "Audi", Modell = "A7", F�rg = "R�d", AntalHjul = 4},
                new Fordon { Id=4,MedlemsId=medlemmar[3].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL444", M�rke = "Toyota", Modell = "Lexus", F�rg = "Vit", AntalHjul = 4},
                new Fordon { Id=5,MedlemsId=medlemmar[4].MedlemsId,  FordonstypId=fordonstyper[0].FordonstypId , Tid=datetime,  RegNr = "BIL555", M�rke = "Mercedes", Modell = "S550", F�rg = "Silver", AntalHjul = 4},
            };
            context.Fordon.AddRange(fordon);
            context.SaveChanges();
        }
    }
}
