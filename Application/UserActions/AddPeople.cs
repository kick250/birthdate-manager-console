using System;
using BirthdateManager.Models;
using BirthdateManager.Services;

namespace BirthdateManagerConsole
{
  namespace UserActions
  {
    public class AddPeople : IUserAction
    {
      private IPeoplesService Service { get; set; }

      public static AddPeople Build()
      {
        return new AddPeople(
          PeoplesService.Build()
        );
      }

      public AddPeople(IPeoplesService service)
      {
        Service = service;
      }

      public void Execute()
      {
        Console.WriteLine("Cadastrando pessoa!");
        while (true)
        {
          string firstName = Helper.ReadString(input: "Digite o primeiro nome da pessoa: ");
          string lastName = Helper.ReadString(input: "Digite o sobrenome da pessoa: ");
          DateTime birthdate = GetBirthdate();

          People people = new People(firstName, lastName, birthdate);

          if (!ConfirmCreate(people))
          {
            continue;
          }

          Service.Create(people);
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
          } catch(ArgumentOutOfRangeException) {
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
    }
  }
}