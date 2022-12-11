using System;
using BirthdateManager.Models;

namespace BirthdateManager
{
  namespace Factories
  {
    public class PeopleFactory
    {
      public People BuildFromDictionary(Dictionary<string, string?> peopleData)
      {
        return new People(
          peopleData["FirstName"],
          peopleData["LastName"],
          GetBirthdate(peopleData)
        );
      }

      private DateTime? GetBirthdate(Dictionary<string, string?> peopleData)
      {
        DateTime? birthdate;
        string? value = peopleData["Birthdate"];

        if (value == null)
          birthdate = null;
        else
          birthdate = DateTime.Parse(value);

        return birthdate;
      }
    }
  }
}