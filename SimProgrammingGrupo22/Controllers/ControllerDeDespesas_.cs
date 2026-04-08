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
    }

    public static void Main()
    {
        var gestor = new GestorDespesas();
        var view = new ConsoleView();
        var controller = new DespesaController(gestor, view);
        controller.Iniciar();
    }

    public void Iniciar()
    {
        bool sair = false;
        while (!sair)
        {
            // inserir quando tiver a view 
            view.MostrarMenu();
            int opcao = view.LerOpcao();
            switch (opcao)
            {
                case 0:
                    sair = true;
                    break;
                case 1:
                    AdicionarDespesa();
                    break;
                case 2:
                    ListarDespesas();
                    break;
                case 3:
                    ListarDespesasPorCategoria();
                    break;
                case 4:
                    MostrarTotal();
                    break;
                default:
                    view.mostrarMensagem("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    public void AdicionarDespesa()
    {
        // var despesa = view.LerNovaDespesa(); 
        //Inserir quando tiver o model 
        //gestor.AdicionarDespesa(despesa);
        //Inserir quando tiver a view 
        //view.MostrarMensagem("Despesa adicionada com sucesso!");
    }

    public void ListarDespesas()
    {
        //Inserir quando tiver o Model 
        //var despesas = gestor.listarDespesas(); 
        //Inserir quando tiver a view 
        //view.MostrarDespesas(despesas);

    }
    public void ListarDespesasPorCategoria()
    {
        // Inserir quando tiver a view 
        //var categoria = view.LerCategoria();
        //Inserir quando tiver o Model 
        //var despesas = gestor.listarDespesasPorCategoria(CategoriaDespesa);
        //Inserir quando tiver a view 
        //view.mostrarDespesasPorCategoria(despesasPorCategoria);
    }

    public void MostrarTotal()
    {
        //Inserir quando tiver o model 
        //var total = gestor.calcularTotal(); 
        //Inserir quando tiver a view 
        //view.MostrarTotal(total);
    }

