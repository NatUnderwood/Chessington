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
            
            switch (Player)
            {
                case Player.Black:
                    if (location.Row == 7)
                        break;
                    if (HasMoved==false && CheckForBlockingPiece(location.Row + 1, location.Col, board) && CheckForBlockingPiece(location.Row + 2, location.Col, board))
                        movesList.Add(Square.At(location.Row+2, location.Col));
                    
                    if(CheckForBlockingPiece(location.Row + 1, location.Col, board))
                        movesList.Add(Square.At(location.Row + 1, location.Col));

                    if (CanTakePiece(board, location, 1)["left"])
                        movesList.Add(Square.At(location.Row + 1, location.Col-1));
                    
                    if (CanTakePiece(board, location, 1)["right"])
                        movesList.Add(Square.At(location.Row + 1, location.Col + 1));
                    break;
                case Player.White:
                    if (location.Row==0)
                        break;
                    if (HasMoved == false && CheckForBlockingPiece(location.Row-1,location.Col,board) && CheckForBlockingPiece(location.Row-2, location.Col, board))
                        movesList.Add(Square.At(location.Row - 2, location.Col));

                    if (CheckForBlockingPiece(location.Row - 1, location.Col, board))
                        movesList.Add(Square.At(location.Row - 1, location.Col));

                    if (CanTakePiece(board, location, -1)["left"])
                        movesList.Add(Square.At(location.Row - 1, location.Col - 1));

                    if (CanTakePiece(board, location, -1)["right"])
                        movesList.Add(Square.At(location.Row - 1, location.Col + 1));
                    break;
            }
            
            return movesList;
        }

        public Dictionary<string,bool> CanTakePiece(Board board, Square location, int direction)
        {
            var piecesToBeTaken = new Dictionary<string, bool> {{"left", false}, {"right", false}};
            if (location.Col+1<8 && 0<=location.Row + direction&& location.Row + direction < 8 && board.GetPiece(Square.At(location.Row + direction, location.Col + 1)) != null)
            {
                if (board.GetPiece(Square.At(location.Row + direction, location.Col + 1)).Player != Player)
                    piecesToBeTaken["right"] = true;
            }
            if (location.Col-1>=0 && 0 <= location.Row + direction && location.Row + direction < 8 && board.GetPiece(Square.At(location.Row + direction, location.Col - 1)) != null)
            {
                if (board.GetPiece(Square.At(location.Row + direction, location.Col - 1)).Player != Player)
                    piecesToBeTaken["left"] = true;
            }

            return piecesToBeTaken;



        }
    }
}