namespace SnakeGame
{
    public class Snake
    {
        private readonly ConsoleColor _headColore;
        private readonly ConsoleColor _bodyColore;

        public Snake(int initialX,
            int initialY,
            ConsoleColor headColor,
            ConsoleColor bodyColor,
            int bodyLength = 3
            )
        {
            _headColore = headColor;
            _bodyColore = bodyColor;

            Head = new Pixel(initialX, initialY, _headColore);
            for (int i = bodyLength; i >= 0; i--)
            {
                Body.Enqueue(new Pixel(Head.X - i - 1, initialY, _bodyColore));
            }

            Draw();
        }

        public Pixel Head { get; private set; }

        public Queue<Pixel> Body { get; } = new Queue<Pixel>();

        public void Move(Direction direction, bool eat = false)
        {
            Clear();

            Body.Enqueue(new Pixel(Head.X, Head.Y, _bodyColore));
            if(!eat)
                Body.Dequeue();

            Head = direction switch
            {
                Direction.Right => new Pixel(Head.X + 1, Head.Y, _headColore),
                Direction.Left => new Pixel(Head.X - 1, Head.Y, _headColore),
                Direction.Up => new Pixel(Head.X, Head.Y - 1, _headColore),
                Direction.Down => new Pixel(Head.X, Head.Y + 1, _headColore),
                _ => Head
            };

            Draw();
        }

        public void Draw()
        {
            Head.Draw();
            foreach (Pixel pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();
            foreach (Pixel pixel in Body)
            {
                pixel.Clear();
            }
        }
    }
}
