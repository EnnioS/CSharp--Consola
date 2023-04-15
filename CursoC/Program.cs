using System;

namespace CursoC
{
    class Program
    {
        static void Main(string[] args)
        {
            (int id, string name) product = (1, "cerveza stout");
            Console.WriteLine($"{product.id} {product.name}");

            product.name = "Cerveza Porter";
            Console.WriteLine($"{product.id} {product.name}");

            var person = (1, "Héctor", 12.2);
            Console.WriteLine($"{person.Item1} {person.Item2}");

            //Arreglo de Tuplas
            var people = new[]
            {
                (1,"Héctor"),
                (2,"Pedro"),
                (3,"Juan")
            };

            foreach (var p in people)
            {
                Console.WriteLine($"{p.Item1} {p.Item2}");
            }

            
            (int id, string name)[] people2 = new[]
            {
                (1,"Héctor"),
                (2,"Pedro"),
                (3,"Juan")
            };

            foreach (var p in people2)
            {
                Console.WriteLine($"{p.id} {p.name}");
            }

            var cityInfo = getLocationCDMX();
            Console.WriteLine($"lat: {cityInfo.lat} Long: {cityInfo.lng} nombre: {cityInfo.name}");

            //guión bajo ignora el valor de la posición, y cada nombre del elemento de vuelve una variable independiente
            var (_, lng, name) = getLocationCDMX();
            Console.WriteLine(lng);
            Console.WriteLine(name);

        }

        public static (float lat, float lng, string name) getLocationCDMX()
        {
            float lat = 19.12121f;
            float lng = -99.19212f;
            string name = "CDMX";

            return (lat, lng, name);
        }

    }
}