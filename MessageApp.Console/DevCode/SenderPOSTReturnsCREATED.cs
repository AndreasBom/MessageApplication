using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MessageApp.Console.Model;

namespace MessageApp.Console.DevCode
{ 
    public class SenderPOSTReturnsCREATED : ISender
    {
        public HttpStatusCode Post(string message)
        {
            return HttpStatusCode.Created;
        }

    }
}
