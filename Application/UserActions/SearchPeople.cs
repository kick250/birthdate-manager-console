using System;
using BirthdateManager;
using System.Collections.Generic;

namespace TP3
{
  namespace UserActions
  {
    public class SearchPeople : UserAction
    {
      private PeopleRepository Repository { get; set; }

      public static SearchPeople Build()
      {
        return new SearchPeople(
          PeopleRepository.Build()
        );
      }

      public SearchPeople(PeopleRepository peopleRepository)
      {
        Repository = peopleRepository;
      }

      public void Execute()
      {
        Console.WriteLine("Digite uma parte do nome da pessoa: ");
        string name = Helper.ReadString(input: "Nome: ");

        List<People> peoples = Repository.GetByName(name);

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