using Biblioteca.ConsoleApp.ModuloLivro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.Compartilhado
{
    public class RepositorioBase<TEntidade> where TEntidade : EntidadeBase<TEntidade>
    {
        protected List<TEntidade> listaRegistros;
        protected int contadorRegistros;
        public RepositorioBase()
        {
            this.listaRegistros = new();
            this.contadorRegistros = 0;
        }
        public bool Inserir(TEntidade registro)
        {
            if (ehDuplicado(registro) > 0)
            {
                return false;
            }
            registro.id = this.contadorRegistros;

            this.listaRegistros.Add(registro);

            this.contadorRegistros++;

            return true;
        }
        public bool Editar(TEntidade registro) { 

            TEntidade registroAntigo = this.SelecionarPorId(registro.id);

            TEntidade tempRegistroAntigo = (TEntidade)registroAntigo.Clone();

            registroAntigo.AtualizarInformacoes(registro);

            int quantidadeIgual = ehDuplicado(registro);

            if(quantidadeIgual > 1)
            {
                registroAntigo.AtualizarInformacoes(tempRegistroAntigo);
                return false;
            }
            return true;
        }
        public bool Excluir(int id)
        {
            TEntidade registro = SelecionarPorId(id);
            return listaRegistros.Remove(registro);
        }
        public List<TEntidade> SelecionarTodos() => listaRegistros;
        public TEntidade SelecionarPorId(int id) => listaRegistros.FirstOrDefault(x => x.id == id);
        public TEntidade SelecionarPorPropiedadeUnica(string propiedadeUnica) => listaRegistros.FirstOrDefault(x => x.ObterPropiedadeUnica() == propiedadeUnica);

        public virtual int ehDuplicado(TEntidade entidade)
        {
            return listaRegistros.Count(x => x.ObterPropiedadeUnica() == entidade.ObterPropiedadeUnica());
        }
    }
}
