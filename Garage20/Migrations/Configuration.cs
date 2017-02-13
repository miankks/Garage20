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
                new Fordon { RegNr = "BIL111", Typ = Typ.Bil, Märke = "Volvo", Modell = "850", Färg = "Röd", AntalHjul = 4 },
                new Fordon { RegNr = "BIL222", Typ = Typ.Bil, Märke = "Volkswagen", Modell = "Golf", Färg = "Grå", AntalHjul = 4 },
                new Fordon { RegNr = "BIL333", Typ = Typ.Bil, Märke = "Mercedes-Benz", Modell = "220", Färg = "Svart", AntalHjul = 4 },
                new Fordon { RegNr = "BIL444", Typ = Typ.Bil, Märke = "Ferrari", Modell = "Testarossa", Färg = "Röd", AntalHjul = 4 },
                new Fordon { RegNr = "BIL555", Typ = Typ.Bil, Märke = "Citroën", Modell = "C4", Färg = "Vit", AntalHjul = 4 },
                new Fordon { RegNr = "BUS111", Typ = Typ.Buss, Märke = "Scania", Modell = "850", Färg = "Gul", AntalHjul = 4 },
                new Fordon { RegNr = "BUS222", Typ = Typ.Buss, Märke = "Renault", Modell = "Golf", Färg = "Röd", AntalHjul = 6 },
                new Fordon { RegNr = "BUS333", Typ = Typ.Buss, Märke = "Mercedes-Benz", Modell = "220", Färg = "Blå", AntalHjul = 6 },
                new Fordon { RegNr = "BUS444", Typ = Typ.Buss, Märke = "Volvo", Modell = "Testarossa", Färg = "Svart", AntalHjul = 8 },
                new Fordon { RegNr = "BUS555", Typ = Typ.Buss, Märke = "MAN", Modell = "C4", Färg = "Grön", AntalHjul = 10 },
                new Fordon { RegNr = "MCF111", Typ = Typ.Motorcykel, Märke = "Yamaha", Modell = "500cc", Färg = "Gul", AntalHjul = 2 },
                new Fordon { RegNr = "MCK222", Typ = Typ.Motorcykel, Märke = "Honda", Modell = "FCX", Färg = "Röd", AntalHjul = 2 },
                new Fordon { RegNr = "MCG333", Typ = Typ.Motorcykel, Märke = "Harley-Davidson", Modell = "Softail", Färg = "Blå", AntalHjul = 2 },
                new Fordon { RegNr = "MCH444", Typ = Typ.Motorcykel, Märke = "Kawasaki", Modell = "ZX-12R", Färg = "Svart", AntalHjul = 2 },
                new Fordon { RegNr = "MCJ555", Typ = Typ.Motorcykel, Märke = "Aprilia", Modell = "RS125", Färg = "Grön", AntalHjul = 3 });
        }
    }
}
