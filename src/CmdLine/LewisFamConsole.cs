using System;

namespace LewisFam.CmdLine
{
    public abstract class LewisFamConsole
    {
        protected static string HelloWorld => "Hello World!";

        protected static void PrintLine(object obj) =>
            Console.WriteLine(obj);

        protected static void SetColor(ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }

        protected static void ResetColor()
        {
            Console.ResetColor();
        }
    }
}