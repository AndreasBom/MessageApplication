using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Console.View
{
    public class ConsoleView : IConsoleView
    {
        public string UserInput()
        {
            System.Console.Write("$>");
            return System.Console.ReadLine();

        }

        public void ShowIntroduction()
        {
            System.Console.WriteLine("*** Meddelande Applikation ***");
            System.Console.WriteLine("Skriv in ett meddelande. Skicka genom att trycka enter");
            System.Console.WriteLine("q+Enter avslutar applikationen");
        }

        public void ErrorMessage(Exception exeption)
        {
            System.Console.WriteLine("Ett fel inträffade.");
            System.Console.WriteLine("Var god försök igen.");
        }

        public void ShowSendingConfirmation()
        {
            System.Console.WriteLine("Skickar meddelande...");
        }

        public void ShowSuccessfullySent()
        {
            System.Console.WriteLine("Meddelandet har skickats");
        }
    }
}
