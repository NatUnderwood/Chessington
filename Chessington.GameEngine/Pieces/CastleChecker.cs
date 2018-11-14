using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public static class CastleChecker
    {
        public static Dictionary<string, Square> FindCastleLocationDictionary(King king, Rook rook, Board board )
        {
            var kingLocation = board.FindPiece(king);
            var rookLocation = board.FindPiece(rook);
            var difference = kingLocation.Col - rookLocation.Col;
            var direction = Math.Sign(difference);
            var endLocationDict = new Dictionary<string, Square>
            {
                {"king", Square.At(kingLocation.Row, kingLocation.Col - 2 * direction)},
                {"rook", Square.At(kingLocation.Row, kingLocation.Col - direction)}
            };
            
            return endLocationDict;
        }

        public static bool CheckIfCastleAllowed(King king, Rook rook, Board board)
        {
            var kingLocation = board.FindPiece(king);
            var rookLocation = board.FindPiece(rook);
            var difference = kingLocation.Col - rookLocation.Col;
            var direction = Math.Sign(difference);
            if (!king.HasMoved && !rook.HasMoved)
            {
                for (var col = rookLocation.Col+direction; col < kingLocation.Col; col +=direction)
                {
                    if (board.GetPiece(Square.At(rookLocation.Row, col)) != null)
                    {
                        return false;
                    }  
                }
                return true;
            }
            return false;
        }
    }
}