using System;
using BirthdateManager;
using System.Collections.Generic;

namespace BirthdateManager
{
  public class PeopleRepository
  {
    private static List<People>? SavedPeoples { get; set; }

    public static PeopleRepository Build()
    {
      People people1 = new People("Breno", "Lobato", new DateTime(2002, 6, 28));
      People people2 = new People("Joao", "Silva", new DateTime(2004, 12, 1));
      People people3 = new People("Luana", "Silveira", new DateTime(2000, 1, 1));

      List<People> peoples = new List<People> {
        people1,
        people2,
        people3
      };

      return new PeopleRepository(peoples);
    }

    public PeopleRepository(List<People> savedPeoples)
    {
      SavedPeoples = savedPeoples;
    }

    public List<People> GetAll()
    {
      if (SavedPeoples == null)
        return new List<People> {};

      return SavedPeoples;
    }

    public List<People> GetByName(string searchedName)
    {
      List<People> peoples = new List<People> {};

      foreach (People people in GetAll())
      {
        string poepleName = people.GetFullName().ToLower();
        if (poepleName.Contains(searchedName.ToLower()))
          peoples.Add(people);
      }
      return peoples;
    }
  }
}