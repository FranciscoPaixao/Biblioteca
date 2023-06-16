using Biblioteca.ConsoleApp.Compartilhado;
using Biblioteca.ConsoleApp.ModuloLivro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.Emprestimo
{
    public class Emprestimo : EntidadeBase<Emprestimo>
    {
        public int idUsuario;

        public List<Livro> listaLivros;

        public DateTime dataEmprestimo;

        public override void AtualizarInformacoes(Emprestimo entidade) { 
            
        }

        public override string ObterPropiedadeIndividualizadora() => this.id.ToString();
        public override string ToString()
        {
            string msg = $"===== Dados do Emprestimo =====\n";
            msg += $"Id: {this.id}\n";
            msg += $"Id do Usuário: {this.idUsuario}\n";
            msg += $"Data do Emprestimo: {this.dataEmprestimo}\n";
            msg += $"Livros Emprestados: \n";
            foreach (var item in listaLivros)
            {
                msg += $"Id: {item.id}\n";
                msg += $"Título: {item.titulo}\n";
                msg += "=============================\n";
        }
            return msg;
        }
    }
}
