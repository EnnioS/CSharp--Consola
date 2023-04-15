using System;
namespace LINQ_Join
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Beer> beers = new List<Beer>()
            {
                new Beer()
                {
                    Name = "Corona", Country = "México"
                },
                new Beer()
                {
                    Name= "Delirium", Country = "Bélgica"
                },
                new Beer()
                {
                    Name= "Erdinger", Country = "Alemania"
                }
            };

            var countries = new List<Country>()
            {
                new Country()
                {
                    Name = "Corona", Continent = "México"
                },
                new Country()
                {
                    Name= "Delirium", Continent = "Bélgica"
                },
                new Country()
                {
                    Name= "Erdinger", Continent = "Alemania"
                }
            };
            try
            {
                var beersWithContinent = from beer in beers
                                         join country in countries
                                         on beer.Country equals country.Name
                                         select new
                                         {
                                             Name = beer.Name,
                                             Country = beer.Country,
                                             Continent = country.Continent
                                         };

                foreach (var beer in beersWithContinent) Console.WriteLine($"{beer.Name} {beer.Country} {beer.Continent}");
            }
            catch ( Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class Beer
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"$Nombre: {Name} Pais: {Country}";

        }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Continent { get; set; }

        public override string ToString()
        {
            return $"$Nombre: {Name} Pais: {Continent}";

        }
    }
}