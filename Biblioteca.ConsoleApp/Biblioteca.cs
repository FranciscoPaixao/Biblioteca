using Biblioteca.ConsoleApp.Compartilhado;
using Biblioteca.ConsoleApp.ModuloEmprestimo;
using Biblioteca.ConsoleApp.ModuloLivro;
using Biblioteca.ConsoleApp.ModuloUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp
{
    public class Biblioteca
    {
        RepositorioBase<Emprestimo> repositorioEmprestimo;
        RepositorioBase<Livro> repositorioLivro;
        RepositorioBase<Usuario> repositorioUsuario;

        CLIEmprestimo cliEmprestimo;
        CLILivro cliLivro;
        CLIUsuario cliUsuario;
        public Biblioteca()
        {
            repositorioEmprestimo = new();
            repositorioLivro = new();
            repositorioUsuario = new();

            cliLivro = new(repositorioLivro);
            cliUsuario = new(repositorioUsuario);
            cliEmprestimo = new(repositorioEmprestimo, repositorioUsuario, repositorioLivro);

            // Inserção de dados para testes
            /*
            repositorioUsuario.Inserir(new Usuario(nome: "Fulano", email: "fulano@gmail.com", telefone: "5685689567", numeroRG: "456453456", endereco: "Rua 1"));
            repositorioUsuario.Inserir(new Usuario(nome: "Ciclano", email: "ciclano@gmail.com", telefone: "658568568", numeroRG: "45756756", endereco: "Rua 2"));

            repositorioLivro.Inserir(new Livro(titulo: "Livro 1", isbn: "6796796796", autor: "Autor 1",numeroPaginas: 100, editora: "Editora 1", anoPublicacao: 2021));
            repositorioLivro.Inserir(new Livro(titulo: "Livro 2", isbn: "5685685685", autor: "Autor 2", numeroPaginas: 200, editora: "Editora 2", anoPublicacao: 2021));

            repositorioEmprestimo.Inserir(new Emprestimo(repositorioUsuario.SelecionarPorId(0), repositorioLivro.SelecionarPorId(0 )));
            repositorioEmprestimo.Inserir(new Emprestimo(repositorioUsuario.SelecionarPorId(1), repositorioLivro.SelecionarPorId(1)));
            */
        }
        public void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Menu Principal");
            Console.WriteLine("Opções disponíveis: ");
            Console.WriteLine("1 - Menu Livro");
            Console.WriteLine("2 - Menu Usuário");
            Console.WriteLine("3 - Menu Empréstimo");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("Digite a opção desejada: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    cliLivro.MenuLivro();
                    break;
                case 2:
                    cliUsuario.MenuUsuario();
                    break;
                case 3:
                    cliEmprestimo.MenuEmprestimo();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuPrincipal();
        }
    }
}
