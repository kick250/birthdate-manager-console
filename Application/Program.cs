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

      PrintBirdaysToday();

      while (true)
      {
        UserAction action = ShowMenuOptions();
        action.Execute();
      }
    }

    private static void PrintBirdaysToday()
    {
      UserAction action = ShowBirthdaysToday.Build();

      action.Execute();
    }

    private static UserAction ShowMenuOptions()
    {
      int option = 0;
      List<int> VALIDOPTIONS = new List<int> { 1, 2, 3, 4, 5, 6 };

      Console.WriteLine("Escolha uma opção");
      Console.WriteLine("1 - Pesquisar pessoa");
      Console.WriteLine("2 - Adicionar pessoa");
      Console.WriteLine("3 - Atualizar pessoa");
      Console.WriteLine("4 - Deletar pessoa");
      Console.WriteLine("5 - Exibir aniversários do dia");
      Console.WriteLine("6 - Sair");

      option = Helper.ReadInt(message: "Sua escolha: ", validValues: VALIDOPTIONS);

      switch (option)
      {
        case 1:
          return SearchPeople.Build();
        case 2:
          return AddPeople.Build();
        case 3:
          return UpdatePeople.Build();
        case 4:
          return DeletePeople.Build();
        case 5:
          return ShowBirthdaysToday.Build();
        case 6:
          return FinishProgram.Build();
        default:
          throw new Exception("Valor invalido");
      }
    }
  }
}