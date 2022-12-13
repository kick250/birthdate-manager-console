namespace Database;
using System.Collections.Generic;

public class PeoplesDatabase
{
  private const string filePath = "/Users/kick/Desktop/peoples.txt";

  public static PeoplesDatabase Build()
  {
    return new PeoplesDatabase();
  }

  public List<Dictionary<string, string?>> GetAll()
  {
    var peoples = new List<Dictionary<string, string?>>() {};

    StreamReader file = new StreamReader(filePath);

    string? line;
    line = file.ReadLine();

    while (!string.IsNullOrEmpty(line))
    {
      peoples.Add(ParseToPeopleData(line));

      line = file.ReadLine();
    }

    file.Close();

    return peoples;
  }

  public void Create(Dictionary<string, string?> peopleData)
  {
    File.AppendAllText(filePath, FormatPeopleToString(peopleData));
  }

  public void Update(Dictionary<string, string?> editedPeopleData)
  {
    var peoples = GetAll();

    var updatedPeoples = peoples.Select(peopleData => {
      if (peopleData["Id"] == editedPeopleData["Id"])
        return editedPeopleData;
      return peopleData;
    }).ToList();

    File.WriteAllText(
      filePath,
      FormatPeoplesToString(updatedPeoples)
    );
  }

  public void DeleteById(int id)
  {
    var peoples = GetAll();
    peoples.RemoveAll(people => people["Id"] == $"{id}");

    File.WriteAllText(
      filePath,
      FormatPeoplesToString(peoples)
    );
  }

  public Dictionary<string, string?> ParseToPeopleData(string peopleDataString)
  {
    var peopleData = new Dictionary<string, string?>() {};

    string[] data = peopleDataString.Split(',');

    peopleData.Add("Id", data[0]);
    peopleData.Add("FirstName", data[1]);
    peopleData.Add("LastName", data[2]);
    peopleData.Add("Birthdate", data[3]);

    return peopleData;
  }

  public string FormatPeoplesToString(List<Dictionary<string, string?>> peoplesData)
  {
    string peoplesString = "";

    foreach (var peopleData in peoplesData)
    {
      peoplesString += FormatPeopleToString(peopleData);
    }

    return peoplesString;
  }

  public string FormatPeopleToString(Dictionary<string, string?> peopleData)
  {
    string? id = peopleData["Id"];
    string? firstName = peopleData["FirstName"];
    string? lastName = peopleData["LastName"];
    string? birthdate = peopleData["Birthdate"];

    return $"{id},{firstName},{lastName},{birthdate}\n";
  }
}
