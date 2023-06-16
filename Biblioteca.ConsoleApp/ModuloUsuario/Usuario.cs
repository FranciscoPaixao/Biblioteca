using Biblioteca.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.ModuloUsuario
{
    public class Usuario : EntidadeBase<Usuario>
    {
        public string nome;

        public string email;
        
        public string telefone;
        
        public string numeroRG;
        
        public string endereco;

        public override void AtualizarInformacoes(Usuario entidade)
        {
            this.nome = entidade.nome;
            this.email = entidade.email;
            this.telefone = entidade.telefone;
            this.numeroRG = entidade.numeroRG;
            this.endereco = entidade.endereco;    
        }

        public override string ObterPropiedadeIndividualizadora()
        {
            return this.numeroRG;
        }

        public override string ToString()
        {
            string msg = "";
            msg += "===== Dados do Usuário =====" + Environment.NewLine;
            msg += "Id: " + this.id + Environment.NewLine;
            msg += "Nome: " + this.nome + Environment.NewLine;
            msg += "Email: " + this.email + Environment.NewLine;
            msg += "Telefone: " + this.telefone + Environment.NewLine;
            msg += "RG: " + this.numeroRG + Environment.NewLine;
            msg += "Endereço: " + this.endereco + Environment.NewLine;
            return msg;
        }
    }
}
