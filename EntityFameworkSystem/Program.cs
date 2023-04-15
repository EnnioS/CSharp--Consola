using BD;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
namespace EnttyFrameworkSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            DbContextOptionsBuilder<CsharpDbContext> optionsBuilder = new DbContextOptionsBuilder<CsharpDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-JQM79AM;Database=CSharpDB;Trusted_Connection=True;TrustServerCertificate=True;");//se puede usar sin estas dos ultimas lineas, la diferencia esta en que de sta manera se puede utilizar conexiones de otros sevidores o biblioteca de clases de entity famework diferente a la DB, de no tener esta cadena de conexión automaticamente se conecta con la bilioteca de clases "DB"

            bool again = true;
            int op = 0;
            do
            {
                ShowMenu();
                Console.WriteLine("Elige una opción: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Show(optionsBuilder);
                        break;
                    case 2:
                        Add(optionsBuilder);
                        break;
                      
                    case 3:
                        Edit(optionsBuilder);
                        break;
                    case 4:
                        Delete(optionsBuilder);
                        break;
                    case 5:
                        again = false;
                        break;
                }
                       
            } while (again);
        }

        public static void Show(DbContextOptionsBuilder<CsharpDbContext> optionBuilder)
        {
            Console.Clear();
            Console.WriteLine("Cervezas en la base de datos");
            using (var context = new CsharpDbContext(optionBuilder.Options))// using iiene una interfaz heredada de disp´sable, el cual hace el cierre de la conexion a la base de datos, pero dentro de using al cerrar la llave el cierre lo hace automaticamente
            {
                var beers = context.Beers.OrderBy(b => b.Name).ToList();
                var beers2 = (from b in context.Beers where b.BrandId == 2 orderby b.Name select b).Include(b=>b.Brand).ToList();// el resultado es lo mismo que la linea anterior solo que se le agrega un where y se realiza un join con el include
                foreach (var beer in beers)
                {
                    Console.WriteLine($"{beer.Id} - {beer.Name}");// {beer.Brand.Name} usarlo para el join en beer2
                }
                
            }
        }

        public static void Add(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Console.WriteLine("Agregar Nueva Cerveza");
            Console.WriteLine("Escriba el Nombre: ");
            string name = Console.ReadLine();
            Console.WriteLine("Escriba el Id de la marca: ");
            int brandId = int.Parse(Console.ReadLine());
            using (var context = new CsharpDbContext(optionsBuilder.Options))
            {
                Beer beer = new Beer()
                {
                    Name = name,
                    BrandId = brandId
                };

                context.Add(beer);
                context.SaveChanges();
            }
        }

        public static void Edit(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Editar Cerveza");
            Console.WriteLine("Escriba el Id de tu cerveza a editar: ");
            int id = int.Parse(Console.ReadLine());
            using (var context = new CsharpDbContext(optionsBuilder.Options))
            {
                Beer beer = context.Beers.Find(id);
                if(beer != null)
                {
                    Console.WriteLine("Escriba el nombre: ");
                    string name = Console.ReadLine();
                    int brandId = int.Parse(Console.ReadLine());
                    beer.Name = name;
                    beer.BrandId = brandId;
                    context.Entry(beer).State = EntityState.Modified;
                    context.SaveChanges();

                    Console.WriteLine("Cerveza Actualizada");
                }
                else
                {

                    Console.WriteLine("Cerveza no existe");
                }
            }
        }

        public static void Delete(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Eliminar Cerveza");
            Console.WriteLine("Escriba el Id de la Cerveza a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (var context = new CsharpDbContext(optionsBuilder.Options))
            {
                Beer beer = context.Beers.Find(id);
                if (beer != null)
                {
                    context.Beers.Remove(beer);
                    context.SaveChanges();
                    Console.WriteLine("Cerveza Eliminada");
                }
                else
                {
                    Console.WriteLine("Cerveza no existe");
                }
            }
        }

            public static void ShowMenu()
        {
            Console.WriteLine("\n-----------menu---------------");
            Console.WriteLine("1.- Mostrar");
            Console.WriteLine("1.- Agregar");
            Console.WriteLine("1.- Editar");
            Console.WriteLine("1.- Salir");
        }
    }
}