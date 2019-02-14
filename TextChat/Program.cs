using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextChat.InputHandler;

namespace TextChat
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            InputHandler inputHandler = new InputHandler();

            Console.WriteLine("Welcome to ChatBot2000!");
            Console.WriteLine("\nUse ! for special commands.");
            Console.WriteLine("Use !help for list of all commands.\n");
            Console.WriteLine("-------------------------------------------------------------------------------");

            while (!quit)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                if (input.Length == 0) { Console.WriteLine("No entry detected."); continue; } //Check for a blank input
                if (input[0] == '!') //Trigger for special command
                    if (input.Length == 1) Console.WriteLine("Command expected."); //If the text after the ! is less than 2 characters
                    else inputHandler.Output(input, ref quit);
            }

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.Write("Thank you for using ChatBot 2000! Press any key to quit.");
            Console.ReadKey();
        }
    }
}