using Biblioteca.ConsoleApp.Compartilhado;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.ModuloLivro
{
    public class CLILivro
    {
        private RepositorioBase<Livro> repLivro;
        public CLILivro(RepositorioBase<Livro> repLivro)
        {
            this.repLivro = repLivro;
        }
        public void MenuLivro(bool statusOpcao = false)
        {
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu do livro");
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
            Console.WriteLine("===== Menu do Livro =====");
            Console.WriteLine("============================");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar Livro");
            Console.WriteLine("2 - Editar Livro");
            Console.WriteLine("3 - Excluir Livro");
            Console.WriteLine("4 - Listar Livros");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine("============================");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    this.CadastrarLivro();
                    break;
                case 2:
                    this.EditarLivro();
                    break;
                case 3:
                    this.ExcluirLivro();
                    break;
                case 4:
                    this.ListarLivros();
                    break;
                case 5:
                    return;
                    break;
                default:
                    statusOpcao = true;
                    break;
            }
            MenuLivro(statusOpcao);
        }
        public void CadastrarLivro() { 
            Livro novoLivro = new Livro();

            Console.WriteLine("===============================");
            Console.WriteLine("===== Cadastro de Livro =====");
            Console.WriteLine("===============================");

            Console.Write("Digite o título do livro: ");
            novoLivro.titulo = Console.ReadLine();

            Console.Write("Digite o autor do livro: ");
            novoLivro.autor = Console.ReadLine();

            Console.Write("Digite o ano de publicação do livro: ");
            novoLivro.anoPublicacao = int.Parse(Console.ReadLine());

            Console.Write("Digite a editora do livro: ");
            novoLivro.editora = Console.ReadLine();

            Console.Write("Digite o número de páginas do livro: ");
            novoLivro.numeroPaginas = int.Parse(Console.ReadLine());

            repLivro.Inserir(novoLivro);
            Console.WriteLine("===============================");
            Console.WriteLine("Livro cadastrado com sucesso!");
            Console.WriteLine("===============================");
        }
        public void EditarLivro()
        {
            Console.WriteLine("===== Edição de Livro =====");
            Console.WriteLine("===============================");
            ListarLivros("Livros disponíveis para edição:");
            Console.Write("Digite o ID do livro que deseja editar: ");
            int id = int.Parse(Console.ReadLine());
            Livro livro = repLivro.SelecionarPorId(id);
            if (livro == null)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Livro não encontrado");
                Console.WriteLine("===============================");
                return;
            }
            Console.WriteLine("Livro encontrado:");
            Console.WriteLine("===============================");

            Console.Write("Digite o título do livro: ");
            livro.titulo = Console.ReadLine();

            Console.Write("Digite o autor do livro: ");
            livro.autor = Console.ReadLine();

            Console.Write("Digite o ano de publicação do livro: ");
            livro.anoPublicacao = int.Parse(Console.ReadLine());

            Console.Write("Digite a editora do livro: ");
            livro.editora = Console.ReadLine();

            Console.Write("Digite o número de páginas do livro: ");
            livro.numeroPaginas = int.Parse(Console.ReadLine());

            repLivro.Editar(livro);

            Console.WriteLine("===============================");
            Console.WriteLine("Livro editado com sucesso!");
            Console.WriteLine("===============================");
        }
        public void ExcluirLivro()
        {

        }
        public void ListarLivros(string msg = "")
        {
            if(String.IsNullOrEmpty(msg))
            {
                Console.WriteLine("===== Lista de Livros =====");
                Console.WriteLine("===============================");
            }
            else
            {
                Console.WriteLine(msg);
                Console.WriteLine("===============================");
            }
            foreach (Livro livro in repLivro.SelecionarTodos())
            {
                Console.WriteLine(livro);
            }
        }

    }
}
