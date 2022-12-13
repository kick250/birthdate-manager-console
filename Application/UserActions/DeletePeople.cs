using System;
using BirthdateManager.Models;
using BirthdateManager.Services;

namespace BirthdateManagerConsole
{
  namespace UserActions
  {
    public class DeletePeople : IUserAction
    {
      private IPeoplesService Service { get; set; }

      public static DeletePeople Build()
      {
        return new DeletePeople(
          PeoplesService.Build()
        );
      }

      public DeletePeople(IPeoplesService service)
      {
        Service = service;
      }

      public void Execute()
      {
        People people = AskForPeopleOption(Service.GetAll());

        Service.DeleteById(people.GetId());
      }

      private People AskForPeopleOption(List<People> peoples)
      {
        List<int> validValues = new List<int> {};

        Console.WriteLine("Escolha uma das oções abaixo para Deletar: ");

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
