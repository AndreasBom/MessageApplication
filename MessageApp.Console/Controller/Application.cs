﻿using System.Net;
using MessageApp.Console.Model;
using MessageApp.Console.View;

namespace MessageApp.Console.Controller
{

    /// <summary>
    ///Application Controller
    /// Will return false if user input is 'q', otherwise true
    /// </summary>
    public class Application
    {
        private readonly IConsoleView _view;
        private readonly ISender _sender;
        private bool _isIntroductionVisible = true;

        public Application(IConsoleView view, ISender sender)
        {
            _view = view;
            _sender = sender;
        }


        //Run Application
        public bool Run()
        {
            //Instructions. Only visible when app starts
            if (_isIntroductionVisible)
            {
                _view.ShowIntroduction();
                _isIntroductionVisible = false;
            }
           
            var input = _view.UserInput();

            //Quit application
            if (input.ToLower() == "q")
            {
                return false;
            }

            //Send message to server
            try
            {
                _view.ShowSendingConfirmation();
                var response =_sender.Post(input);

                if (response == HttpStatusCode.Created)
                {
                    _view.ShowSuccessfullySent();
                }
                
            }
            catch (WebException ex)
            {
                _view.ErrorMessage(ex);
            }

            return true;
        }

    }
}