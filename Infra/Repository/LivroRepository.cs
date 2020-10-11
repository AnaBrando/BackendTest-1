using Domain;
using Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
namespace Infra.Repository
{
    public class LivroRepository : ILivroRepository
    {
        public List<Book> Consulta()
        {
            var json = File.ReadAllText(@"../../../../Infra/Mock/books.json", Encoding.GetEncoding("iso-8859-1"));
            var livros = JsonConvert.DeserializeObject<List<Book>>(json);

            return livros;

        }
    }
}
