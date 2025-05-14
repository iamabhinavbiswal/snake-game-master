using Snake_Game;

Coord gridDimesions = new Coord(50, 20);
Coord snakePos = new Coord(10, 1);
Random rand = new Random();
Coord applePos = new Coord(rand.Next(1, gridDimesions.X - 1), rand.Next(1, gridDimesions.Y - 1));
int frameDelayMilli = 100;
Direction movementDirection = Direction.Down;
int score = 0;

List<Coord> snakePosHistory = new List<Coord>();
int tailLength = 1;

while (true) {
    Console.Clear();
    Console.WriteLine("Score: " + score);
    snakePos.AppleMovementDirection(movementDirection);
    for (int y = 0; y < gridDimesions.Y; y++)
    {
        for (int x = 0; x < gridDimesions.X; x++)
        {
            Coord currentCoord = new Coord(x, y);

            if (snakePos.Equals(currentCoord) || snakePosHistory.Contains(currentCoord))
                Console.Write("■");
            else if (applePos.Equals(currentCoord))
                Console.Write("*");
            else if (x == 0 || x == gridDimesions.X - 1 || y == 0 || y == gridDimesions.Y - 1)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
    if (snakePos.Equals(applePos))
    {
        applePos = new Coord(rand.Next(1, gridDimesions.X - 1), rand.Next(1, gridDimesions.Y - 1));
        tailLength++;
        score++;
    }
    else if (snakePos.X == 0 || snakePos.Y == 0 || snakePos.X == gridDimesions.X - 1 || snakePos.Y == gridDimesions.Y - 1 || snakePosHistory.Contains(snakePos))
    { 
        score  = 0;
        tailLength = 1;
        snakePos = new Coord(10, 1);
        snakePosHistory.Clear();
        movementDirection = Direction.Down;
        continue;
    }
        snakePosHistory.Add(new Coord(snakePos.X, snakePos.Y));
    if (snakePosHistory.Count > tailLength)
    {
        snakePosHistory.RemoveAt(0);
    }
    DateTime time = DateTime.Now;

    while ((DateTime.Now - time).Milliseconds < frameDelayMilli)
    {
        if (Console.KeyAvailable) 
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
                {
                case ConsoleKey.UpArrow:
                    movementDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    movementDirection = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    movementDirection = Direction.Right;
                    break;
            }
        }
    }
}
