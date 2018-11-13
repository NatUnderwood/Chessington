using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
            HasMoved = false;
        }

        public Player Player { get; private set; }
        public bool HasMoved;

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            HasMoved = true;
        }
        public bool CheckForBlockingPiece(int row, int col, Board board)
        {
            if (board.GetPiece(Square.At(row, col)) == null)
                return true;
            return false;
        }
    }
}