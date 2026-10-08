using System.Collections.Generic;

namespace MonoPraksa.Repository.Common
{
    public interface IFootballerRepository
    {
        IEnumerable<Footballer> GetAll();
        Footballer GetById(int id);
        void Add(Footballer player);
        void Remove(Footballer player);
    }
}