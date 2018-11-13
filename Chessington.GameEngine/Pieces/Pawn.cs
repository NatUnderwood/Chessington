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
                    if (location.Row == 7)
                        break;
                    if (this.HasMoved==false && CheckForBlockingPiece(location.Row + 1, location.Col, board) && CheckForBlockingPiece(location.Row + 2, location.Col, board))
                    {
                        movesList.Add(Square.At(location.Row+2, location.Col));
                    }
                    if(CheckForBlockingPiece(location.Row + 1, location.Col, board))
                        movesList.Add(Square.At(location.Row + 1, location.Col));
                    break;
                case Player.White:
                    if (location.Row==0)
                        break;
                    if (this.HasMoved == false && CheckForBlockingPiece(location.Row-1,location.Col,board) && CheckForBlockingPiece(location.Row-2, location.Col, board))
                    {
                        movesList.Add(Square.At(location.Row - 2, location.Col));
                    }
                    if (CheckForBlockingPiece(location.Row - 1, location.Col, board))
                        movesList.Add(Square.At(location.Row - 1, location.Col));
                    break;
            }
            
            return movesList;
        }
    }
}