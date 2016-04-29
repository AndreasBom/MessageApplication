using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Console.View
{
    public interface IConsoleView
    {
        void ShowIntroduction();
        string UserInput();
        void ErrorMessage(Exception exeption);
        void ErrorMessage();
        void ShowSendingConfirmation();

        void ShowSuccessfullySent();
    }
}
