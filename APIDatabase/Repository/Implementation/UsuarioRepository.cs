using APIDatabase.Models;
using APIDatabase.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using APIDatabase.Repository.Interface;
using System.Threading.Tasks;
using APIDatabase.Models.Context;

namespace APIDatabase.Repository.Implementation
{
    public class UsuarioRepository : 
        GenericRepository<UsuarioModel>,
        IUsuarioRepository
    {
        public UsuarioRepository(SqlServerContext context) : base(context) { }

        public UsuarioModel GetByLogin(string email, string senha)
        {
            return _context.usuario
                    .Where(u => u.email == email && u.senha == senha)
                    .FirstOrDefault();
        }
        public UsuarioModel GetByEmail(string email)
        {
            return _context.usuario
                    .Where(u => u.email == email)
                    .FirstOrDefault();
        }
        public UsuarioModel GetByCpf(string cpf)
        {
            return _context.usuario
                    .Where(u => u.cpf == cpf)
                    .FirstOrDefault();
        }
    }
}
