using Biblioteca.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo : RepositorioBase<Emprestimo>
    {
        public override bool ehDuplicado(Emprestimo entidade)
        {
            int quantidade = listaRegistros.Count(x => x.usuario.id == entidade.usuario.id && x.livro.id == entidade.livro.id);
            if (quantidade > 1)
            {
                return true;
            }
            return false;

        }
    }
}
