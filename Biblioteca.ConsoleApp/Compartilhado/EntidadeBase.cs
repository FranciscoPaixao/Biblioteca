using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase<TEntidade> : ICloneable
    {
        // Template Method: Propriedade compartilhada entre as classes concretas
        public int id { get; set; } 

        // Template Method: Método Abstrato a ser implementando pelas classes concretas  
        // Ele é chamado pelo método Editar do RepositorioBase e deve atualizar as informações da entidade.
        // Um exemplo de implementação está na classe Usuario.cs

        public abstract void AtualizarInformacoes(TEntidade entidade);

        // Template Method: Método compartilhado entre as classes concretas
        // Ele implementa a interface ICloneable e é chamado pelo método Editar do RepositorioBase na verificação de dados únicos duplicados. 
        public object Clone() 
        {
            return this.MemberwiseClone();
        }

        // Template Method: Método Abstrato a ser implementando pelas classes concretas
        // Ele é chamado no RepositorioBase e deve retornar a propriedade única da entidade, por exemplo, o RG do usuário ou o ISBN do livro.
        // Um exemplo de implementação está na classe Usuario.cs

        public abstract string ObterPropriedadeUnica(); 
    }
}
