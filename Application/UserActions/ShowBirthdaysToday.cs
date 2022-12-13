using System;
using BirthdateManager.Models;
using BirthdateManager.Services;
using System.Collections.Generic;

namespace BirthdateManagerConsole.UserActions;

public class ShowBirthdaysToday : UserAction
{
  private PeoplesService Service { get; set; }

  public static ShowBirthdaysToday Build()
  {
    return new ShowBirthdaysToday(
      PeoplesService.Build()
    );
  }

  public ShowBirthdaysToday(PeoplesService service)
  {
    Service = service;
  }

  public void Execute()
  {
    List<People> peoples = Service.GetBirthdayToday();

    if (peoples.Count() == 0)
    {
      Console.WriteLine("Não existem aniversários hoje. :(");
      return;
    }

    Console.WriteLine("Aniversários hoje:");
    for (int index = 0; index < peoples.Count(); index++)
    {
      People people = peoples[index];
      Console.WriteLine($"{index} - {people.GetFullName()}");
    }

    Console.Write("\n\n");
  }
}