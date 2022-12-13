using System;
using System.Collections.Generic;
using BirthdateManager.Models;
using BirthdateManager.Factories;
using Database;

namespace BirthdateManager
{
  namespace Repositories
  {
    public class PeoplesRepository
    {
      PeoplesDatabase Database { get; set; }
      PeopleFactory Factory { get; set; }

      public static PeoplesRepository Build()
      {
        return new PeoplesRepository(
          PeoplesDatabase.Build(),
          new PeopleFactory()
        );
      }

      public PeoplesRepository(PeoplesDatabase database, PeopleFactory factory)
      {
        Database = database;
        Factory = factory;
      }

      public List<People> GetAll()
      {
        var peoples = new List<People> {};

        foreach(var peopleData in Database.GetAll())
        {
          peoples.Add(
            Factory.BuildFromDictionary(peopleData)
          );
        }

        return peoples;
      }

      public List<People> GetBirthdayToday()
      {
        return GetAll().Where(people => people.IsBirthdayToday()).ToList();
      }

      public List<People> GetByName(string name)
      {
        var peoples = new List<People> {};

        foreach(var peopleData in Database.GetAll())
        {
          People people = Factory.BuildFromDictionary(peopleData);
          if (people.HasThisName(name))
          {
            peoples.Add(people);
          }
        }

        return peoples;
      }

      public void Create(People people)
      {
        people.SetId();
        Database.Create(people.ToDictionary());
      }

      public void Update(People people)
      {
        Database.Update(people.ToDictionary());
      }

      public void DeleteById(int id)
      {
        Database.DeleteById(id);
      }
    }
  }
}