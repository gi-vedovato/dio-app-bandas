using DIO.Musicas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIO.Musicas
{
    public class Banda : EntidadeBase
    {
        // Atributos
        private Genero Genero { get; set; }
        private string Nome { get; set; }
        private bool Excluido { get; set; }

        private List<Integrante> Integrantes { get; set; }

        // Métodos
        public Banda(int id, Genero genero, string nome,  List<Integrante> atores)
        {
            this.Id = id;
            this.Genero = genero;
            this.Nome = nome;
            
            this.Integrantes = atores;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Gênero Musical: " + this.Genero + Environment.NewLine;
            retorno += "Nome: " + this.Nome+ Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;

            if (Integrantes.Any())
            {
                retorno += "Integrantes:" + Environment.NewLine;

                foreach (var ator in Integrantes)
                {
                    retorno += "     " + ator.NomeIntegrante + Environment.NewLine;
                }
            }

            return retorno;
        }

        public string RetornaNome()
        {
            return this.Nome;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}