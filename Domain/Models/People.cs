using System;

namespace BirthdateManager
{
  namespace Models
  {
    public class People
    {
      private int? Id { get; set; }
      private string? FirstName { get; set; }
      private string? LastName { get; set; }
      private DateTime? Birthdate { get; set; }


      public People(int? id, string? firstName, string? lastName, DateTime? birthdate)
      {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
      }

      public People(string? firstName, string? lastName, DateTime? birthdate)
      {

        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
      }

      public int? GetId()
      {
        return Id;
      }

      public void SetId()
      {
        Id = DateTime.Now.Second * 3 * DateTime.Now.Millisecond;
      }

      public string GetFirstName()
      {
        if (FirstName == null)
          return "";

        return FirstName;
      }

      public string GetLastName()
      {
        if (LastName == null)
          return "";

        return LastName;
      }

      public string GetFullName()
      {
        return $"{FirstName} {LastName}";
      }

      public DateTime? GetBirthdate()
      {
        return Birthdate;
      }

      public bool HasThisName(string name)
      {
        return GetFullName().ToUpper().Contains(name.ToUpper());
      }

      public bool IsBirthdayToday()
      {
        if (Birthdate == null)
          return false;

        DateTime birthdate = (DateTime) Birthdate;

        DateTime today = DateTime.Now;

        return birthdate.Day == today.Day && birthdate.Month == today.Month;
      }
      public string GetFormattedBirthdate(char separateChar = '/')
      {
        if (Birthdate == null)
          return "";

        DateTime birthdate = (DateTime) Birthdate;
        string day = $"{birthdate.Day}".PadLeft(2, '0');
        string month = $"{birthdate.Month}".PadLeft(2, '0');
        string year = $"{birthdate.Year}".PadLeft(4, '0');

        return $"{day}{separateChar}{month}{separateChar}{year}";
      }
      public int GetDaysForBirthdate()
      {
        DateTime? nextBirthdateValue = GetNextBirthdate();

        if (nextBirthdateValue == null)
          return -1;

        DateTime nextBirthdate = (DateTime) nextBirthdateValue;

        int daysForBirthdate = (nextBirthdate - DateTime.Now).Days;
        return daysForBirthdate;
      }

      public DateTime? GetNextBirthdate()
      {
        if (Birthdate == null)
          return null;

        DateTime birthdate = (DateTime) Birthdate;

        DateTime today = DateTime.Today;

        int currentYear = today.Year;
        DateTime nextBirthdate = new DateTime(currentYear, birthdate.Month, birthdate.Day);

        if (today > nextBirthdate)
          return new DateTime(currentYear + 1, birthdate.Month, birthdate.Day);

        return nextBirthdate;
      }
      public Dictionary<string, string?> ToDictionary()
      {
        var dict = new Dictionary<string, string?>() {};

        dict["Id"] = $"{GetId()}";
        dict["FirstName"] = GetFirstName();
        dict["LastName"] = GetLastName();

        if (Birthdate == null)
          dict["Birthdate"] = null;
        else {
          var birthdate  = DateOnly.FromDateTime((DateTime) Birthdate);
          dict["Birthdate"] = birthdate.ToString();
        }


        return dict;
      }
    }
  }
}