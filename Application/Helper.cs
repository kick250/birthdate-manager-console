using System;

namespace TP3
{
  class Helper
  {
    public static string ReadString()
    {
      string? value = "";

      value = Console.ReadLine();

      if (string.IsNullOrEmpty(value)) {
        Console.WriteLine("Valor invalido");
        value = "";
      }

      return value;
    }

    public static bool IsInt(string value) {
      try
      {
        int.Parse(value);
        return true;
      } catch (FormatException)
      {
        return false;
      }
    }
  }
}