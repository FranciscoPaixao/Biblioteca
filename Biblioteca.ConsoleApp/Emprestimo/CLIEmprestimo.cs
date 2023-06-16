using Biblioteca.ConsoleApp.Compartilhado;
using Biblioteca.ConsoleApp.ModuloLivro;
using Biblioteca.ConsoleApp.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.Emprestimo
{
    public class CLIEmprestimo
    {
        RepositorioBase<Emprestimo> repositorioEmprestimo;

        RepositorioBase<Usuario> repositorioUsuario;

        RepositorioBase<Livro> repositorioLivro;

        public CLIEmprestimo(RepositorioBase<Emprestimo> repositorioEmprestimo, RepositorioBase<Usuario> repositorioUsuario, RepositorioBase<Livro> repositorioLivro)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioUsuario = repositorioUsuario;
            this.repositorioLivro = repositorioLivro;
        }
        public void MenuEmprestimo(bool statusOpcao = false)
        {
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu do emprestimo");
            if (statusOpcao)
            {
                Console.Clear();
                Console.WriteLine("Opção inválida");
                statusOpcao = false;
                Console.ReadKey();
            }
            else
            {
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("============================");
            Console.WriteLine("===== Menu Emprestimo =====");
            Console.WriteLine("============================");
            Console.WriteLine("1 - Cadastrar Emprestimo");
            Console.WriteLine("3 - Listar Emprestimos");
            Console.WriteLine("4 - Voltar");
            Console.WriteLine("===========================");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    CadastrarEmprestimo();
                    break;
                case 2:
                    ListarEmprestimos();
                    break;
                case 3:
                    return;
                    break;
                default:
                    statusOpcao = true;
                    break;
            }
            MenuEmprestimo(statusOpcao);
        }
        public void CadastrarEmprestimo() { 
            
        }
        public void ListarEmprestimos()
        {
            Console.WriteLine("Lista de Emprestimos");
            Console.WriteLine("====================");
            foreach (var item in repositorioEmprestimo.SelecionarTodos())
            {
                Console.WriteLine(item);
            }

        }
    }
}
