using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatInAMazeConsole
{
    public class BackingTrackSolution
    {
        private MazePosition _finalPosition;
        private int[,] _mazeSolution;
        private bool foundSolution = false;

        /// <summary>
        /// The rat can move only in two directions: forward (0,1) and down (1,0). 
        /// </summary>
        private static (int row, int col)[] _allowedDirections = new (int, int)[] { (0, 1), (1, 0) };

        public int[,] SolveMaze(int[,] maze)
        {
            int mazeLength = maze.GetLength(0);
            _mazeSolution = new int[mazeLength, mazeLength];
            _mazeSolution[0, 0] = 1;
            _finalPosition = new MazePosition(mazeLength - 1, mazeLength - 1);
            MazePosition ratPosition = new(0, 0);

            MoveRat(maze, ratPosition);
            return _mazeSolution;
        }

        private void MoveRat(int[,] maze, MazePosition ratPosition)
        {
            if (ratPosition.Equals(_finalPosition))
            {
                foundSolution = true;
                return;
            }

            for (int i = 0; i < _allowedDirections.Length; i++)
            {
                if (maze[ratPosition.Row + _allowedDirections[i].row, ratPosition.Col + _allowedDirections[i].col] == 1)
                {
                    ratPosition.Row += _allowedDirections[i].row;
                    ratPosition.Col += _allowedDirections[i].col;
                    _mazeSolution[ratPosition.Row, ratPosition.Col] = 1;
                    MoveRat(maze, ratPosition);

                    if (foundSolution)
                        return;

                    ratPosition.Row -= _allowedDirections[i].row;
                    ratPosition.Col -= _allowedDirections[i].col;
                }
            }
        }
    }

    internal struct MazePosition
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public MazePosition(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            MazePosition positionToCompare = (MazePosition)obj;
            return positionToCompare.Row == Row && positionToCompare.Col == Col;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
