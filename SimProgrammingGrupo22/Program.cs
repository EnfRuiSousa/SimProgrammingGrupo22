using System;
using System.Text;
using SimProgrammingGrupo22.Models;
using SimProgrammingGrupo22.Views;

namespace SimProgrammingGrupo22
{
    class Program
    {
        public static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            var gestor = new GestorDespesas();
            var view = new ConsoleView();
            var controller = new DespesaController(gestor, view);

            controller.Iniciar();
        }
    }
}