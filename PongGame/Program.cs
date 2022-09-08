using System.Collections;

const int fieldLenght = 50, fieldWidth = 15;
const char fieldTile = '$';
string line = string.Concat(Enumerable.Repeat(fieldTile, fieldLenght));

const int racketLenght = fieldWidth / 4;
const char racketTile = '|';

int leftRacketHeigt = 0;
int rightRacketHeigt = 0;

int ballX = fieldLenght / 2;
int ballY = fieldWidth / 2;
const char ballTile = 'O';

bool isBallGoingDown = true;
bool isBallGoingRight = true;

int leftPlayerScore = 0;
int rightPlayerScore = 0;

int scoreBoardX = fieldLenght / 2 - 2;
int scoreBoardY = fieldWidth + 3;



while (true)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine(line);

    Console.SetCursorPosition(0, fieldWidth);
    Console.WriteLine(line);

    for (int i = 0; i < racketLenght; i++)
    {
        Console.SetCursorPosition(0, i + 1 + leftRacketHeigt);
        Console.WriteLine(racketTile);
        Console.SetCursorPosition(fieldLenght - 1, i + 1 + rightRacketHeigt);
        Console.WriteLine(racketTile);
    }

    while (!Console.KeyAvailable)
    {
        Console.SetCursorPosition(ballX, ballY);
        Console.WriteLine(ballTile);
        Thread.Sleep(100);

        Console.SetCursorPosition(ballX, ballY);
        Console.WriteLine(" ");

        if (isBallGoingDown)
        {
            ballY++;
        }
        else
        {
            ballY--;
        }
        if (isBallGoingRight)
        {
            ballX++;
        }
        else
        {
            ballX--;
        }

        if (ballY == 1 || ballY == fieldWidth - 1)
        {
            isBallGoingDown = !isBallGoingDown;
        }

        if (ballX == 1)
        {
            if (ballY >= leftRacketHeigt + 1 && ballY <= leftRacketHeigt + racketLenght)
            {
                isBallGoingRight = !isBallGoingRight;
            }

            else
            {
                rightPlayerScore++;
                ballY = fieldWidth / 2;
                ballX = fieldLenght / 2;
                Console.SetCursorPosition(scoreBoardX, scoreBoardY);
                Console.WriteLine($"{leftPlayerScore} | {rightPlayerScore}");
                if (rightPlayerScore == 10)
                {
                    goto outer;
                }
            }

        }

        if (ballX == fieldLenght-2)
        {
            if (ballY >= rightRacketHeigt + 1 && ballY <= rightRacketHeigt + racketLenght)
            {
                isBallGoingRight = !isBallGoingRight;
            }

            else
            {
                leftPlayerScore++;
                ballY = fieldWidth / 2;
                ballX = fieldLenght / 2;
                Console.SetCursorPosition(scoreBoardX, scoreBoardY);
                Console.WriteLine($"{leftPlayerScore} | {rightPlayerScore}");
                if (leftPlayerScore == 10)
                {
                    goto outer;
                }
            }

        }
    }

    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.UpArrow:
            if (rightRacketHeigt > 0)
            {
                rightRacketHeigt--;
            }
            break;

        case ConsoleKey.DownArrow:
            if (rightRacketHeigt < fieldWidth - racketLenght - 1)
            {
                rightRacketHeigt++;
            }
            break;
        case ConsoleKey.W:
            if (leftRacketHeigt > 0)
            {
                leftRacketHeigt--;
            }
            break;
        case ConsoleKey.S:
            if (leftRacketHeigt < fieldWidth - racketLenght - 1)
            {
                leftRacketHeigt++;
            }
            break;
    }

    for (int i = 1; i < fieldWidth; i++)
    {
        Console.SetCursorPosition(0, i);
        Console.WriteLine(" ");
        Console.SetCursorPosition(fieldLenght - 1, i);
        Console.WriteLine(" ");
    }
}
outer:;
Console.Clear();
Console.SetCursorPosition(0, 0);
if (rightPlayerScore == 10)
{
    Console.WriteLine("Right player WON!");
}
else
{
    Console.WriteLine("Left player WON!");
}