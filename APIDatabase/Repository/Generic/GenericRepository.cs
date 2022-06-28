using APIDatabase.Models.Base;
using APIDatabase.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public readonly SqlServerContext _context;
        private readonly DbSet<T> _dataset;

        public GenericRepository(SqlServerContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public List<T> FindAll()
        {
            return _dataset.OrderBy(t => t.id).ToList();
        }
        public T FindById(int id)
        {
            return _dataset.SingleOrDefault(x => x.id == id);
        }

        public T Create(T item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }

                T result = _dataset.SingleOrDefault(x => x.id == item.id);
                if (result == null)
                {
                    item.id = 0;
                    var response = _dataset.Add(item);
                    _context.SaveChanges();

                    return response.Entity;
                }
                else
                {
                    throw new InvalidOperationException(
                        string.Format("Registro já existente para o id {0}", item.id));
                }
            }
            catch (Exception ex)
            {
                string message;
                if (ex.InnerException != null && ex.InnerException.InnerException != null)
                    message = ex.InnerException.InnerException.Message;
                else if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                throw new InvalidOperationException(message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                T result = _dataset.SingleOrDefault(x => x.id == id);

                if (result != null)
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException(
                        string.Format("Registro inexistente na base de dados para o id {0}", id));
                }
            }
            catch (Exception ex)
            {
                string message;
                if (ex.InnerException != null && ex.InnerException.InnerException != null)
                    message = ex.InnerException.InnerException.Message;
                else if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                throw new InvalidOperationException(message);
            }
        }

        public T Update(T item)
        {
            try
            {
                var result = _dataset.FirstOrDefault(x => x.id == item.id);

                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                else
                {
                    throw new InvalidOperationException(
                        string.Format("Registro inexistente na base de dados para o id {0}", item.id));
                }
            }
            catch (Exception ex)
            {
                string message;
                if (ex.InnerException != null && ex.InnerException.InnerException != null)
                    message = ex.InnerException.InnerException.Message;
                else if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                throw new InvalidOperationException(message);
            }
        }
    }
}
