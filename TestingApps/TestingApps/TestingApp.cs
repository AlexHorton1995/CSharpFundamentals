
using System.Runtime.CompilerServices;

namespace TestingApps
{
    public class TestingApp
    {
        static void Main(string[] args)
        {

            Console.WriteLine(SayHelloWorld());
            Console.WriteLine(SayYo());
            Console.WriteLine(SayGreetings());
            Console.WriteLine();
            Console.WriteLine("press any key to continue");
            Console.ReadLine();

            Console.WriteLine("Bye!");

        }

        public static string SayHelloWorld()
        {
            return "Hello World!";
        }

        public static string SayYo()
        {
            return "  YOTVRAPS!";
        }

        public static string SayGreetings()
        {
            return "Greetings!";
        }

    }
}