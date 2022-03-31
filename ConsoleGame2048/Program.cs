using Game2048;
using System;

namespace ConsoleGame2048
{
    class Program
    {
        private static void Main(string[] args)
        {
            var program = new Program();
            program.Start();
        }

        private Model _model;

        private void Start()
        {
            _model = new Model(4);
            _model.Start();
            while (true)
            {
                Show(_model);
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.LeftArrow:  _model.Left(); break;
                    case ConsoleKey.RightArrow: _model.Right(); break;
                    case ConsoleKey.UpArrow:    _model.Up(); break;
                    case ConsoleKey.DownArrow:  _model.Down(); break;
                    case ConsoleKey.Spacebar:   _model.Start(); break;
                    case ConsoleKey.Escape:     return;
                    default:                    continue;
                }
            }
        }

        private static void Show(Model model)
        {
            for (var y = 0; y < model.Size; y++)
                for (var x = 0; x < model.Size; x++)
                {
                    Console.SetCursorPosition(x * 5 + 5, y * 2 + 2);
                    var number = model.GetMap(x, y);
                    Console.Write(number == 0 ? ".   " : number + "    ");
                }
            Console.WriteLine();
            Console.WriteLine(model.IsGameOver() ? "GAME OVER!" : "Still play");
        }
    }
}
