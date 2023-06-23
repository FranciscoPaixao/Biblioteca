using Biblioteca.ConsoleApp.Compartilhado;
using Biblioteca.ConsoleApp.ModuloLivro;
using Biblioteca.ConsoleApp.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo : EntidadeBase<Emprestimo>
    {
        public Usuario usuario;

        public Livro livro;

        public DateTime dataEmprestimo;

        public DateTime dataDevolucao;

        public Emprestimo(Usuario usuario, Livro livro)
        {
            this.usuario = usuario;
            this.livro = livro;
            dataEmprestimo = DateTime.Now;
            dataDevolucao = DateTime.Now.AddDays(7);
        }

        public override void AtualizarInformacoes(Emprestimo entidade)
        {

        }

        public override string ObterPropriedadeUnica()
        {
            return usuario.id.ToString() + livro.id.ToString();
        }

        public override string ToString()
        {
            string msg = "";
            msg += "===== Dados do Empréstimo =====\n";
            msg += $"Id do Empréstimo: {id}\n";
            msg += $"Nome do Usuário: {usuario.nome}\n";
            msg += $"Email do Usuário: {usuario.email}\n";
            msg += $"Data do Empréstimo: {dataEmprestimo}\n";
            msg += $"Data da Devolução: {dataDevolucao}\n";
            msg += $"Livro Emprestado: \n";
            msg += $"   ISBN: {livro.isbn}\n";
            msg += $"   Título: {livro.titulo}\n";
            msg += "=============================\n";
            return msg;
        }
    }
}
