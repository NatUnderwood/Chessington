using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public static class LateralPieceChecker
    {
        public static IEnumerable<Square> GetAvailableLateralMoves(Board board, Square location)
        {
            var movesList = new List<Square>();

            for (var i = location.Row + 1; i < 8; i++)
            {
                if (CheckForBlockingPiece(location.Row, i, board))
                {
                    movesList.Add(Square.At(location.Row, i));
                }
                else
                {
                    break;
                }
            }

            for (var i = location.Row - 1; i >= 0; i--)
            {
                if (CheckForBlockingPiece(location.Row, i, board))
                {
                    movesList.Add(Square.At(location.Row, i));
                }
                else
                {
                    break;
                }
            }

            for (var i = location.Col + 1; i < 8; i++)
            {
                if (CheckForBlockingPiece(i, location.Col, board))
                {
                    movesList.Add(Square.At(i, location.Col));
                }
                else
                {
                    break;
                }
            }

            for (var i = location.Col - 1; i >= 0; i--)
            {
                if (CheckForBlockingPiece(i, location.Col, board))
                {
                    movesList.Add(Square.At(i, location.Col));
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