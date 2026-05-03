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

        public string? AvisoInicial { get; private set; }

        // Define-se o caminho do ficheiro JSON no construtor
        public GestorDespesas(string repoPath = "Models/repository.json")
        {
            _repo = new JsonRepository(repoPath);

            try
            {
                // Tenta carregar as despesas guardadas no ficheiro JSON.
                _despesas = _repo.LerDespesas();
            }
            catch (ErroPersistenciaException ex)
            {
                // Se o ficheiro JSON estiver corrompido, a aplicação arranca com lista vazia.
                _despesas = new List<Despesa>();
                AvisoInicial = ex.Message + " A aplicação será iniciada sem despesas carregadas.";
            }
        }

        /*  FUNÇÃO AdicionarDespesa(despesa) */
        public void AdicionarDespesa(Despesa despesa)
        {
            if (despesa == null)
                throw new ArgumentNullException(nameof(despesa));

            // Validacao de regra de negocio: uma despesa deve ter descricao.
            if (string.IsNullOrWhiteSpace(despesa.Descricao))
                throw new ValidacaoDespesaException("A descrição da despesa não pode estar vazia.");

            // Validacao de regra de negocio: uma despesa deve ter valor superior a zero.
            if (despesa.Valor <= 0)
                throw new ValidacaoDespesaException("O valor da despesa tem de ser superior a zero.");

            // Se a despesa for valida, e adicionada primeiro em memoria.
            _despesas.Add(despesa);

            // Depois e persistida no ficheiro JSON.
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