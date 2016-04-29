using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MessageApp.Domain;
using MessageApp.Domain.DAL.Entities;
using MessageApp.Domain.Repositories;
using MessageApp.Domain.Services;
using MessageApp.MVC.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageApp.MVC.Controllers
{
    public class MessageController : Controller
    {
        private string _apiKey = "123456";
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
            //DeleteAllDataInDatabase();

            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public void SaveMessage()
        {
            var headers = Request.Headers;
            //Reading request body
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

            var vm = new MessageViewModel();
        }

        public ActionResult GetMessages()
        {
            var vm = new MessageViewModel();
            var model = vm.Message;

            return Json(model, JsonRequestBehavior.AllowGet);

        }

        //Catches all unhandled exceptions and redirects to Errorhandler
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