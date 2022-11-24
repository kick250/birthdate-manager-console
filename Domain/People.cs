using System;

namespace BirthdateManager
{
  public class People
  {
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private DateTime Birthdate { get; set; }

    public People(string firstName, string lastName, DateTime birthdate)
    {
      FirstName = firstName;
      LastName = lastName;
      Birthdate = birthdate;
    }

    public string GetFullName() {
      return $"{FirstName} {LastName}";
    }
  }
}