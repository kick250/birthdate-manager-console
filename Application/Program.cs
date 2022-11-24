using System;
using BirthdateManager;
using System.Collections.Generic;
using TP3;

namespace TP3
{
  class Program
  {
    PeopleRepository PeopleRepository = PeopleRepository.Build();

    public static void Main(string[] args)
    {
      Console.WriteLine("Gerenciamento de Aniversários\n");
      ShowMenuOptions();
    }

    private static void ShowMenuOptions()
    {
      int option = 0;
      List<int> VALIDOPTIONS = new List<int> { 1, 2, 3 };

      do {
        int input;
        Console.WriteLine("Escolha uma opção");
        Console.WriteLine("1 - Pesquisar pessoa");
        Console.WriteLine("2 - Adicionar pessoa");
        Console.WriteLine("3 - Sair");
        Console.Write("Sua escolha: ");
        string value = Helper.ReadString();

        if (!Helper.IsInt(value))
          continue;

        input = int.Parse(value);

        if (!VALIDOPTIONS.Exists(n => n == input))
          continue;

        option = int.Parse(value);
      } while (option == 0);
    }
  }
}