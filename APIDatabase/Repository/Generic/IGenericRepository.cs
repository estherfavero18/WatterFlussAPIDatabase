using APIDatabase.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Repository.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        List<T> FindAll();
        public T FindById(int id);
        public T Create(T item);
        public void Delete(int id);
        public T Update(T item);
    }
}
