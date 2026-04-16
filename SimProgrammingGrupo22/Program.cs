using SimProgrammingGrupo22.Models;
using SimProgrammingGrupo22.Views;

namespace SimProgrammingGrupo22
{
    class Program
    {
        public static void Main()
        {
            var gestor = new GestorDespesas();
            var view = new ConsoleView();
            var controller = new DespesaController(gestor, view);
            controller.Iniciar();
        }
    }
}