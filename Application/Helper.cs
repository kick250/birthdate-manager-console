using System;
using System.Collections.Generic;

namespace TP3
{
  class Helper
  {
    public static int ReadInt(string message = "", List<int>? validValues = null) {
      int result = -1;

      do {
        int input;

        if (!string.IsNullOrEmpty(message))
          Console.Write(message);

        string? value = Console.ReadLine();

        if (string.IsNullOrEmpty(value))
        {
          Console.WriteLine("Voce deve preencher algum valor.");
          continue;
        }

        if (!Helper.IsInt(value))
        {
          Console.WriteLine("O valor deve ser numerico");
          continue;
        }

        input = int.Parse(value);

        if (validValues != null && !validValues.Exists(n => n == input))
        {
          Console.WriteLine("O valor deve estar entre as opcoes");
          continue;
        }

        result = int.Parse(value);
      } while (result == -1);

      return result;
    }

    public static string ReadString(string input = "")
    {
      string? value = "";

      while(true)
      {
        if (!string.IsNullOrEmpty(input))
          Console.Write(input);

        value = Console.ReadLine();

        if (string.IsNullOrEmpty(value)) {
          Console.WriteLine("Valor invalido");
          continue;
        }

        break;
      };

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