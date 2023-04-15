
using System;
using System.IO;//nos ayuda a leer archivos
using System.Reflection.Metadata;
//Controlar situaciones inesperadas
namespace Exepciones
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				//como leer un archivolear 
				string content = File.ReadAllText(@"C:\Users\ennio\OneDrive\Documentos\Cursos\Udemi\CursoCSharp\CursoC\pato.txt");
				Console.WriteLine(content);
				throw new Exception("Ocurrio algo raro");// esta excepcion se arroa en el segundo catch
			}
			catch (FileNotFoundException ex)
			{
                Console.WriteLine(ex);
            }
            catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
			finally
			{
				Console.WriteLine("Aqui me he ejecutado pase lo que pase, Finaly siempre se va a ejecutar");
			}

            throw new Exception("Se sigue ejecutando");

        }
	}
}