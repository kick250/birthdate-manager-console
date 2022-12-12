using System;
using BirthdateManager.Models;
using BirthdateManager.Services;

namespace BirthdateManagerConsole
{
  namespace UserActions
  {
    public class UpdatePeople : UserAction
    {
      private PeoplesService Service { get; set; }

      public static UpdatePeople Build()
      {
        return new UpdatePeople(
          PeoplesService.Build()
        );
      }

      public UpdatePeople(PeoplesService service)
      {
        Service = service;
      }

      public void Execute()
      {
        Console.WriteLine("Atualizando pessoa!");

        People people = AskForPeopleOption(Service.GetAll());

        while (true)
        {
          string firstName = Helper.ReadString(input: "Digite o primeiro nome da pessoa: ");
          string lastName = Helper.ReadString(input: "Digite o sobrenome da pessoa: ");
          DateTime birthdate = GetBirthdate();

          People editedPeople = new People(people.GetId(), firstName, lastName, birthdate);

          if (!ConfirmCreate(editedPeople))
          {
            continue;
          }

          Service.Update(editedPeople);
          return;
        }
      }

      private DateTime GetBirthdate()
      {
        int day;
        int month;
        int year;

        while (true)
        {
          try
          {
            string unparsedBirthdate = Helper.ReadString(input: "Digite a data de aniversario da pessoa(dd/mm/yy): ");
            string[] birthdateData = unparsedBirthdate.Split('/');

            day = int.Parse(birthdateData[0]);
            month = int.Parse(birthdateData[1]);
            year = int.Parse(birthdateData[2]);

            return new DateTime(year, month, day);
          } catch(IndexOutOfRangeException) {
            Console.WriteLine("Formato de data invalido.");
            continue;
          }
        }
      }

      private bool ConfirmCreate(People people)
      {
        Console.WriteLine("Confirme os dados abaixo: ");
        Console.WriteLine($"Nome: {people.GetFullName()}");
        Console.WriteLine($"Aniversario: {people.GetFormattedBirthdate()}");

        List<int> validOptions = new List<int> { 1, 2 };
        Console.WriteLine("1 - Prosseguir");
        Console.WriteLine("2 - Editar");

        int option = Helper.ReadInt(message: "Sua escolher: ", validValues: validOptions);
        switch (option)
        {
          case 1:
            return true;
          case 2:
            return false;
          default:
            throw new Exception("Ocorreu um erro desconhecido");
        }
      }

      private People AskForPeopleOption(List<People> peoples)
      {
        List<int> validValues = new List<int> {};

        Console.WriteLine("Escolha uma das oções abaixo para atualizar: ");

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