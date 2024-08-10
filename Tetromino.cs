namespace Tetris
{
    public class Tetromino
    {
        public int[,] Shape { get; private set; }
        public int Width => Shape.GetLength(1);
        public int Height => Shape.GetLength(0);

        public Tetromino(int[,] shape)
        {
            Shape = shape;
        }

        // Поворот фигуры
        public void Rotate()
        {
            int newWidth = Height;
            int newHeight = Width;
            int[,] rotatedShape = new int[newHeight, newWidth];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    rotatedShape[x, newWidth - y - 1] = Shape[y, x];
                }
            }

            Shape = rotatedShape;
        }
    }

}
