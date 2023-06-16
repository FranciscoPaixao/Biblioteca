using Biblioteca.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.ModuloUsuario
{
    public class CLIUsuario
    {
        private RepositorioBase<Usuario> repUsuario;
        public CLIUsuario(RepositorioBase<Usuario> repUsuario)
        {
            this.repUsuario = repUsuario;
        }
        public void MenuUsuario(bool statusOpcao = false)
        {
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu do usuário");
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
            Console.WriteLine("===== Menu do Usuário =====");
            Console.WriteLine("============================");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Editar Usuário");
            Console.WriteLine("3 - Excluir Usuário");
            Console.WriteLine("4 - Listar Usuários");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine("============================");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    this.CadastrarUsuario();
                    break;
                case 2:
                    this.EditarUsuario();
                    break;
                case 3:
                    this.ExcluirUsuario();
                    break;
                case 4:
                    this.ListarUsuarios();
                    break;
                case 5:
                    return;
                    break;
                default:
                    statusOpcao = true;
                    break;
            }
            MenuUsuario(statusOpcao);
        }
        public void CadastrarUsuario()
        {
            Usuario novoUsuario = new Usuario();
            Console.WriteLine("===== Cadastro de Usuário =====");
            Console.WriteLine("===============================");
            Console.Write("Digite o nome do usuário: ");
            novoUsuario.nome = Console.ReadLine();

            Console.Write("Digite o e-mail do usuário: ");
            novoUsuario.email = Console.ReadLine();

            Console.Write("Digite o telefone do usuário: ");
            novoUsuario.telefone = Console.ReadLine();

            Console.Write("Digite o RG do usuário: ");
            novoUsuario.numeroRG = Console.ReadLine();

            Console.Write("Digite o endereço do usuário: ");
            novoUsuario.endereco = Console.ReadLine();

            repUsuario.Inserir(novoUsuario);

            Console.WriteLine("===============================");
            Console.WriteLine("Usuário cadastrado com sucesso!");
            Console.WriteLine("===============================");
        }
        public void EditarUsuario()
        {
            Console.WriteLine("===== Edição de Usuário =====");
            Console.WriteLine("=============================");
            ListarUsuarios("Usuários disponíveis para edição:");
            Console.Write("Digite o ID do usuário que deseja editar: ");
            int id = int.Parse(Console.ReadLine());
            Usuario usuario = repUsuario.SelecionarPorId(id);
            if (usuario == null)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Usuário não encontrado!");
                Console.WriteLine("===============================");
                return;
            }
            Console.WriteLine("Usuário encontrado!");

            Console.Write("Digite o nome do usuário: ");
            usuario.nome = Console.ReadLine();

            Console.Write("Digite o e-mail do usuário: ");
            usuario.email = Console.ReadLine();

            Console.Write("Digite o telefone do usuário: ");
            usuario.telefone = Console.ReadLine();

            Console.Write("Digite o RG do usuário: ");
            usuario.numeroRG = Console.ReadLine();

            Console.Write("Digite o endereço do usuário: ");
            usuario.endereco = Console.ReadLine();

            repUsuario.Editar(usuario);

            Console.WriteLine("===============================");
            Console.WriteLine("Usuário editado com sucesso!");
            Console.WriteLine("===============================");
        }

        public void ExcluirUsuario()
        {
            Console.WriteLine("===== Exclusão de Usuário =====");
            Console.WriteLine("===============================");
            ListarUsuarios("Usuários disponíveis para exclusão:");
            Console.Write("Digite o ID do usuário que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());
            Usuario usuario = repUsuario.SelecionarPorId(id);
            if (usuario == null)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Usuário não encontrado!");
                Console.WriteLine("===============================");
                return;
            }

            Console.WriteLine("Usuário encontrado!");
            
            repUsuario.Excluir(usuario.id);
            
            Console.WriteLine("===============================");
            Console.WriteLine("Usuário excluído com sucesso!");
            Console.WriteLine("===============================");
        }
        public void ListarUsuarios(string msg = "")
        {
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
            foreach (Usuario usuario in repUsuario.SelecionarTodos())
            {
                Console.WriteLine(usuario);
            }
            Console.WriteLine("===============================");
        }
    }
}