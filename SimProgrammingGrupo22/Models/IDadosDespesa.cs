using System;

namespace SimProgrammingGrupo22.Models
{
    // Interface IDadosDespesa
    public interface IDadosDespesa
    {
        string Descricao { get; }
        decimal Valor { get; }
        CategoriaDespesa Categoria { get; }
        DateTime Data { get; }
    }
}