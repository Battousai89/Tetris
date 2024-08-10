namespace Tetris
{
    public static class Tetrominoes
    {
        public static Tetromino I = new Tetromino(new int[,]
        {
            { 1, 1, 1, 1 }
        });

        public static Tetromino O = new Tetromino(new int[,]
        {
            { 1, 1 },
            { 1, 1 }
        });

        public static Tetromino T = new Tetromino(new int[,]
        {
            { 0, 1, 0 },
            { 1, 1, 1 }
        });

        public static Tetromino L = new Tetromino(new int[,]
        {
            { 0, 1, 0 },
            { 0, 1, 0 },
            { 0, 1, 1 }
        });

        public static Tetromino J = new Tetromino(new int[,]
        {
            { 0, 1, 0 },
            { 0, 1, 0 },
            { 1, 1, 0 }
        });

        public static Tetromino Z = new Tetromino(new int[,]
        {
            { 0, 1 },
            { 1, 1 },
            { 1, 0 }
        });

        public static Tetromino S = new Tetromino(new int[,]
        {
            { 1, 0 },
            { 1, 1 },
            { 0, 1 }
        });
    }

}
