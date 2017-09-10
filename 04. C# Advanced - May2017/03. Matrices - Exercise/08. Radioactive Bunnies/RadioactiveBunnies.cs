using System;
using System.Linq;

namespace _08.Radioactive_Bunnies
{
    public class RadioactiveBunnies
    {
        public static void Main()
        {
            bool playerDied = false;
            bool playerEscaped = false;
            string playerPositionAfterMove = string.Empty;
            string playerPositionAfterSpread = string.Empty;

            var sizes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var rows = sizes[0];
            var columns = sizes[1];
            var matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine();
                matrix[i] = new char[columns];

                for (int j = 0; j < columns; j++)
                {
                    matrix[i][j] = line[j];
                }
            }

            var playerCommands = Console.ReadLine();

            for (int i = 0; i < playerCommands.Length; i++)
            {
                var currCommand = playerCommands[i];

                switch (currCommand)
                {
                    case 'U':
                        PlayerMoves(matrix, currCommand, out playerEscaped, out playerDied, out playerPositionAfterMove);
                        BunniesSpread(matrix, out playerDied, out playerPositionAfterSpread);
                        break;
                    case 'D':
                        PlayerMoves(matrix, currCommand, out playerEscaped, out playerDied, out playerPositionAfterMove);
                        BunniesSpread(matrix, out playerDied, out playerPositionAfterSpread);
                        break;
                    case 'R':
                        PlayerMoves(matrix, currCommand, out playerEscaped, out playerDied, out playerPositionAfterMove);
                        BunniesSpread(matrix, out playerDied, out playerPositionAfterSpread);
                        break;
                    case 'L':
                        PlayerMoves(matrix, currCommand, out playerEscaped, out playerDied, out playerPositionAfterMove);
                        BunniesSpread(matrix, out playerDied, out playerPositionAfterSpread);
                        break;
                    default:
                        break;
                }
                
                if (playerEscaped || playerDied)
                {
                    break;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
            if (!playerDied)
            {
                Console.WriteLine(playerPositionAfterMove);
            }
            else
            {
                if (playerPositionAfterSpread == String.Empty)
                {
                    Console.WriteLine(playerPositionAfterMove);
                }
                else
                {
                    Console.WriteLine(playerPositionAfterSpread);
                }
            }
        }

        public static void BunniesSpread(char[][] matrix, out bool playerDied, out string playerPositionAfterSpread)
        {
            playerDied = false;
            playerPositionAfterSpread = string.Empty;

            var newBunnyAllocation = new char[matrix.Length][];
            for (int i = 0; i < newBunnyAllocation.Length; i++)
            {
                newBunnyAllocation[i] = new char[matrix[0].Length];
            }

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (matrix[r][c] == 'B')
                    {
                        if (NewCellIsInsideMatrix(matrix, r - 1, c) && matrix[r - 1][c] == '.')
                        {
                            newBunnyAllocation[r - 1][c] = 'B';
                        }
                        else if (NewCellIsInsideMatrix(matrix, r - 1, c) && matrix[r - 1][c] == 'P')
                        {
                            playerDied = true;
                            playerPositionAfterSpread = $"dead: {r} {c}";
                            matrix[r - 1][c] = 'B';
                            break;
                        }

                        if (NewCellIsInsideMatrix(matrix, r + 1, c) && matrix[r + 1][c] == '.')
                        {
                            newBunnyAllocation[r + 1][c] = 'B';
                        }
                        else if (NewCellIsInsideMatrix(matrix, r + 1, c) && matrix[r + 1][c] == 'P')
                        {
                            playerDied = true;
                            playerPositionAfterSpread = $"dead: {r} {c}";
                            matrix[r - 1][c] = 'B';
                            break;
                        }

                        if (NewCellIsInsideMatrix(matrix, r, c - 1) && matrix[r][c - 1] == '.')
                        {
                            newBunnyAllocation[r][c - 1] = 'B';
                        }
                        else if (NewCellIsInsideMatrix(matrix, r, c - 1) && matrix[r][c - 1] == 'P')
                        {
                            playerDied = true;
                            playerPositionAfterSpread = $"dead: {r} {c}";
                            matrix[r - 1][c] = 'B';
                            break;
                        }

                        if (NewCellIsInsideMatrix(matrix, r, c + 1) && matrix[r][c + 1] == '.')
                        {
                            newBunnyAllocation[r][c + 1] = 'B';
                        }
                        else if (NewCellIsInsideMatrix(matrix, r, c + 1) && matrix[r][c + 1] == 'P')
                        {
                            playerDied = true;
                            playerPositionAfterSpread = $"dead: {r} {c}";
                            matrix[r - 1][c] = 'B';
                            break;
                        }
                    }
                    if (playerDied)
                    {
                        break;
                    }
                }
            }

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (matrix[r][c] == '.' && newBunnyAllocation[r][c] == 'B')
                    {
                        matrix[r][c] = 'B';
                    }
                }
            }
        }

        public static void PlayerMoves(char[][] matrix, char currCommand, out bool playerEscaped, out bool playerDied, out string playerPositionAfterMove)
        {
            int rowMove = 0;
            int colMove = 0;
            int currRow = 0;
            int currCol = 0;
            playerDied = false;
            playerEscaped = false;
            playerPositionAfterMove = string.Empty;

            switch (currCommand)
            {
                case 'U':
                    rowMove = -1;
                    break;
                case 'D':
                    rowMove = 1;
                    break;;
                case 'L':
                    colMove = -1;
                    break;
                case 'R':
                    colMove = 1;
                    break;
            }

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (matrix[r][c] == 'P')
                    {
                        currRow = r;
                        currCol = c;
                    }
                }
            }

            if (NewCellIsInsideMatrix(matrix, currRow + rowMove, currCol + colMove) &&
                matrix[currRow + rowMove][currCol + colMove] == '.')
            {
                matrix[currRow][currCol] = '.';
                matrix[currRow + rowMove][currCol + colMove] = 'P';
            }
            else if (!NewCellIsInsideMatrix(matrix, currRow + rowMove, currCol + colMove))
            {
                playerEscaped = true;
                playerPositionAfterMove = $"won: {currRow} {currCol}";
                matrix[currRow][currCol] = '.';
            }
            else if (NewCellIsInsideMatrix(matrix, currRow + rowMove, currCol + colMove) &&
                     matrix[currRow + rowMove][currCol + colMove] == 'B')
            {
                playerDied = true;
                playerPositionAfterMove = $"dead: {currRow} {currCol}";
                matrix[currRow][currCol] = '.';
            }
        }

        private static bool NewCellIsInsideMatrix(char[][] matrix, int i, int j)
        {
            return (i < matrix.Length && i >= 0 && j < matrix[i].Length && j >= 0);
        }
    }
}
