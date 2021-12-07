using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("Input4.txt");
            var bingoNumbersStrings = lines[0].Split(',');
            var bingoNumbers = bingoNumbersStrings.ToList().Select(x => int.Parse(x)).ToArray();

            int i = 2;  // First line of first board
            var boards = new List<BingoBoard>();
            int boardNumber = 0;

            while (i < lines.Length)
            {
                // Read a board
                var board = new BingoBoard() { BoardNumber = boardNumber++, Numbers = new List<int>()};
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        board.Numbers.Add(int.Parse(lines[i].Substring(k * 3, 2)));
                    }

                    i++;
                }

                boards.Add(board);
                i++;
            }

            Console.WriteLine($"Number of boards: {boards.Count}");

            // Start reading bingo numbers

            var winningBoard = -1;
            var currentNumber = -1;

            var bingoIndex = 0;

            while (winningBoard == -1)
            {
                currentNumber = bingoNumbers[bingoIndex++];

                foreach (var board in boards)
                {
                    var bingoBoard = Bingo(bingoNumbers, bingoIndex, board);
                    if (bingoBoard >= 0)
                    {
                        Console.WriteLine($"Bingo: Board nr {bingoBoard}, drawn number: {currentNumber}");
                        winningBoard = bingoBoard;
                        break;
                    }
                }
            }

            if (winningBoard < 0)
            {
                Console.WriteLine("No winner board");
                Console.ReadKey();
                return;
            }

            var sumOfUnmarkedNumbers = GetSumOfUnmarkedNumbers(bingoNumbers, bingoIndex, boards[winningBoard]);

            Console.WriteLine($"Score: {currentNumber * sumOfUnmarkedNumbers}");
            Console.ReadKey();
        }

        private static int GetSumOfUnmarkedNumbers(int[] bingoNumbers, int bingoIndex, BingoBoard board)
        {
            var drawnNumbers = GetDrawnNumbers(bingoNumbers, bingoIndex);

            var sum = 0;

            foreach (var boardNumber in board.Numbers)
            {
                if (!drawnNumbers.Contains(boardNumber))
                    sum += boardNumber;
            }

            return sum;
        }

        private static List<int> GetDrawnNumbers(int[] bingoNumbers, int bingoIndex)
        {
            var drawnNumbers = new List<int>();
            for (int i = 0; i < bingoIndex; i++)
            {
                drawnNumbers.Add(bingoNumbers[i]);
            }

            return drawnNumbers;
        }

        private static int Bingo(int[] bingoNumbers, int bingoIndex, BingoBoard board)
        {
            // Check all lines and columns if they match the bingonumbers
            var drawnNumbers = GetDrawnNumbers(bingoNumbers, bingoIndex);

            // All lines
            for (int line = 0; line < 5; line++)
            {
                int matches = 0;
                for (int column = 0; column < 5; column++)
                {
                    if (drawnNumbers.Contains(board.Numbers[line * 5 + column]))
                        matches++;
                }

                if (matches == 5)
                {
                    // Bingo!
                    return board.BoardNumber;
                }
            }

            // All columns
            for (int column = 0; column < 5; column++)
            {
                int matches = 0;
                for (int line = 0; line < 5; line++)
                {
                    if (drawnNumbers.Contains(board.Numbers[line * 5 + column]))
                        matches++;
                }

                if (matches == 5)
                {
                    // Bingo!
                    return board.BoardNumber;
                }
            }

            return -1;
        }
    }
}
