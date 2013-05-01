using System;
namespace WebApiPostIt.Controllers
{
    public interface IRepository
    {
        System.Collections.Generic.List<PostIt> GetAll();
        void Remove(int i);
        void Save(System.Collections.Generic.List<PostIt> items);
        void Save();
        PostIt Get(int id);
        void Add(PostIt postit);
    }
}
