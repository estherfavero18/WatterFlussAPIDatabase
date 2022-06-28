using APIDatabase.Models;
using APIDatabase.Repository.Interface;
using APIDatabase.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Service.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public List<UsuarioModel> GetAll()
        {
            return _repository.FindAll();
        }
        public UsuarioModel GetById(int id)
        {
            return _repository.FindById(id);
        }
        public UsuarioModel GetByLogin(string email, string senha)
        {
            return _repository.GetByLogin(email, senha);
        }
        public UsuarioModel GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }
        public UsuarioModel GetByCpf(string cpf)
        {
            return _repository.GetByCpf(cpf);
        }
        public UsuarioModel Post(UsuarioModel item)
        {
            return _repository.Create(item);
        }
        public UsuarioModel Put(UsuarioModel item)
        {
            return _repository.Update(item);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
