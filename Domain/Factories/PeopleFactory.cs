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
          GetId(peopleData),
          peopleData["FirstName"],
          peopleData["LastName"],
          GetBirthdate(peopleData)
        );
      }

      public int? GetId(Dictionary<string, string?> peopleData)
      {
        string? id = peopleData["Id"];
        if (id == null)
          return null;

        return int.Parse(id);
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