using System;
using TurboTarot.Class;
using TurboTarot.Service;

namespace TurboTarot
{
    class Program
    {
        static void Main(string[] args)
        {
            TableService tableService = new TableService();
            new ConsoleService(tableService);
        }
    }
}
