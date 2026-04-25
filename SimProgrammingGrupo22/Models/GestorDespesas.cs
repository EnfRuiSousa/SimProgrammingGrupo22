using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimProgrammingGrupo22.Models
{
    /* FUNÇÃO GestorDespesas */
    public class GestorDespesas
    {
        // Ficheiro JSON onde as despesas são guardadas
        private readonly JsonRepository _repo;

        // Lista em memória das despesas
        private readonly List<Despesa> _despesas;

        // Define-se o caminho do ficheiro JSON no construtor
        public GestorDespesas(string repoPath = "Models/repository.json")
        {
            _repo = new JsonRepository(repoPath);

            // Verifica-se se o ficheiro existe através de LerDespesas
            _despesas = _repo.LerDespesas();
        }

        /*  FUNÇÃO AdicionarDespesa(despesa) */
        public void AdicionarDespesa(Despesa despesa)
        {
            if (despesa == null) throw new ArgumentNullException(nameof(despesa));

            // 1) Atualiza a lista em memória
            _despesas.Add(despesa);

            // 2) Persiste a lista no ficheiro JSON (pode lançar em caso de I/O)
            _repo.GuardarDespesas(_despesas);
        }

        /* FUNÇÃO ObterTodasDespesas */
        public List<Despesa> ObterTodasDespesas()
        {
            return new List<Despesa>(_despesas);
        }

        /* FUNÇÃO ObterDespesasPorCategoria(categoria) */
        public List<Despesa> ObterDespesasPorCategoria(CategoriaDespesa categoria)
        {
            return _despesas
                .Where(d => EqualityComparer<CategoriaDespesa>.Default.Equals(d.Categoria, categoria))
                .ToList();
        }

        /* FUNÇÃO CalcularTotal() */
        public decimal CalcularTotal()
        {
            return _despesas.Sum(d => Convert.ToDecimal(d.Valor));
        }

    }
}
