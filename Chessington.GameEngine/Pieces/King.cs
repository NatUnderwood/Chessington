using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            int[,] potentialMovesArray = { { 1, 1 }, { -1, 1 }, { -1, -1 }, { 1, -1 }, { 0,-1 }, { -1, 0 }, { 1, 0 }, { 0, 1 } };
            var movesList = new List<Square>();
            var location = board.FindPiece(this);

            for (var line = 0; line < 8; line++)
            {
                if (OnlyTargetSquarePieceChecker.CheckIfAllowedMove(location.Row + potentialMovesArray[line,0], location.Col + potentialMovesArray[line, 1], board))
                    movesList.Add(Square.At(location.Row + potentialMovesArray[line, 0], location.Col + potentialMovesArray[line, 1]));
            }
            return movesList.Concat(GetAvailableCastleMoves(board));
        }

        public List<Square> GetAvailableCastleMoves(Board board)
        {
            var movesList = new List<Square>();
            var rookLocations = FindRookStartLocations(board);

            for (var rookNumber = 0; rookNumber < 2; rookNumber++)
            {
                if (CheckIfRookPresent(board, rookLocations[rookNumber]) && CastleChecker.CheckIfCastleAllowed(this, (Rook)board.GetPiece(rookLocations[rookNumber]), board))
                {
                    movesList.Add(CastleChecker.FindCastleLocationDictionary(this, (Rook)board.GetPiece(rookLocations[rookNumber]), board)["king"]);
                }
            }
            return movesList;
        }

        public bool checkIfCastleMove(Board board, Square newSquare)
        {
            return GetAvailableCastleMoves(board).Contains(newSquare);
        }

        public bool CheckIfRookPresent(Board board, Square rook)
        {
            return board.GetPiece(rook) is Rook;
        }

        public Square[] FindRookStartLocations(Board board)
        {
            var rookLocation = new Square[2];
            switch (Player)
            {
                case Player.White:
                    rookLocation[0] = Square.At(7, 0);
                    rookLocation[1] = Square.At(7, 7);
                    break;
                case Player.Black:
                    rookLocation[0] = Square.At(0, 0);
                    rookLocation[1] = Square.At(0, 7);
                    break;
            }

            return rookLocation;
        }
        public override void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            if (checkIfCastleMove(board, newSquare))
            {
                var direction = Math.Sign(currentSquare.Col - newSquare.Col);
                var rookOldSquare = new Square();
                switch (direction)
                {
                    case -1:
                        rookOldSquare = Square.At(newSquare.Row, 7);
                        break;
                    case 1:
                        rookOldSquare = Square.At(newSquare.Row, 0);
                        break;
                }

                var rookNewSquare = Square.At(newSquare.Row, newSquare.Col + direction);
                board.MovePiece(rookOldSquare, rookNewSquare);
                board.CurrentPlayer = board.CurrentPlayer == Player.White ? Player.Black : Player.White;

            }
            board.MovePiece(currentSquare, newSquare);
            HasMoved = true;
        }
    }
}