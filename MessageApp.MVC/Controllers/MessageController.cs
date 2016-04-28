using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageApp.Domain;
using MessageApp.Domain.Services;

namespace MessageApp.MVC.Controllers
{
    public class MessageController : Controller
    {
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
            return View();
        }

    }
}