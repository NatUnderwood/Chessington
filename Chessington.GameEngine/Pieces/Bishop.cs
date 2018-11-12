using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var movesList = new List<Square>();
            var location = board.FindPiece(this);
            var max = Math.Max(location.Row, location.Col);
            var min = Math.Min(location.Row, location.Col);
            var minMoves = Math.Min(8 - max, min);
            for (var i=1;i<(8-max);i++)
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

            for (var i = 1; i <  minMoves; i++)
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

    }
}