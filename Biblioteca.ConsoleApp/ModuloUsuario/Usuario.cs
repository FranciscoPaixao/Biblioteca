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

        public Usuario(string nome = "", string email = "", string telefone = "", string numeroRG = "", string endereco = "")
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.numeroRG = numeroRG;
            this.endereco = endereco;
        }

        public override void AtualizarInformacoes(Usuario entidade)
        {
            if(!String.IsNullOrEmpty(entidade.nome))
            {
                this.nome = entidade.nome;
            }
            if (!String.IsNullOrEmpty(entidade.email))
            {
                this.email = entidade.email;
            }
            if (!String.IsNullOrEmpty(entidade.telefone))
            {
                this.telefone = entidade.telefone;
            }
            if (!String.IsNullOrEmpty(entidade.numeroRG))
            {
                this.numeroRG = entidade.numeroRG;
            }
            if (!String.IsNullOrEmpty(entidade.endereco))
            {
                this.endereco = entidade.endereco;
            }
        }

        public override string ObterPropiedadeUnica() => numeroRG;

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
