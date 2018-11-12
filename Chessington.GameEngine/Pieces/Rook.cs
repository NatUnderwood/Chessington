using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var movesList = new List<Square>();
            var location = board.FindPiece(this);

            for (var i = location.Row+1; i < 8; i++)
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

            for (var i = location.Row-1; i >=0; i--)
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

            for (var i = location.Col+1; i < 8; i++)
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

            for (var i = location.Col - 1; i >=0; i--)
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
    }
}