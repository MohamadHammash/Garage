using System;

namespace GarageApplikation
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new ConsoleUI();
            var manager = new GarageManager();
            manager.Run();

        }
    }
}
