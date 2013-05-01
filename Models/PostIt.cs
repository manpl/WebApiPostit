using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace WebApiPostIt.Controllers
{
    public class PostIt
    {
        public DateTime CreatedOn { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public int Id { get; set; }
        public DisplayData DisplayData { get; set; }
    }

    public class DisplayData
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}