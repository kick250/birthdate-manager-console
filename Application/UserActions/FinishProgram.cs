using System;

namespace BirthdateManagerConsole
{
  namespace UserActions
  {
    public class FinishProgram : UserAction
    {
      public static FinishProgram Build()
      {
        return new FinishProgram();
      }

      public void Execute()
      {
        Environment.Exit(1);
      }
    }
  }
}