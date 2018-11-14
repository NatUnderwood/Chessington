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
                    if (board.GetPiece(Square.At(location.Row, i)).Player != board.CurrentPlayer)
                        movesList.Add(Square.At(location.Row, i));
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
                    if (board.GetPiece(Square.At(location.Row, i)).Player != board.CurrentPlayer)
                        movesList.Add(Square.At(location.Row, i));
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
                    if (board.GetPiece(Square.At(i, location.Col)).Player != board.CurrentPlayer)
                        movesList.Add(Square.At(i, location.Col));
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
                    if (board.GetPiece(Square.At(i, location.Col)).Player != board.CurrentPlayer)
                        movesList.Add(Square.At(i, location.Col));
                    break;
                }
            }

            return movesList;
        }
        public static bool CheckForBlockingPiece(int row, int col, Board board)
        {
            return board.GetPiece(Square.At(row, col)) == null;
        }
    }
}