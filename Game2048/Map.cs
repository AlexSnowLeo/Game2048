namespace Game2048
{
    internal class Map
    {
        public int Size { get; }
        private readonly int[,] _map;

        public Map(int size)
        {
            Size = size;
            _map = new int[size, size];
        }

        public int Get(int x, int y)
        {
            if (OnMap(x, y))
            {
                return _map[x, y];
            }
            return -1;
        }

        public void Set(int x, int y, int number)
        {
            if (OnMap(x, y))
            {
                _map[x, y] = number;
            }
        }

        private bool OnMap(int x, int y)
        {
            return x >= 0 && x < Size && 
                   y >= 0 && y < Size;
        }
    }
}
