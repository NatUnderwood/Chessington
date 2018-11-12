using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var movesList = new List<Square>();
            var location = board.FindPiece(this);
            
            switch (board.CurrentPlayer)
            {
                case Player.Black:
                    movesList.Add(new Square(location.Row + 1, location.Col));
                    break;
                case Player.White:
                    movesList.Add(new Square(location.Row - 1, location.Col));
                    break;
            }
            
            return movesList;
        }
    }
}