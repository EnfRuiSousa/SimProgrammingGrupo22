using System.Collections.Generic;

namespace SimProgrammingGrupo22.Models
{
    public interface IRepositorioDespesas
    {
        bool HouveErroLeitura { get; }
        List<Despesa> LerDespesas();
        void GuardarDespesas(List<Despesa> despesas);
    }
}