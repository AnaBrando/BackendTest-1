using Domain;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repo;

        public LivroService(ILivroRepository repo)
        {
            _repo = repo;
        }
        public List<Book> BuscarLivros()
        {
            var livros = _repo.Consulta();
            return livros;
        }

        public double frete(int id)
        {
            var precoLivro = _repo.Consulta().Where(x => x.Id == id).FirstOrDefault().Price;

            return precoLivro + ((precoLivro * 20)/100);
        }

        public List<Book> OrdenarPrecoAsc()
        {
            return _repo.Consulta().OrderBy(x => x.Price).ToList();
        }

        public List<Book> OrdenarPrecoDesc()
        {
            var livros = _repo.Consulta();
            var y = livros.OrderByDescending(x=>x.Price).ToList();
            return y;
        }
    }
}
