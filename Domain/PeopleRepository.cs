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
      People people2 = new People("Joao", "Silva", new DateTime(2004, 8, 12));
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
  }
}