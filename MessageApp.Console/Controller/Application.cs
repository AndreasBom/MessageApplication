using System.Net;
using MessageApp.Console.Model;
using MessageApp.Console.View;

namespace MessageApp.Console.Controller
{

    /// <summary>
    ///Application Controller
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


        /// <summary>
        /// Run application
        /// </summary>
        /// <returns>Returns false if user presses 'q' otherwise true</returns>
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
            if (Validate.IsValid(input))
            {
                try
                {
                    _view.ShowSendingConfirmation();
                    var response = _sender.Post(input);

                    if (response == HttpStatusCode.OK)
                    {
                        _view.ShowSuccessfullySent();
                    }
                    else
                    {
                        _view.ErrorMessage();
                    }

                }
                catch (WebException ex)
                {
                    _view.ErrorMessage(ex);
                }
            }
            else
            {
                _view.NotValidErrorMessage();
            }
            

            return true;
        }

    }
}
