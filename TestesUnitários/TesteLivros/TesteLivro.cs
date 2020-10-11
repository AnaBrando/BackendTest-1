using Domain;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Moq;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestesUnitários
{
    public class TesteLivro
    {

        private readonly ILivroService _service;
        private readonly Mock<ILivroRepository> _livroMock = new Mock<ILivroRepository>();

        public TesteLivro()
        {
            _service = new LivroService(_livroMock.Object);
        }

        private List<Book> MockListaLivro()
        {
            var json = File.ReadAllText(@"../../../Mock/books.json", Encoding.GetEncoding("iso-8859-1"));
            var livros = JsonConvert.DeserializeObject<List<Book>>(json);

            return livros;
        }
        [Theory]
        [InlineData("Jules Verne", 2)]
        [InlineData("J. K. Rowling", 2)]
        [InlineData("J. R. R. Tolkien", 1)]
        
        public void BuscarPorAutor(string nome, int quantidade)
        {
            //arange
            var livros = _livroMock.Setup(x=>x.Consulta()).Returns(MockListaLivro());

            //action
            var result = _service.BuscarLivros().Where(x => x.Specifications.Author == nome);

            //assert
            Assert.Equal(quantidade, result.Count());
            
            
        }
        [Theory]
        [InlineData("Journey to the Center of the Earth", 1)]
        [InlineData("20,000 Leagues Under the Sea", 1)]
        [InlineData("Harry Potter and the Goblet of Fire", 1)]
        [InlineData("Fantastic Beasts and Where to Find Them: The Original Screenplay", 1)]
        [InlineData("The Lord of the Rings", 1)]
       
        public void BuscarLivroPorNome(string nome, int quantidade)
        {
            //arange
            var livros = _livroMock.Setup(x => x.Consulta()).Returns(MockListaLivro());

            //action
            var result = _service.BuscarLivros().Where(x => x.Name == nome);

            //assert
            Assert.Equal(quantidade, result.Count());


        }
        [Fact]
       
        public void OrdenarPrecoDesc(/*int id, double preco*/)
        {

            //arange
            _livroMock.Setup(x => x.Consulta()).Returns(MockListaLivro());
           
            //action
            var result = _service.OrdenarPrecoDesc();
            var livros = _livroMock.Object.Consulta().OrderByDescending(x=>x.Price).ToList();
            //assert
            Assert.Equal(livros,result);


        }
        [Fact]
        public void OrdenarPrecoAsc()
        {

            //arange
            _livroMock.Setup(x => x.Consulta()).Returns(MockListaLivro());

            //action
            var result = _service.OrdenarPrecoAsc();
            var livros = _livroMock.Object.Consulta().OrderBy(x => x.Price).ToList();
            //assert
            Assert.Equal(livros, result);


        }
        [Theory]
        [InlineData(1, 10.00)]
        [InlineData(2, 10.10)]
        [InlineData(3, 7.31)]
        [InlineData(4, 11.15)]
        [InlineData(5, 6.15)]
        public void frete(int id, double price)
        {
            //arange
            _livroMock.Setup(x => x.Consulta()).Returns(MockListaLivro());

            var valor = price + ((price * 20)/100);

            var preco = _service.frete(id);

            Assert.Equal(valor, preco);
        }
    }
}
