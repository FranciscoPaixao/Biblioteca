using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase<TEntidade>
    {
        public int id { get; set; }

        public abstract void AtualizarInformacoes(TEntidade entidade);
        public abstract string ObterPropiedadeIndividualizadora();
    }
}
