using SimProgrammingGrupo22.Views;
using SimProgrammingGrupo22.Models;

public class DespesaController
{
    private GestorDespesas gestor;
    private ConsoleView view;

    public DespesaController(GestorDespesas gestor, ConsoleView view)
    {
        this.gestor = gestor;
        this.view = view;

        // Subscrição dos eventos da View

        view.AdicionarDespesaSolicitada += OnAdicionarDespesaSolicitada;
        view.DespesaIntroduzida += OnDespesaIntroduzida;
        view.ListagemDespesasSolicitada += OnListagemDespesasSolicitada;
        view.TotalDespesasSolicitado += OnTotalDespesasSolicitado;
        view.SaidaSolicitada += OnSaidaSolicitada;
        view.ListagemPorCategoriaSolicitada += OnListagemPorCategoriaSolicitada;
    }

    public void Iniciar()
    {
        //ciclo na view
        view.Iniciar();
    }

    // Handlers dos eventos

    private void OnAdicionarDespesaSolicitada()
    {
        view.LerNovaDespesa();
    }

    private void OnDespesaIntroduzida(Despesa despesa)
    {
        try
        {
            // O Controller pede ao Model para adicionar; o Model valida e persiste.
            gestor.AdicionarDespesa(despesa);
            view.MostrarMensagem("Despesa adicionada com sucesso!");
        }
        catch (ValidacaoDespesaException ex)
        {
            // Erros de validacao sao apresentados ao utilizador de forma clara.
            view.MostrarMensagem($"Erro de validação: {ex.Message}");
        }
        catch (ErroPersistenciaException ex)
        {
            // Erros de JSON/persistencia sao tratados sem terminar abruptamente a aplicacao.
            view.MostrarMensagem($"Erro ao guardar os dados: {ex.Message}");
        }
        catch (Exception)
        {
            // Proteccao final para erros inesperados.
            view.MostrarMensagem("Ocorreu um erro inesperado ao adicionar a despesa.");
        }
    }

    private void OnListagemDespesasSolicitada()
    {
        try
        {
            // O Controller solicita ao Model a lista de despesas.
            var despesas = gestor.ObterTodasDespesas();
            view.MostrarDespesas(despesas);
        }
        catch (Exception)
        {
            // Caso ocorra erro inesperado, a View informa o utilizador.
            view.MostrarMensagem("Ocorreu um erro ao obter a lista de despesas.");
        }
    }

    private void OnListagemPorCategoriaSolicitada()
    {
        try
        {
            // A View recolhe a categoria e o Controller pede ao Model a filtragem.
            var categoria = view.LerCategoria();
            var despesas = gestor.ObterDespesasPorCategoria(categoria);
            view.MostrarDespesas(despesas);
        }
        catch (Exception)
        {
            // Evita falha abrupta caso ocorra erro durante a listagem por categoria.
            view.MostrarMensagem("Ocorreu um erro ao listar despesas por categoria.");
        }
    }

    private void OnTotalDespesasSolicitado()
    {
        try
        {
            // O Controller pede ao Model o calculo do total.
            var total = gestor.CalcularTotal();
            view.MostrarTotal(total);
        }
        catch (Exception)
        {
            // Mensagem controlada caso o calculo nao possa ser realizado.
            view.MostrarMensagem("Ocorreu um erro ao calcular o total das despesas.");
        }
    }

    private void OnSaidaSolicitada()
    {
        Environment.Exit(0);
    }
}