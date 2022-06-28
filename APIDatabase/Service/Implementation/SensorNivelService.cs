using APIDatabase.Models;
using APIDatabase.Repository.Interface;
using APIDatabase.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Service.Implementation
{
    public class SensorNivelService : ISensorNivelService
    {
        private readonly ISensorNivelRepository _repository;

        public SensorNivelService(ISensorNivelRepository repository)
        {
            _repository = repository;
        }

        public List<SensorNivelModel> GetAll()
        {
            return _repository.FindAll();
        }
        public List<SensorNivelModel> GetByRepositorio(int idRepositorio)
        {
            return _repository.FindByRepositorio(idRepositorio);
        }
        public SensorNivelModel GetByRepositorioUltimaMedicao(int idRepositorio)
        {
            return _repository.FindByRepositorio(idRepositorio).LastOrDefault();
        }
        public SensorNivelModel GetById(int id)
        {
            return _repository.FindById(id);
        }
        public SensorNivelModel Post(SensorNivelModel item)
        {
            return _repository.Create(item);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
