using System;
using System.Collections.Generic;
using BirthdateManager.Models;
using BirthdateManager.Exceptions;
using BirthdateManager.Repositories;

namespace BirthdateManager
{
  namespace Services
  {
    public class PeoplesService : IPeoplesService
    {
      PeoplesRepository Repository { get; set; }

      public static PeoplesService Build()
      {
        return new PeoplesService(
          PeoplesRepository.Build()
        );
      }

      public PeoplesService(PeoplesRepository repository)
      {
        Repository = repository;
      }

      public List<People> GetAll()
      {
        return Repository.GetAll();
      }

      public List<People> GetBirthdayToday()
      {
        return Repository.GetBirthdayToday();
      }

      public void Update(People people)
      {
        Repository.Update(people);
      }

      public void Create(People people)
      {
        Repository.Create(people);
      }

      public void DeleteById(int id)
      {
        Repository.DeleteById(id);
      }

      public List<People> GetByName(string searchedName)
      {
        return Repository.GetByName(searchedName);
      }
    }
  }
}