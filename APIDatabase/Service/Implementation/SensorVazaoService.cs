using APIDatabase.Models;
using APIDatabase.Repository.Interface;
using APIDatabase.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Service.Implementation
{
    public class SensorVazaoService : ISensorVazaoService
    {
        private readonly ISensorVazaoRepository _repository;

        public SensorVazaoService(ISensorVazaoRepository repository)
        {
            _repository = repository;
        }

        public List<SensorVazaoModel> GetAll()
        {
            return _repository.FindAll();
        }
        public List<SensorVazaoModel> GetByRepositorio(int idRepositorio)
        {
            return _repository.FindByRepositorio(idRepositorio);
        }
        public SensorVazaoModel GetByRepositorioUltimaMedicao(int idRepositorio)
        {
            return _repository.FindByRepositorio(idRepositorio).LastOrDefault();
        }
        public SensorVazaoModel GetById(int id)
        {
            return _repository.FindById(id);
        }
        public SensorVazaoModel Post(SensorVazaoModel item)
        {
            return _repository.Create(item);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
