using System;
using System.Collections.Generic;
using SimProgrammingGrupo22.Models;

namespace SimProgrammingGrupo22.Views
{
    public class ConsoleView
    {
        public void MostrarMenu()
        {
            Console.WriteLine("===== GESTÃO DE DESPESAS =====");
            Console.WriteLine("1 - Adicionar despesa");
            Console.WriteLine("2 - Listar todas as despesas");
            Console.WriteLine("3 - Listar despesas por categoria");
            Console.WriteLine("4 - Mostrar total das despesas");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
        }

        public int LerOpcao()
        {
            int opcao;

            do
            {
                Console.Write("Escolha uma opção: ");
            }
            while (!int.TryParse(Console.ReadLine(), out opcao));

            return opcao;
        }

        public Despesa LerNovaDespesa()
        {
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            decimal valor;
            do
            {
                Console.Write("Valor: ");
            }
            while (!decimal.TryParse(Console.ReadLine(), out valor));

            CategoriaDespesa categoria = LerCategoria();

            DateTime data;
            do
            {
                Console.Write("Data (dd/MM/yyyy): ");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out data));

            return new Despesa
            {
                Descricao = descricao,
                Valor = valor,
                Categoria = categoria,
                Data = data
            };
        }

        public CategoriaDespesa LerCategoria()
        {
            Console.WriteLine("Escolha uma categoria:");
            Console.WriteLine("1 - energia");
            Console.WriteLine("2 - agua");
            Console.WriteLine("3 - Mercearia");
            Console.WriteLine("4 - Roupas");
            Console.WriteLine("5 - Telemovel");
            Console.WriteLine("6 - Carro");
            Console.WriteLine("7 - Saude");
            Console.WriteLine("8 - Educacao");
            Console.WriteLine("9 - Outra");

            int opcao;
            do
            {
                Console.Write("Opção: ");
            }
            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 9);

            return (CategoriaDespesa)(opcao - 1);
        }

        public void MostrarDespesas(List<Despesa> despesas)
        {
            if (despesas.Count == 0)
            {
                Console.WriteLine("Não existem despesas registadas.");
                return;
            }

            Console.WriteLine("===== LISTA DE DESPESAS =====");

            foreach (Despesa despesa in despesas)
            {
                Console.WriteLine($"Descrição: {despesa.Descricao}");
                Console.WriteLine($"Valor: {despesa.Valor} €");
                Console.WriteLine($"Categoria: {despesa.Categoria}");
                Console.WriteLine($"Data: {despesa.Data:dd/MM/yyyy}");
                Console.WriteLine("----------------------------");
            }
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public void MostrarTotal(decimal total)
        {
            Console.WriteLine($"Total das despesas: {total} €");
        }
    }

}