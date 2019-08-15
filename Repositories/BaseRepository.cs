using System.Collections.Generic;
using System.Threading.Tasks;


namespace Document.Repository
{
    public abstract class BaseRepository<T>
    {
        public abstract Task<T> GetId(int code);
        public abstract Task<IList<T>> GetAll();
        public abstract Task Insert(T obj);
        public abstract void Edit(T obj);
        public abstract void Delete(T obj);
        public abstract Task<int> Save();
    }
}