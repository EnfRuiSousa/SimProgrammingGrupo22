public static void Main()
  {
      var gestor = new GestorDespesas();
      var view = new ConsoleView();
      var controller = new DespesaController(gestor, view);
      controller.Iniciar();
  }