using Tetris;

GameField field = new GameField(20, 30);
Tetromino currentTetromino = Tetrominoes.Z; // Начальная фигура
int posX = 3;
int posY = 0;

while (true)
{
    field.DrawField(currentTetromino, posX, posY);

    // Обработка нажатия клавиш
    if (Console.KeyAvailable)
    {
        ConsoleKey key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (!field.CheckCollision(currentTetromino, posX - 1, posY))
                    posX--;
                break;
            case ConsoleKey.RightArrow:
                if (!field.CheckCollision(currentTetromino, posX + 1, posY))
                    posX++;
                break;
            case ConsoleKey.DownArrow:
                if (!field.CheckCollision(currentTetromino, posX, posY + 1))
                    posY++;
                break;
            case ConsoleKey.UpArrow:
                currentTetromino.Rotate();
                if (field.CheckCollision(currentTetromino, posX, posY))
                    currentTetromino.Rotate();
                break;
        }
    }

    if (!field.CheckCollision(currentTetromino, posX, posY + 1))
    {
        posY++;
    }
    else
    {
        field.AddTetromino(currentTetromino, posX, posY);
        field.ClearFullLines();
        posX = 3;
        posY = 0;
        currentTetromino = Tetrominoes.I;

        // Проверка на конец игры
        if (field.CheckCollision(currentTetromino, posX, posY))
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            break;
        }
    }

    System.Threading.Thread.Sleep(500);
}
