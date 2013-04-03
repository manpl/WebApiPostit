using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public int Id { get; set; }
        public object DisplayData { get; set; }
    }

    public class Repository
    {

        public List<PostIt> GetAll()
        {
            var content = File.ReadAllText(@"c:\temp\test.data");
                
            return JsonConvert.DeserializeObject<List<PostIt>>(content);
        }

        public void Save(List<PostIt> items)
        {
             File.WriteAllText(@"c:\temp\test.data", JsonConvert.SerializeObject(items));
        }
    }

    public class ValuesController : ApiController
    {
        Repository repo = new Repository();
        // GET api/values
        public IEnumerable<PostIt> Get()
        {
            return repo.GetAll();
        }

        // GET api/values/5
        public PostIt Get(int id)
        {
            return repo.GetAll().Single(p => p.Id == id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            
        }

        // PUT api/values/5
        public void Put([FromBody]PostIt value)
        {
            var items = repo.GetAll();
            items.Add(value);
            repo.Save(items);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var allItems = repo.GetAll();

            allItems.RemoveAll(item => item.Id == id);
            
            repo.Save(allItems);
        }
    }
}