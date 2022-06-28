using APIDatabase.Models;
using APIDatabase.Repository.Interface;
using APIDatabase.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Service.Implementation
{
    public class ReservatorioService : IReservatorioService
    {
        private readonly IReservatorioRepository _repository;

        public ReservatorioService(IReservatorioRepository repository)
        {
            _repository = repository;
        }
        public List<ReservatorioModel> GetAll()
        {
            return _repository.FindAll();
        }
        public ReservatorioModel GetById(int id)
        {
            return _repository.FindById(id);
        }
        public ReservatorioModel GetByUsuario(string email)
        {
            return _repository.FindByUsuario(email);
        }
        public ReservatorioModel Post(ReservatorioModel item)
        {
            return _repository.Create(item);
        }
        public ReservatorioModel Put(ReservatorioModel item)
        {
            return _repository.Update(item);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}