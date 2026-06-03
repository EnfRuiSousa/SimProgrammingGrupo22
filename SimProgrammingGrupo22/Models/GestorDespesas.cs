using System;
using System.Collections.Generic;
using System.Linq;

namespace SimProgrammingGrupo22.Models
{
    /* FUNÇÃO GestorDespesas */
    public class GestorDespesas
    {
        // Ficheiro JSON onde as despesas são guardadas via abstração
        private readonly IRepositorioDespesas _repo;

        // Lista em memória das despesas (concreta, continua a usar Despesa)
        private readonly List<Despesa> _despesas;

        // Define-se o caminho do ficheiro JSON no construtor
        public GestorDespesas(string repoPath = "Models/repository.json")
        {
            _repo = new JsonRepository(repoPath);

            // Verifica-se se o ficheiro existe através de LerDespesas
            _despesas = _repo.LerDespesas();
        }

        public string AvisoInicial
        {
            get
            {
                if (_repo.HouveErroLeitura)
                {
                    return "Aviso: O ficheiro de dados estava corrompido. Os dados foram reiniciados. Por favor, verifique se precisa de recuperar informações anteriores.";
                }
                return string.Empty;
            }
        }


        /*  FUNÇÃO AdicionarDespesa(despesa) */
        // Este metodo teve que ser colocado como internal pois estava sempre a dar erros de acessibilidade, 
        // mesmo estando na mesma pasta
        internal void AdicionarDespesa(Despesa despesa)
        {
            if (despesa == null) throw new ArgumentNullException(nameof(despesa));

            ValidarDespesa(despesa);

            // 1) Atualiza a lista em memória
            _despesas.Add(despesa);

            // 2) Persiste a lista no ficheiro JSON (pode lançar em caso de I/O)
            _repo.GuardarDespesas(_despesas);
        }

        private void ValidarDespesa(Despesa despesa)
        {
            if (string.IsNullOrWhiteSpace(despesa.Descricao))
            {
                throw new ValidacaoDespesaException("A descrição da despesa não pode ser vazia.");
            }

            if (despesa.Valor <= 0m)
            {
                throw new ValidacaoDespesaException("O valor da despesa deve ser superior a zero.");
            }

            if (despesa.Data == default)
            {
                throw new ValidacaoDespesaException("A data da despesa não é válida.");
            }
        }

        /* FUNÇÃO ObterTodasDespesas */
        // Agora expõe a abstração IDadosDespesa para reduzir acoplamento com a View.
        public List<IDadosDespesa> ObterTodasDespesas()
        {
            // Cada Despesa implementa IDadosDespesa, por isso é seguro fazer cast
            return _despesas.Cast<IDadosDespesa>().ToList();
        }

        /* FUNÇÃO ObterDespesasPorCategoria(categoria) */
        // Tambem retorna IDadosDespesa
        public List<IDadosDespesa> ObterDespesasPorCategoria(CategoriaDespesa categoria)
        {
            return _despesas
                .Where(d => EqualityComparer<CategoriaDespesa>.Default.Equals(d.Categoria, categoria))
                .Cast<IDadosDespesa>()
                .ToList();
        }

        /* FUNÇÃO CalcularTotal() */
        public decimal CalcularTotal()
        {
            return _despesas.Sum(d => d.Valor);
        }

    }
}
