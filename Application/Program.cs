using System;
using BirthdateManager;
using BirthdateManagerConsole.UserActions;
using System.Collections.Generic;

namespace BirthdateManagerConsole
{
  class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Gerenciamento de Aniversários\n");
      while (true)
      {
        UserAction action = ShowMenuOptions();
        action.Execute();
      }
    }

    private static UserAction ShowMenuOptions()
    {
      int option = 0;
      List<int> VALIDOPTIONS = new List<int> { 1, 2, 3 };

      Console.WriteLine("Escolha uma opção");
      Console.WriteLine("1 - Pesquisar pessoa");
      Console.WriteLine("2 - Adicionar pessoa");
      Console.WriteLine("3 - Sair");

      option = Helper.ReadInt(message: "Sua escolha: ", validValues: VALIDOPTIONS);

      switch (option)
      {
        case 1:
          return SearchPeople.Build();
        case 2:
          return AddPeople.Build();
        case 3:
          return FinishProgram.Build();
        default:
          throw new Exception("Valor invalido");
      }
    }
  }
}