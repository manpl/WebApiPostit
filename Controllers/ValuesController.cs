using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPostIt.Controllers
{
    public class PostIt
    {
        public DateTime CreatedOn { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
    }

    public class ValuesController : ApiController
    {
        List<PostIt> postits = new List<PostIt>() { 
            new PostIt{CreatedOn = new DateTime(2012, 11, 11), Content= "TEST1", Subject="TEST1", User="USER"},
            new PostIt{CreatedOn = new DateTime(2011, 11, 11), Content= "TEST2", Subject="TEST2", User="USER"},
            new PostIt{CreatedOn = new DateTime(2014, 11, 11), Content= "TEST3", Subject="TEST3", User="USER"},
            new PostIt{CreatedOn = new DateTime(2015, 11, 11), Content= "TEST4", Subject="TEST4", User="USER"},
        };

        // GET api/values
        public IEnumerable<PostIt> Get()
        {
            return postits;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}