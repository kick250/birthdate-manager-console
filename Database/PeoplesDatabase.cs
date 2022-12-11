namespace Database;
using System.Collections.Generic;

public class PeoplesDatabase
{
  private const string filePath = "../peoples.txt";

  public static PeoplesDatabase Build()
  {
    return new PeoplesDatabase();
  }

  public List<Dictionary<string, string?>> GetAll()
  {
    FileStream file = File.OpenRead(filePath);
    return new List<Dictionary<string, string?>>() {};
  }

  public void Create(Dictionary<string, string?> peopleData)
  {
    File.AppendAllText(filePath, FormatPeopleString(peopleData));
  }

  public string FormatPeopleString(Dictionary<string, string?> peopleData)
  {
    string? id = peopleData["Id"];
    string? firstName = peopleData["FirstName"];
    string? lastName = peopleData["LastName"];
    string? birthdate = peopleData["Birthdate"];

    return $"{id},{firstName},{lastName},{birthdate};";
  }
}
