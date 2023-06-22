using Biblioteca.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.ModuloLivro
{
    public class RepositorioLivro : RepositorioBase<Livro>
    {
        public override bool ehDuplicado(Livro entidade)
        {
            int quantidade = listaRegistros.Count(x => x.ObterPropiedadeIndividualizadora() == entidade.ObterPropiedadeIndividualizadora());
            if (quantidade > 1)
            {
                return true;
            }
            return false;
        }
        public Livro SelecionarPorISBN(String isbn) => listaRegistros.FirstOrDefault(x => x.isbn == isbn);

    }
}
