using System;
using System.Timers;

namespace GameOfLife
{

    class GameOfLife
    {
        private int[,] board = new int[20, 20];
        private Oscillators oscillator;
        public enum Oscillators

        {
            Default = 0, Blinker = 1, Toad = 2, Beacon = 3, Pulsar = 4, Pentadeclathon = 5
        }
        public GameOfLife(Oscillators oscillator = Oscillators.Default)
        {
            this.oscillator = oscillator;
            InitBoard();
        }

        private void InitBoard()
        {
            switch (oscillator)
            {
                case Oscillators.Blinker:
                    {
                        SetBlinker();
                        break;
                    }
                case Oscillators.Toad:
                    {
                        SetToad();
                        break;
                    }
                case Oscillators.Beacon:
                    {
                        SetBeacon();
                        break;
                    }
                case Oscillators.Pulsar:
                    {
                        SetPulsar();
                        break;
                    }
                case Oscillators.Pentadeclathon:
                    {
                        SetPentadecathlon();
                        break;
                    }
                default:
                    {
                        RandomSeedBoard();
                        break;
                    }

            }
        }

        private void RandomSeedBoard()
        {
            Random rand = new Random();
            for (int i = 1; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = rand.Next(2);
                }
            }
        }

        private void Generate()

        {
            int[,] tempBoard = new int[board.GetLength(0), board.GetLength(1)];
            for (int i = 1; i < board.GetLength(0) - 1; i++)//start with 1 leave out the edges 
            {
                for (int j = 1; j < board.GetLength(1) - 1; j++)
                {
                    tempBoard[i, j] = CheckNeighbors(i, j);
                }
            }
            board = tempBoard;
        }

        private int CheckNeighbors(int i, int j)
        {
            int liveNeighborCount = 0;
            for (int k = -1; k <= 1; k++)
            {
                for (int l = -1; l <= 1; l++)
                {
                    liveNeighborCount += board[i + k, j + l];
                }
            }
            liveNeighborCount -= board[i, j];

            return LifeRules(i, j, liveNeighborCount);

        }

        private int LifeRules(int i, int j, int liveNeighborCount)
        {
            if (board[i, j] == 0)
            {
                if (liveNeighborCount == 3)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if (liveNeighborCount < 2 || liveNeighborCount > 3)
            {
                return 0;
            }


            return 1;
        }

        private void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    var foo = board[i, j] == 1 ? "\u25A0" : "\u25A1";
                    Console.Write("|_" + foo + "_|");
                }
                Console.WriteLine("");

            }
        }

        public void TimedGeneration()
        {



            Timer aTimer;
            aTimer = new Timer();
            aTimer.Interval = 500;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;

            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            ManualGeneration();

        }

        public void ManualGeneration()
        {
            Console.Clear();
            Generate();
            PrintBoard();


        }
        private void SetBlinker()
        {
            board[9, 9] = 1;
            board[9, 10] = 1;
            board[9, 11] = 1;
        }
        private void SetToad()
        {
            board[9, 9] = 1;
            board[9, 10] = 1;
            board[9, 11] = 1;
            board[10, 8] = 1;
            board[10, 9] = 1;
            board[10, 10] = 1;
        }

        private void SetBeacon()
        {
            board[9, 8] = 1;
            board[9, 9] = 1;
            board[10, 8] = 1;
            board[10, 9] = 1;
            board[11, 10] = 1;
            board[11, 11] = 1;
            board[12, 10] = 1;
            board[12, 11] = 1;
        }

        private void SetPulsar()
        {
            board[4, 5] = 1;
            board[4, 6] = 1;
            board[4, 7] = 1;
            board[4, 11] = 1;
            board[4, 12] = 1;
            board[4, 13] = 1;
            board[6, 3] = 1;
            board[6, 8] = 1;
            board[6, 10] = 1;
            board[6, 15] = 1;
            board[7, 3] = 1;
            board[7, 8] = 1;
            board[7, 10] = 1;
            board[7, 15] = 1;
            board[8, 3] = 1;
            board[8, 8] = 1;
            board[8, 10] = 1;
            board[8, 15] = 1;
            board[9, 5] = 1;
            board[9, 6] = 1;
            board[9, 7] = 1;
            board[9, 11] = 1;
            board[9, 12] = 1;
            board[9, 13] = 1;
            board[11, 5] = 1;
            board[11, 6] = 1;
            board[11, 7] = 1;
            board[11, 11] = 1;
            board[11, 12] = 1;
            board[11, 13] = 1;
            board[12, 3] = 1;
            board[12, 8] = 1;
            board[12, 10] = 1;
            board[12, 15] = 1;
            board[13, 3] = 1;
            board[13, 8] = 1;
            board[13, 10] = 1;
            board[13, 15] = 1;
            board[14, 3] = 1;
            board[14, 8] = 1;
            board[14, 10] = 1;
            board[14, 15] = 1;
            board[16, 5] = 1;
            board[16, 6] = 1;
            board[16, 7] = 1;
            board[16, 11] = 1;
            board[16, 12] = 1;
            board[16, 13] = 1;
        }

        private void SetPentadecathlon()
        {
            board[8, 7] = 1;
            board[8, 12] = 1;
            board[9, 5] = 1;
            board[9, 6] = 1;
            board[9, 8] = 1;
            board[9, 9] = 1;
            board[9, 10] = 1;
            board[9, 11] = 1;
            board[9, 13] = 1;
            board[9, 14] = 1;
            board[10, 7] = 1;
            board[10, 12] = 1;
        }
    }


}
