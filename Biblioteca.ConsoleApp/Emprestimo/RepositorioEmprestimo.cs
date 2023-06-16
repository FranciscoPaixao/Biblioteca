using Biblioteca.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.Emprestimo
{
    public class RepositorioEmprestimo : RepositorioBase<Emprestimo>
    {
        public override bool ehDuplicado(Emprestimo entidade)
        {
            int quantidade = listaRegistros.Count(x => x.idUsuario == entidade.idUsuario && x.listaLivros.Equals(entidade.listaLivros));
            if (quantidade > 1)
            {
                return true;
            }
            return false;

        }
    }
}
