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
        static Repository()
        {
    
            var Items = new List<PostIt>() { 
            new PostIt{Id = 1,CreatedOn = new DateTime(2012, 11, 11), Content= "TEST1", Subject="TEST1", User="USER", DisplayData = new { X = 0, Y = 0 }},
            new PostIt{Id = 2,CreatedOn = new DateTime(2011, 11, 11), Content= "TEST2", Subject="TEST2", User="USER", DisplayData = new { X = 250, Y = 0 }},
            new PostIt{Id = 3,CreatedOn = new DateTime(2014, 11, 11), Content= "TEST3", Subject="TEST3", User="USER", DisplayData = new { X = 500, Y = 0 }},
            new PostIt{Id = 4,CreatedOn = new DateTime(2015, 11, 11), Content= "TEST4", Subject="TEST4", User="USER", DisplayData = new { X = 750, Y = 0 }},
            };

            File.WriteAllText(@"c:\temp\test.data", JsonConvert.SerializeObject(Items));
        }

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
            value.DisplayData = new {X = 100, Y = 100};

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