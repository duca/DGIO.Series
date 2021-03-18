using System;
using System.Collections.Generic;
using System.Text;

namespace Series.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { set; get; }
        private string Titulo { set; get; }
        private string Descricao { set; get; }
        private int Ano { set; get; }

        private bool Excluido { set; get; }

        public Serie (int id, Genero gen, string titulo, string desc, int ano)
        {
            this.Genero = gen;
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = desc;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            return $"Gênero: {this.Genero}, " +
                $"Título: {this.Titulo}, " +
                $"Descrição: {this.Descricao}, " +
                $"Ano: {this.Ano} {Environment.NewLine}";
        }

        public int GetId ()
        {
            return this.Id;
        }

        public string GetTitulo ()
        {
            return this.Titulo;
        }

        public void Excluir ()
        {
            this.Excluido = true;
        }

        public bool GetExcluido ()
        {
            return this.Excluido;
        }

        public string GetDescricao ()
        {
            return this.Descricao;
        }

        public int GetAno ()
        {
            return this.Ano;
        }

        public void UpdateTitulo (string newTitulo)
        {
            this.Titulo = newTitulo;
        }

        public void UpdateDesc (string newDesc)
        {
            this.Descricao = newDesc;
        }

        public void UpdateAno (int newAno)
        {
            this.Ano = newAno;
        }

        public void UpdateGenero (Genero newGen)
        {
            this.Genero = newGen;
        }
    }
}
