using Biblioteca.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.ModuloUsuario
{
    public class RepositorioUsuario : RepositorioBase<Usuario>
    {
        public override bool ehDuplicado(Usuario entidade)
        {
            int quantidade = listaRegistros.Count(x => x.ObterPropiedadeIndividualizadora() == entidade.ObterPropiedadeIndividualizadora());
            if (quantidade > 1)
            {
                return true;
            }
            return false;
        }
    }
}
