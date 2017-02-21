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
            
            switch (this.Player)
            {
                case Player.Black:
                    if (location.Row == 1)
                    {
                        movesList.Add(new Square(location.Row+2, location.Col));
                    }
                    movesList.Add(new Square(location.Row + 1, location.Col));
                    break;
                case Player.White:
                    if (location.Row == 7)
                    {
                        movesList.Add(new Square(location.Row - 2, location.Col));
                    }
                    movesList.Add(new Square(location.Row - 1, location.Col));
                    break;
            }
            
            return movesList;
        }


    }
}