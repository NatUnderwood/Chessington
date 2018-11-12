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
            var max = Math.Max(location.Row, location.Col);
            var min = Math.Min(location.Row, location.Col);
            var minMoves = Math.Min(8 - max, min);
            for (var i = 1; i < (8 - max); i++)
            {
                if (CheckForBlockingPiece(location.Row + i, location.Col + i, board))
                {
                    movesList.Add(Square.At(location.Row + i, location.Col + i));
                }
                else
                {
                    break;
                }
            }

            for (var i = 1; i < min + 1; i++)
            {
                if (CheckForBlockingPiece(location.Row - i, location.Col - i, board))
                {
                    movesList.Add(Square.At(location.Row - i, location.Col - i));
                }
                else
                {
                    break;
                }
            }

            for (var i = 1; i < minMoves; i++)
            {
                if (CheckForBlockingPiece(location.Row - i, location.Col + i, board))
                {
                    movesList.Add(Square.At(location.Row - i, location.Col + i));
                }
                else
                {
                    break;
                }
            }
            for
                (var i = 1; i < minMoves; i++)
            {
                if (CheckForBlockingPiece(location.Row + i, location.Col - i, board))
                {
                    movesList.Add(Square.At(location.Row + i, location.Col - i));
                }
                else
                {
                    break;
                }
            }

            return movesList;
        }
        public static bool CheckForBlockingPiece(int row, int col, Board board)
        {
            if (board.GetPiece(Square.At(row, col)) == null)
                return true;
            return false;
        }
    }
}