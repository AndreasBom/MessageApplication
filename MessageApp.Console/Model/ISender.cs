using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Console.Model
{
    public interface ISender
    {
        HttpStatusCode Post(string message);
    }
}
