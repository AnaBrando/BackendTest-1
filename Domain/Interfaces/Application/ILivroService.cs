using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Application
{
    public interface ILivroService
    {
        List<Book> BuscarLivros();

        double frete(int id);
        List<Book> OrdenarPrecoDesc();

        List<Book> OrdenarPrecoAsc();
    }
}
