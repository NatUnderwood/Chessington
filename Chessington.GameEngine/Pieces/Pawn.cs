using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        { //Make better!!

            var movesList = new List<Square>();
            var location = board.FindPiece(this);
            
            switch (Player)
            {
                case Player.Black:
                    movesList = CheckAllowedMoves(location, board, Player);
                    break;
                case Player.White:
                    movesList = CheckAllowedMoves(location, board, Player);
                    break;
            }
            
            return movesList;
        }

        public bool CanTakePiece(Board board, Square location, int directionOfTravel, int directionOfDiagonalTaking)
        {
            if (location.Col + directionOfDiagonalTaking >=0 && location.Col+ directionOfDiagonalTaking < 8 && 0<=location.Row + directionOfTravel && location.Row + directionOfTravel < 8 && board.GetPiece(Square.At(location.Row + directionOfTravel, location.Col + directionOfDiagonalTaking)) != null)
            {
                if (board.GetPiece(Square.At(location.Row + directionOfTravel, location.Col + directionOfDiagonalTaking)).Player != Player)
                    return true;
            }

            return false;
        }

        public List<Square> CheckAllowedMoves(Square location, Board board, Player player)
        {
            var movesList = new List<Square>();
            var playerMoves = CreatePlayerMoves(player);

            if (location.Row != playerMoves["endRow"])
            {
                if (HasMoved == false &&
                    CheckForBlockingPiece(location.Row + playerMoves["direction"], location.Col, board) &&
                    CheckForBlockingPiece(location.Row + 2*playerMoves["direction"], location.Col, board))
                    { movesList.Add(Square.At(location.Row + 2*playerMoves["direction"], location.Col));}

                if (CheckForBlockingPiece(location.Row + playerMoves["direction"], location.Col, board))
                    movesList.Add(Square.At(location.Row + playerMoves["direction"], location.Col));

                if (CanTakePiece(board, location, playerMoves["direction"],-1))
                    movesList.Add(Square.At(location.Row + playerMoves["direction"], location.Col - 1));

                if (CanTakePiece(board, location, playerMoves["direction"],1))
                    movesList.Add(Square.At(location.Row + playerMoves["direction"], location.Col + 1));
            }

            return movesList;
        }

        private Dictionary<string, int> CreatePlayerMoves(Player player)
        {
            var playerMovesDictionary = new Dictionary<string, int>();

            switch (player)
            {
                case Player.Black:
                    playerMovesDictionary.Add("endRow", 7);
                    playerMovesDictionary.Add("direction", 1);
                    break;
                case Player.White:
                    playerMovesDictionary.Add("endRow", 0);
                    playerMovesDictionary.Add("direction", -1);
                    break;
            }
            return playerMovesDictionary;
        }
    }
}