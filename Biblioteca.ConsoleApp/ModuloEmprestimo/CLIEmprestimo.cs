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
    public class CLIEmprestimo : CLIBase
    {

        public CLIEmprestimo(RepositorioBase<Emprestimo> repEmprestimo, RepositorioBase<Usuario> repUsuario, RepositorioBase<Livro> repLivro)
        {
            this.repEmprestimo = repEmprestimo;
            this.repUsuario = repUsuario;
            this.repLivro = repLivro;
        }
        public void MenuEmprestimo(bool statusOpcao = false)
        {

            if (statusOpcao)
            {
                Console.Clear();
                Console.WriteLine("Opção inválida");
                statusOpcao = false;
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
            }
            Console.WriteLine("============================");
            Console.WriteLine("===== Menu Empréstimo  =====");
            Console.WriteLine("============================");
            Console.WriteLine("1 - Cadastrar Empréstimo");
            Console.WriteLine("2 - Listar Empréstimos");
            Console.WriteLine("3 - Voltar");
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
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu do empréstimo");
            Console.ReadKey();
            MenuEmprestimo(statusOpcao);
        }
        public void CadastrarEmprestimo()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("=== Cadastro de Empréstimo ===");
            Console.WriteLine("===============================");
            Usuario usuario;
            while (true)
            {
                Console.WriteLine("Digite o RG do usuario:");
                string RG = Console.ReadLine();
                usuario = repUsuario.SelecionarPorPropiedadeUnica(RG);
                if (usuario == null)
                {
                    Console.WriteLine("Usuario não encontrado!");
                    continue;
                }
                break;

            }
            Livro livro;
            while (true)
            {
                Console.WriteLine("Digite o ISBN do livro:");
                string isbn = Console.ReadLine();
                livro = repLivro.SelecionarPorPropiedadeUnica(isbn);
                if (livro == null)
                {
                    Console.WriteLine("Livro não encontrado!");
                    continue;
                }
                break;
            }
            Emprestimo emprestimo = new Emprestimo(usuario, livro);
            repEmprestimo.Inserir(emprestimo);
            Console.WriteLine("Empréstimo cadastrado com sucesso!");
            Console.WriteLine(emprestimo);

        }
    }
}
