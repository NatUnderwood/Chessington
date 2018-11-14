using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public static class DiagonalPieceChecker
    {
        public static IEnumerable<Square> GetAvailableDiagonalMoves(Board board, Square location)
        {
            var movesList = new List<Square>();
            var movesListArray = new List<Square>[4];
            var max = Math.Max(location.Row, location.Col);
            var min = Math.Min(location.Row, location.Col);
            var minMoves = Math.Min(8 - max, min);
            var moveDirectionsAndMaximums = new [,] {{1, 1,8-max}, {1, -1,minMoves}, {-1, -1, min+1}, {-1, 1,minMoves}};

            for (var direction = 0;direction<4; direction++)
            {
                movesListArray[direction]= AddMoves(board, location, moveDirectionsAndMaximums[direction,2], moveDirectionsAndMaximums[direction, 0],
                    moveDirectionsAndMaximums[direction, 1]);
            }

            foreach (var moveList in movesListArray)
            {
                if (moveList != null && movesList.Count == 0)
                    movesList = moveList;
                else if (moveList != null && movesList.Count != 0)
                    movesList.Concat(moveList);
            }

            return movesList;
        }

        public static List<Square> AddMoves(Board board, Square location, int maxI,int rowChange, int colChange)
        {
            var movesList = new List<Square>();

            for
                (var i = 1; i < maxI; i++)
            {
                if (CheckIfSquareEmpty(location.Row + i* rowChange, location.Col + i*colChange, board))
                {
                    movesList.Add(Square.At(location.Row + i* rowChange, location.Col + i * colChange));
                }
                else
                {
                    if (board.GetPiece(Square.At(location.Row + i+ rowChange, location.Col +i * colChange)).Player != board.CurrentPlayer)
                        movesList.Add(Square.At(location.Row + i* rowChange, location.Col +i * colChange));
                    break;
                }
            }

            return movesList;
        }
        public static bool CheckIfSquareEmpty(int row, int col, Board board)
        {
            return board.GetPiece(Square.At(row, col)) == null;
        }
    }
}