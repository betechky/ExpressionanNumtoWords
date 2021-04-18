using System;
using System.Text.RegularExpressions;

namespace ExpressionChecker
{
    class Program
    {
        static void Main(string[] args)
        {


            Regex re = new Regex(@"^[a-z]+$");
            Console.WriteLine("The default regular expression checks for at least one digit.");
            Console.WriteLine("Press (Enter) to start the Escape (Esc) key to quit: \n");
            //Console.WriteLine("press enter or Excape");

            ConsoleKeyInfo cki = Console.ReadKey();
            Console.WriteLine("\n------------------------------------------\n");
   
            if (cki.Key == ConsoleKey.Enter)
            {


                do
                {
                    Console.WriteLine("Enter a regular expression (or press ENTER to use the default): " + re);
                    Console.Write("Enter some input : ");
                    string inputStr = Console.ReadLine().ToLower();
                    Console.WriteLine((inputStr) + " matches " + (re) + " ? " + re.IsMatch(inputStr));
                    Console.WriteLine("Press the Escape (Esc) key to quit: \n");
                    ConsoleKeyInfo cki2 = Console.ReadKey();
              
                 
                    while (cki2.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                 
                   Console.Write("\n===============================================\n");
                    
                } while (cki.Key != ConsoleKey.Escape);

              
            }
            else if (cki.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("  Esc key has been pushed");
            }
          
      

           
        }

   
    }
}
