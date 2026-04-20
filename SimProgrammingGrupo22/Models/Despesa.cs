using System;
using System.Collections.Generic;
using System.Text;

namespace SimProgrammingGrupo22.Models
{
    internal class Despesa
    {
        public string Descricao { get; set; } // descricao
        public double Valor { get; set; } // valor
        public CategoriaDespesa Categoria { get; set; } // categoria
        public DateTime Data { get; set; }  // data

        // Construtor para inicializar os atributos da despesa mais facilmente
        // ex: Despesa d = new Despesa("Almoço", 10.5, "Alimentação", DateTime.Now);
        public Despesa(string descricao, double valor, CategoriaDespesa categoria, DateTime data)
        {
            Descricao = descricao;
            Valor = valor;
            Categoria = categoria;
            Data = data;
        }
    }
}
