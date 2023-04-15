
Operation mySum = Functions.Sum;
Console.WriteLine(mySum(2,3));

mySum = Functions.Mul;
Console.WriteLine(mySum(2,3));

Show cw = Console.WriteLine;
cw += Functions.ConsoleShow;
cw("hola mundo");

Functions.Some("Juan", "Guevara", cw);
#region Action
string hi = "Hola";
//Action es para no retornar
Action<string> showMessage = Console.WriteLine;
Functions.someAction("Hector", "De Leon", showMessage);

//funciones anonimas con  lambda
Functions.someAction("Hector", "De Leon", (a) =>
{
    Console.WriteLine("Soy una expresión lambda "+a);
});
Action<string, string> showMessage2 = (a, b) =>
{
    Console.WriteLine($"{hi} {a} {b}");
};

Action<string, string, string> showMessage3 = (a, b, c) => Console.WriteLine($"{hi} {a} {b} {c}");

showMessage2("Ennio", "Saenz");
showMessage3("Ennio", "Saenz", "Martinez");

#endregion


#region Func
// func nos ahorra crear tantos delegados, siempre regresara algo del tipo que se encuentre de ultimo, o slo puede retornar si solo se le coloca un tipo
Func<int> numberRandom = () => new Random().Next(0, 100);
Func<int, string> numberRandomLimit = (limit) => new Random().Next(0, limit).ToString();

Console.WriteLine(numberRandom());
Console.WriteLine(numberRandomLimit(1000));
#endregion

#region Predicate
// delegado generico para crear delegado que tienen un tipo de una funcion que reciba algo pero siempre regrese True o False
//Verifica si la cadena de caracteres contiene espacio o contenga la letra a
Predicate<string> hasSpaceOrA = (word) => word.Contains(" ") || word.ToUpper().Contains("A");
Console.WriteLine(hasSpaceOrA("beer"));
Console.WriteLine(hasSpaceOrA("p ati to"));

var words = new List<string>(){
    "beer",
    "patito",
    "sandia",
    "hola mundo",
    "c#"
};
var wordsNew = words.FindAll( w => !hasSpaceOrA(w));
foreach(var w in wordsNew) Console.WriteLine(w);

#endregion

#region Delegados
delegate int Operation(int a, int b);
public delegate void Show(string message);
public delegate void Show2(string message, string message2);
public delegate void Show3(string message, string message2, string message3);

# endregion
//Definiciones abajo programación arriba
public class Functions
{
    public static int Sum(int x, int y) => x + y;
    public static int Mul(int num1, int num2) => num1 * num2;
    public static void ConsoleShow(string m) => Console.WriteLine(m.ToUpper());

    //Función de orden superiror, acepta delegados
    public static void Some(string name, string lastName, Show fn)
    {
        Console.WriteLine("Haga algo al inicio");
        //call back, se ejecute hasta que termine de ejecutarse el código anterior, puede usarse con bases de datos
        fn($"{name} {lastName}");
        //igualmente se puede ejecutar otra linea de código hasta que finalice el proceso de la linea del callback
        Console.WriteLine("Haga algo al final");
    }

    //Función de orden superiror, acepta delegados
    public static void someAction(string name, string lastName, Action<string> fn)
    {
        Console.WriteLine("Haga algo al inicio");
        //call back, se ejecute hasta que termine de ejecutarse el código anterior, puede usarse con bases de datos
        fn($"{name} {lastName}");
        //igualmente se puede ejecutar otra linea de código hasta que finalice el proceso de la linea del callback
        Console.WriteLine("Haga algo al final");
    }
}