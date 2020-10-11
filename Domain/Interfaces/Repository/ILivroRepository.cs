using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repository
{
    public interface ILivroRepository
    {
        List<Book> Consulta();
    }
}
