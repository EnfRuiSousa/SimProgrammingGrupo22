using System.ComponentModel.Design;

public class DespesasController
{
    private GestorDespesas gestor; private ConsoleView view; public DespesasController(GestorDespesas gestor, ConsoleView view) { this.gestor = gestor; this.view = view; }
    public static void Main()
    {
        var gestor = new GestorDespesas();
        var view = new ConsoleView();

        var controller = new DespesasController(gestor, view);
        controller.Iniciar();
    }
    public void Iniciar()
    {
        bool sair = false; while (!sair)
        {
            // inserir quando tiver a view 
            //view.mostrarMenu(); 
            // apagar o = 0 quando tiver a view

            int opcao = 0; //= view.LerOpcao();
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
                    MostrarTotalGasto();
                    break;
                default:
                    // inserir quando tiver a view 
                    //view.mostrarMensagem("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
    public void AdicionarDespesa()
    {
        // var despesa = view.lerDpspesa; 
        //Inserir quando tiver o gestor 
        //gestor.adicionarDespesa(despesa); 
        //view.mostrarMensagem("Despesa adicionada com sucesso!");
    }
    public void ListarDespesas()
    {
        //Inserir quando tiver o gestor 
        //var despesas = gestor.listarDespesas(); 
        //view.mostrarDespesas(despesas);
    }
    public void ListarDespesasPorCategoria()
    {
        //Inserir quando tiver o gestor 
        //var despesasPorCategoria = gestor.listarDespesasPorCategoria(); 
        //view.mostrarDespesasPorCategoria(despesasPorCategoria);
    }

    public void MostrarTotalGasto()
    {
        //Inserir quando tiver o gestor
        //var totalGasto = gestor.calcularTotalGasto(); 
        //view.mostrarTotalGasto(totalGasto);
    }

    public class GestorDespesas()
    {
        //Construtor do gestor de despesas
    }

    public class ConsoleView()
    {
        //Construtor da view
    }
}

