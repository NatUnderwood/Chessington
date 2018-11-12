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

            for(var i = 0; i < 8; i++)
                movesList.Add(Square.At(location.Row, i));

            for (var i = 0; i < 8; i++)
                movesList.Add(Square.At(i, location.Col));

            movesList.RemoveAll(s => s == Square.At(4, 4));

            return movesList;
        }
    }
}