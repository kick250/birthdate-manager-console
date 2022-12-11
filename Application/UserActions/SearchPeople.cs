using System;
using BirthdateManager.Models;
using BirthdateManager.Services;
using System.Collections.Generic;

namespace BirthdateManagerConsole
{
  namespace UserActions
  {
    public class SearchPeople : UserAction
    {
      private PeoplesService Service { get; set; }

      public static SearchPeople Build()
      {
        return new SearchPeople(
          PeoplesService.Build()
        );
      }

      public SearchPeople(PeoplesService service)
      {
        Service = service;
      }

      public void Execute()
      {
        Console.WriteLine("Digite uma parte do nome da pessoa: ");
        string name = Helper.ReadString(input: "Nome: ");

        List<People> peoples = Service.GetByName(name);

        if (peoples.Count() == 0)
        {
          Console.WriteLine("Ninguem com esse nome foi encontrado.");
          return;
        }

        People people = AskForPeopleOption(peoples);

        Console.WriteLine($"Nome completo: {people.GetFullName()}");
        Console.WriteLine($"Data de aniversario: {people.GetFormattedBirthdate()}");
        Console.WriteLine($"Faltam {people.GetDaysForBirthdate()} dias para esse aniversario.");
      }

      private People AskForPeopleOption(List<People> peoples)
      {
        List<int> validValues = new List<int> {};

        Console.WriteLine("Escolha uma das oções abaixo para visualizar os dados: ");

        for (int index = 0; index < peoples.Count(); index++)
        {
          validValues.Add(index);
          People people = peoples[index];

          Console.WriteLine($"{index} - {people.GetFullName()}");
        }

        int option = Helper.ReadInt(message: "Sua escolha: ", validValues: validValues);

        return peoples[option];
      }
    }
  }
}