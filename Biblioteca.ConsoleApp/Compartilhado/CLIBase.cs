using Biblioteca.ConsoleApp.ModuloEmprestimo;
using Biblioteca.ConsoleApp.ModuloLivro;
using Biblioteca.ConsoleApp.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.Compartilhado
{
    public class CLIBase
    {
        protected RepositorioEmprestimo repEmprestimo;
        protected RepositorioLivro repLivro;
        protected RepositorioUsuario repUsuario;


        public void ListarUsuarios(string msg = "")
        {
            if(repUsuario == null)
            {
                Console.WriteLine("Repositório de Usuários não foi inicializado");
                return;
            }

            if (String.IsNullOrEmpty(msg))
            {
                Console.WriteLine("===== Lista de Usuários =====");
                Console.WriteLine("===============================");
            }
            else
            {
                Console.WriteLine(msg);
                Console.WriteLine("===============================");
            }
            foreach (var usuario in repUsuario.SelecionarTodos())
            {
                Console.WriteLine(usuario);
            }
            Console.WriteLine("===============================");
        }
        public void ListarLivros(string msg = "")
        {
            if(repLivro == null)
            {
                Console.WriteLine("Repositório de Livros não foi inicializado");
                return;
            }

            if (String.IsNullOrEmpty(msg))
            {
                Console.WriteLine("===============================");
                Console.WriteLine("===== Lista de Livros =====");
                Console.WriteLine("===============================");
            }
            else
            {
                Console.WriteLine(msg);
                Console.WriteLine("===============================");
            }
            foreach (var livro in repLivro.SelecionarTodos())
            {
                Console.WriteLine(livro);
            }
        }
        public void ListarEmprestimos()
        {
            if(repEmprestimo == null)
            {
                Console.WriteLine("Repositório de Empréstimos não foi inicializado");
                return;
            }
            Console.WriteLine("===============================");
            Console.WriteLine("===== Lista de Empréstimos =====");
            Console.WriteLine("===============================");
            foreach (var emprestimo in repEmprestimo.SelecionarTodos())
            {
                Console.WriteLine(emprestimo);
            }
        }
    }
}
