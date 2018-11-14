using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var movesList = (List<Square>)LateralPieceChecker.GetAvailableLateralMoves(board, board.FindPiece(this));
            return movesList.Concat(GetAvailableCastleMoves(board));
        }

        public List<Square> GetAvailableCastleMoves(Board board)
        {
            var movesList= new List<Square>();
            var kingLocation = FindKingStartLocation(board);
            if (CheckIfKingPresent(board, kingLocation) && CastleChecker.CheckIfCastleAllowed((King)board.GetPiece(kingLocation), this, board))
                movesList.Add(CastleChecker.FindCastleLocationDictionary((King)board.GetPiece(kingLocation), this, board)["rook"]);
            return movesList;
        }
       
        public bool CheckIfKingPresent(Board board, Square kingLocation)
        {
            return board.GetPiece(kingLocation) is King;
        }

        public Square FindKingStartLocation(Board board)
        {
            var kingLocation = new Square();
            switch (Player)
            {
                case Player.White:
                    kingLocation = Square.At(7, 4);
                    break;
                case Player.Black:
                    kingLocation = Square.At(0, 4);
                    break;
            }

            return kingLocation;
        }
    }
}