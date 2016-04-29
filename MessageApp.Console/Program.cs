using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageApp.Console.Controller;
using MessageApp.Console.DevCode;
using MessageApp.Console.Model;
using MessageApp.Console.View;
using MessageApp.Domain.Repositories;

namespace MessageApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceUrl = "http://localhost:54663/message";
            var apiKey = "123456";

            var view = new ConsoleView();
            var sender = new Sender(serviceUrl, apiKey);
            var app = new Application(view, sender);

            view.SetTitle();

            while (app.Run()) { }
        }
    }
}
