using System;

namespace Game2048
{
    public class Model
    {
        private readonly Map _map;

        private static readonly Random Random = new Random();

        private bool _isGameOver;
        private bool _moved;

        public int Size => _map.Size;

        public Model(int size)
        {
            _map = new Map(size);
        }

        public void Start()
        {
            _isGameOver = false;
            for (var x = 0; x < Size; x++)
                for (var y = 0; y < Size; y++)
                    _map.Set(x, y, 0);
            AddRandomNumber();
            AddRandomNumber();
        }


        public bool IsGameOver()
        {
            if (_isGameOver) return _isGameOver;
            for (var x = 0; x < Size; x++)
                for (var y = 0; y < Size; y++)
                    if (_map.Get(x, y) == 0)
                        return false;
            for (var x = 0; x < Size; x++)
                for (var y = 0; y < Size; y++)
                    if (_map.Get(x, y) == _map.Get(x + 1, y) || _map.Get(x, y) == _map.Get(x, y + 1))
                        return false;
            _isGameOver = true;
            return _isGameOver;
        }

        private void AddRandomNumber()
        {
            if (_isGameOver) return;
            for (var j = 0; j < Size * 10; j++)
            {
                var x = Random.Next(0, Size);
                var y = Random.Next(0, Size);
                if (_map.Get(x, y) == 0)
                {
                    _map.Set(x, y, Random.Next(1, 3) * 2);
                    return;
                }
            }
        }

        private void Move(int x, int y, int sx, int sy)
        {
            if (_map.Get(x, y) > 0)
                while (_map.Get(x + sx, y + sy) == 0)
                {
                    _map.Set(x + sx, y + sy, _map.Get(x, y));
                    _map.Set(x, y, 0);
                    x += sx;
                    y += sy;
                    _moved = true;
                }
        }

        private void Join(int x, int y, int sx, int sy)
        {
            if (_map.Get(x, y) > 0)
                if (_map.Get(x + sx, y + sy) == _map.Get(x, y))
                {
                    _map.Set(x + sx, y + sy, _map.Get(x, y) * 2);
                    while(_map.Get(x - sx, y - sx) > 0)
                    {
                        _map.Set(x, y, _map.Get(x - sx, y - sx));
                        x -= sx;
                        y -= sy;
                    }
                    _map.Set(x, y, 0);
                    _moved = true;
                }
        }

        public void Left()
        {
            _moved = false;
            for (var y = 0; y < Size; y++)
            {
                for (var x = 1; x < Size; x++) Move(x, y, -1, 0);
                for (var x = 1; x < Size; x++) Join(x, y, -1, 0);
            }
            if (_moved) AddRandomNumber();
        }

        public void Right()
        {
            _moved = false;
            for (var y = 0; y < Size; y++)
            {
                for (var x = Size - 2; x >= 0; x--) Move(x, y, +1, 0);
                for (var x = Size - 2; x >= 0; x--) Join(x, y, +1, 0);
            }
            if (_moved) AddRandomNumber();
        }

        public void Up()
        {
            _moved = false;
            for (var x = 0; x < Size; x++)
            {
                for (var y = 1; y < Size; y++) Move(x, y, 0, -1);
                for (var y = 1; y < Size; y++) Join(x, y, 0, -1);
            }
            if (_moved) AddRandomNumber();
        }

        public void Down()
        {
            _moved = false;
            for (var x = 0; x < Size; x++)
            {
                for (var y = Size - 2; y >= 0; y--) Move(x, y, 0, +1);
                for (var y = Size - 2; y >= 0; y--) Join(x, y, 0, +1);
            }

            if (_moved) AddRandomNumber();
        }


        public int GetMap(int x, int y)
        {
            return _map.Get(x, y);
        }
    }
}
