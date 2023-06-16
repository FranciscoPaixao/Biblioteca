using Biblioteca.ConsoleApp.ModuloLivro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBase<TEntidade> where TEntidade : EntidadeBase<TEntidade>
    {
        protected List<TEntidade> listaRegistros;
        protected int contadorRegistros;
        public RepositorioBase()
        {
            this.listaRegistros = new List<TEntidade>();
            this.contadorRegistros = 0;
        }
        public void Inserir(TEntidade registro)
        {
            registro.id = this.contadorRegistros;
            this.listaRegistros.Add(registro);
            this.contadorRegistros++;
        }
        public void Editar(TEntidade registro) { 
            TEntidade registroAntigo = this.SelecionarPorId(registro.id);
            registroAntigo.AtualizarInformacoes(registro);
        }
        public void Excluir(int id)
        {
            TEntidade registro = this.SelecionarPorId(id);
            this.listaRegistros.Remove(registro);
        }
        public List<TEntidade> SelecionarTodos() => this.listaRegistros;
        public TEntidade SelecionarPorId(int id) => this.listaRegistros.FirstOrDefault(x => x.id == id);
        public TEntidade SelecionarPorDocumentoIdentificador(string documentoIdentificador) => this.listaRegistros.FirstOrDefault(x => x.ObterPropiedadeIndividualizadora() == documentoIdentificador);

        public virtual bool ehDuplicado(TEntidade entidade) {
            int quantidade = listaRegistros.Count(x => x.ObterPropiedadeIndividualizadora() == entidade.ObterPropiedadeIndividualizadora());
            if (quantidade > 1)
            {
                return true;
            }
            return false;
        }
    }
}
