using System.Collections.Generic;

namespace MonoPraksa.Repository.Common
{
    public interface IFootballerRepository
    {
        IEnumerable<Footballers> GetAll();
        Footballers GetById(int id);
        void Add(Footballers player);
        void Remove(Footballers player);
    }
}