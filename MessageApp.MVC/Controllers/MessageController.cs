using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using MessageApp.Domain.DAL.Entities;
using MessageApp.Domain.Repositories;
using MessageApp.Domain.Services;
using MessageApp.MVC.ViewModel;
using Newtonsoft.Json;

namespace MessageApp.MVC.Controllers
{
    public class MessageController : Controller
    {
        private string _apiKey = ConfigurationManager.AppSettings["apiKey"];
        private IMessageService _service;


        public MessageController()
            : this(new MessageService())
        {

        }

        public MessageController(IMessageService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            //Delete all messages in database
            //DeleteAllDataInDatabase();

            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public void SaveMessage()
        {
            var headers = Request.Headers;
            //Reading request body and convert to Message-Object
            var jsonString = string.Empty;
            var request = Request.InputStream;
            request.Seek(0, System.IO.SeekOrigin.Begin);
            using (var sr = new StreamReader(request))
            {
                jsonString = sr.ReadToEnd();
            }
            var json = JsonConvert.DeserializeObject<Message>(jsonString);

            //Save to database
            if (headers.Get("X-API-KEY") == _apiKey)
            {
                _service.AddMessage(json);
                _service.Save();
            }
        }

        [HttpGet]
        public ActionResult GetMessages()
        {
            var vm = new MessageViewModel();
            var messages = vm.Message.ToList();

            return Json(messages, JsonRequestBehavior.AllowGet);
        }


        //Catches all unhandled exceptions
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            ModelState.AddModelError(string.Empty, "Något gick fel");

            filterContext.Result = RedirectToAction("Index");
        }

        //For development
        private void DeleteAllDataInDatabase()
        {
            var repo = new MessageRepository();
            var messages = repo.GetAllMessages();
            foreach (var message in messages)
            {
                repo.DeleteMessage(message.Id);
            }
            repo.Save();
        }

    }
}