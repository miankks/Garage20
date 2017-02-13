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
            ContextKey = "Garage20.DAL.Garage20Context";
        }

        protected override void Seed(Garage20.DAL.Garage20Context context)
        {
            context.Fordons.AddOrUpdate(x=>x.Id,
                new Fordon { RegNr = "BIL111", Typ = Typ.Bil, M�rke = "Volvo", Modell = "850", F�rg = "R�d", AntalHjul = 4 },
                new Fordon { RegNr = "BIL222", Typ = Typ.Bil, M�rke = "Volkswagen", Modell = "Golf", F�rg = "Gr�", AntalHjul = 4 },
                new Fordon { RegNr = "BIL333", Typ = Typ.Bil, M�rke = "Mercedes-Benz", Modell = "220", F�rg = "Svart", AntalHjul = 4 },
                new Fordon { RegNr = "BIL444", Typ = Typ.Bil, M�rke = "Ferrari", Modell = "Testarossa", F�rg = "R�d", AntalHjul = 4 },
                new Fordon { RegNr = "BIL555", Typ = Typ.Bil, M�rke = "Citro�n", Modell = "C4", F�rg = "Vit", AntalHjul = 4 },
                new Fordon { RegNr = "BUS111", Typ = Typ.Buss, M�rke = "Scania", Modell = "850", F�rg = "Gul", AntalHjul = 4 },
                new Fordon { RegNr = "BUS222", Typ = Typ.Buss, M�rke = "Renault", Modell = "Golf", F�rg = "R�d", AntalHjul = 6 },
                new Fordon { RegNr = "BUS333", Typ = Typ.Buss, M�rke = "Mercedes-Benz", Modell = "220", F�rg = "Bl�", AntalHjul = 6 },
                new Fordon { RegNr = "BUS444", Typ = Typ.Buss, M�rke = "Volvo", Modell = "Testarossa", F�rg = "Svart", AntalHjul = 8 },
                new Fordon { RegNr = "BUS555", Typ = Typ.Buss, M�rke = "MAN", Modell = "C4", F�rg = "Gr�n", AntalHjul = 10 },
                new Fordon { RegNr = "MCF111", Typ = Typ.Motorcykel, M�rke = "Yamaha", Modell = "500cc", F�rg = "Gul", AntalHjul = 2 },
                new Fordon { RegNr = "MCK222", Typ = Typ.Motorcykel, M�rke = "Honda", Modell = "FCX", F�rg = "R�d", AntalHjul = 2 },
                new Fordon { RegNr = "MCG333", Typ = Typ.Motorcykel, M�rke = "Harley-Davidson", Modell = "Softail", F�rg = "Bl�", AntalHjul = 2 },
                new Fordon { RegNr = "MCH444", Typ = Typ.Motorcykel, M�rke = "Kawasaki", Modell = "ZX-12R", F�rg = "Svart", AntalHjul = 2 },
                new Fordon { RegNr = "MCJ555", Typ = Typ.Motorcykel, M�rke = "Aprilia", Modell = "RS125", F�rg = "Gr�n", AntalHjul = 3 });
        }
    }
}
