using System;

namespace SimProgrammingGrupo22.Models
{
    public class Despesa : IDadosDespesa
    {
        public required string Descricao { get; set; }
        public required decimal Valor { get; set; }
        public required CategoriaDespesa Categoria { get; set; }
        public required DateTime Data { get; set; }
    }
}