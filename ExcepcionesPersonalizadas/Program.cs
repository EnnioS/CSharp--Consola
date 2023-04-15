using System;
namespace ExcepcionesPersonalizadas
{
    class Program
    {
        static void Main(string[] args)
        {

           

            try
            {
                beer beer = new beer()
                {
                    Name = "London Porter",
                    //Brand = "Fuller´s"
                };

                Console.WriteLine(beer);
            }
            catch (InvalidBeerException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public class InvalidBeerException : Exception
        {
            public InvalidBeerException() :
                base("La cerveza no tiene nombre o marca, por lo cual es invalida")
            {

            }
        }

        public class beer
        {
            public string Name { get; set; }
            public string Brand { get; set; }

            public override string ToString()
            {
                if (Name == null || Brand == null)
                    throw new InvalidBeerException();

                return $"Cerveza: {Name}, Brand: {Brand}";
              
            }
        }
    }
}