namespace Tetris
{
    public class GameField
    {
        private readonly int[,] _field;
        public int Width { get; }
        public int Height { get; }

        public GameField(int width, int height)
        {
            Width = width;
            Height = height;
            _field = new int[Height, Width];
        }

        // Метод добавления фигуры на поле
        public bool AddTetromino(Tetromino tetromino, int posX, int posY)
        {
            for (int y = 0; y < tetromino.Height; y++)
            {
                for (int x = 0; x < tetromino.Width; x++)
                {
                    if (tetromino.Shape[y, x] == 1)
                    {
                        if (posY + y >= Height || posX + x < 0 || posX + x >= Width || _field[posY + y, posX + x] == 1)
                            return false;

                        _field[posY + y, posX + x] = 1;
                    }
                }
            }
            return true;
        }

        // Метод для проверки коллизий
        public bool CheckCollision(Tetromino tetromino, int posX, int posY)
        {
            for (int y = 0; y < tetromino.Height; y++)
            {
                for (int x = 0; x < tetromino.Width; x++)
                {
                    if (tetromino.Shape[y, x] == 1)
                    {
                        if (posY + y >= Height || posX + x < 0 || posX + x >= Width || _field[posY + y, posX + x] == 1)
                            return true;
                    }
                }
            }
            return false;
        }

        // Метод для очистки заполненных линий
        public void ClearFullLines()
        {
            for (int y = 0; y < Height; y++)
            {
                bool isFull = true;
                for (int x = 0; x < Width; x++)
                {
                    if (_field[y, x] == 0)
                    {
                        isFull = false;
                        break;
                    }
                }
                if (isFull)
                {
                    // Сдвиг всех линий сверху вниз
                    for (int row = y; row > 0; row--)
                    {
                        for (int col = 0; col < Width; col++)
                        {
                            _field[row, col] = _field[row - 1, col];
                        }
                    }
                    for (int col = 0; col < Width; col++)
                    {
                        _field[0, col] = 0;
                    }
                }
            }
        }

        // Метод отрисовки поля
        public void DrawField(Tetromino currentTetromino, int posX, int posY)
        {
            Console.Clear();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // Проверяем, совпадает ли текущее положение с позицией фигуры
                    if (y >= posY && y < posY + currentTetromino.Height &&
                        x >= posX && x < posX + currentTetromino.Width &&
                        currentTetromino.Shape[y - posY, x - posX] == 1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(_field[y, x] == 1 ? "#" : ".");
                    }
                }
                Console.WriteLine();
            }
        }

    }

}
    