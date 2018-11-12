using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var movesList = new List<Square>();
            var location = board.FindPiece(this);
            var max = Math.Max(location.Row, location.Col);
            var min = Math.Min(location.Row, location.Col);
            var minMoves = Math.Min(8 - max, min);
            for (var i = 1; i < (8 - max); i++)
            {
                movesList.Add(Square.At(location.Row + i, location.Col + i));
            }
            for (var i = 1; i < min + 1; i++)
            {
                movesList.Add(Square.At(location.Row - i, location.Col - i));
            }
            for (var i = 1; i < minMoves; i++)
            {
                movesList.Add(Square.At(location.Row - i, location.Col + i));
            }
            for (var i = 1; i < minMoves; i++)
            {
                movesList.Add(Square.At(location.Row + i, location.Col - i));
            }

            for (var i = 0; i < 8; i++)
                movesList.Add(Square.At(location.Row, i));

            for (var i = 0; i < 8; i++)
                movesList.Add(Square.At(i, location.Col));

            movesList.RemoveAll(s => s == Square.At(4, 4));

            return movesList;
        }
    }
}