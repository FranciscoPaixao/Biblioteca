﻿using Biblioteca.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ConsoleApp.ModuloLivro
{
    public class Livro : EntidadeBase<Livro>
    {
        public string titulo;
        public string isbn;
        public string autor;
        public int numeroPaginas;
        public string editora;
        public int anoPublicacao;

        public Livro(string titulo = "", string isbn = "", string autor = "", int numeroPaginas = 0, string editora = "", int anoPublicacao = 0)
        {
            this.titulo = titulo;
            this.isbn = isbn;
            this.autor = autor;
            this.numeroPaginas = numeroPaginas;
            this.editora = editora;
            this.anoPublicacao = anoPublicacao;
        }

        public override void AtualizarInformacoes(Livro entidade)
        {
            this.titulo = entidade.titulo;
            this.isbn = entidade.isbn;
            this.autor = entidade.autor;
            this.numeroPaginas = entidade.numeroPaginas;
            this.editora = entidade.editora;
            this.anoPublicacao = entidade.anoPublicacao;
        }

        public override string ObterPropiedadeIndividualizadora()
        {
            return this.isbn;
        }

        public override string ToString()
        {
            string msg = $"===== Dados do Livro =====\n";
            msg += $"Id: {this.id}\n";
            msg += $"Título: {this.titulo}\n";
            msg += $"ISBN: {this.isbn}\n";
            msg += $"Autor: {this.autor}\n";
            msg += $"Número de Páginas: {this.numeroPaginas}\n";
            msg += $"Editora: {this.editora}\n";
            msg += $"Ano de Publicação: {this.anoPublicacao}\n";
            return msg;
        }
    }
}