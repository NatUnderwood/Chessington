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
            var movesList = DiagonalPieceChecker.GetAvailableDiagonalMoves(board, board.FindPiece(this));
            var lateralMovesList = LateralPieceChecker.GetAvailableLateralMoves(board, board.FindPiece(this));
            
            return movesList.Concat(lateralMovesList); ;
        }
    }
}