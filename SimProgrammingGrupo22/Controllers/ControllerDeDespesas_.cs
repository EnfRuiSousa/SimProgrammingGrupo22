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
        gestor.AdicionarDespesa(despesa);
        view.MostrarMensagem("Despesa adicionada com sucesso!");
    }

    private void OnListagemDespesasSolicitada()
    {
        var despesas = gestor.ObterTodasDespesas();
        view.MostrarDespesas(despesas);
    }

    private void OnTotalDespesasSolicitado()
    {
        var total = gestor.CalcularTotal();
        view.MostrarTotal(total);
    }

    private void OnSaidaSolicitada()
    {
        Environment.Exit(0);
    }
}