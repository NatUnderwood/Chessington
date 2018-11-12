using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var movesList = new List<Square>();
            var location = board.FindPiece(this);
            if (checkIfAllowedSquare(location.Row + 1, location.Col + 2))
                movesList.Add(Square.At(location.Row + 1, location.Col+2));

            if (checkIfAllowedSquare(location.Row - 1, location.Col + 2))
                movesList.Add(Square.At(location.Row - 1, location.Col + 2));

            if (checkIfAllowedSquare(location.Row - 1, location.Col - 2))
                movesList.Add(Square.At(location.Row - 1, location.Col - 2));

            if (checkIfAllowedSquare(location.Row + 1, location.Col - 2))
                movesList.Add(Square.At(location.Row + 1, location.Col - 2));

            if (checkIfAllowedSquare(location.Row - 2, location.Col + 1))
                movesList.Add(Square.At(location.Row - 2, location.Col + 1));

            if (checkIfAllowedSquare(location.Row - 2, location.Col - 1))
                movesList.Add(Square.At(location.Row - 2, location.Col - 1));

            if (checkIfAllowedSquare(location.Row + 2, location.Col - 1))
                movesList.Add(Square.At(location.Row + 2, location.Col - 1));

            if (checkIfAllowedSquare(location.Row + 2, location.Col + 1))
                movesList.Add(Square.At(location.Row + 2, location.Col + 1));

            return movesList;
        }

        public bool checkIfAllowedSquare( int attemptedRow, int attemptedCol)
        {
            if (attemptedCol < 8 && attemptedCol >= 0 && attemptedRow < 8 && attemptedRow >= 0)
                return true;
            return false;
        }
    }
}