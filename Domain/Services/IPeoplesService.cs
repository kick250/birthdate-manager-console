using BirthdateManager.Models;
using System.Collections.Generic;

namespace BirthdateManager.Services;

public interface IPeoplesService
{
      abstract public List<People> GetAll();

      abstract public List<People> GetBirthdayToday();

      abstract public void Update(People people);

      abstract public void Create(People people);

      abstract public void DeleteById(int id);

      abstract public List<People> GetByName(string searchedName);

}