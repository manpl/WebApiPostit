using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace WebApiPostIt.Controllers
{
    public class PostItDbContext : DbContext
    {
        public DbSet<PostIt> Postits { get; set; }
    }

    public class DbRepository : IRepository
    {
        private PostItDbContext dbContext;

        public DbRepository(PostItDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<PostIt> GetAll()
        {
            var items = dbContext.Postits.ToList();

            return items;
        }

        public void Remove(int i)
        {
            var postIt = this.Get(i);
            this.dbContext.Postits.Remove(postIt);
        }

        public void Add(PostIt postit)
        {
            this.dbContext.Postits.Add(postit);
        }

        public void Save(List<PostIt> items)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public PostIt Get(int id)
        {
            return this.dbContext.Postits.SingleOrDefault(item => item.Id == id);
        }
    }

    public class PostItController : ApiController
    {
        IRepository repository;

        public PostItController(IRepository repo)
        {
            this.repository = repo;
        }

        // GET api/values
        public IEnumerable<PostIt> Get()
        {
            return repository.GetAll();
        }

        // GET api/values/5
        public PostIt Get(int id)
        {
            return repository.GetAll().Single(p => p.Id == id);
        }


        // add
        // POST api/values
        public HttpResponseMessage Post([FromBody]PostIt value)
        {
            var items = repository.GetAll();
            value.Id = items.Any() ? items.Max(item => item.Id) + 1 : 1;
            value.User = Thread.CurrentPrincipal.Identity.Name;
            repository.Add(value);
            repository.Save();

            return Request.CreateResponse<PostIt>(HttpStatusCode.Created, value);
        }

        // update
        // PUT api/values/5
        public PostIt Put([FromBody]PostIt value)
        {
            var postit = repository.Get(value.Id);

            if(postit == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            postit.Subject = value.Subject;
            postit.DisplayData = value.DisplayData;
            postit.Content = value.Content;

            repository.Save();

            return value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            repository.Remove(id);
            repository.Save();
        }
    }
}