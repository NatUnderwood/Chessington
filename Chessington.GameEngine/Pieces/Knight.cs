using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            if (CheckIfSquareExistingAndNotOccupiedByPlayer(location.Row + 1, location.Col + 2, board))
                movesList.Add(Square.At(location.Row + 1, location.Col+2));

            if (CheckIfSquareExistingAndNotOccupiedByPlayer(location.Row - 1, location.Col + 2, board))
                movesList.Add(Square.At(location.Row - 1, location.Col + 2));

            if (CheckIfSquareExistingAndNotOccupiedByPlayer(location.Row - 1, location.Col - 2, board))
                movesList.Add(Square.At(location.Row - 1, location.Col - 2));

            if (CheckIfSquareExistingAndNotOccupiedByPlayer(location.Row + 1, location.Col - 2, board))
                movesList.Add(Square.At(location.Row + 1, location.Col - 2));

            if (CheckIfSquareExistingAndNotOccupiedByPlayer(location.Row - 2, location.Col + 1, board))
                movesList.Add(Square.At(location.Row - 2, location.Col + 1));

            if (CheckIfSquareExistingAndNotOccupiedByPlayer(location.Row - 2, location.Col - 1, board))
                movesList.Add(Square.At(location.Row - 2, location.Col - 1));

            if (CheckIfSquareExistingAndNotOccupiedByPlayer(location.Row + 2, location.Col - 1, board))
                movesList.Add(Square.At(location.Row + 2, location.Col - 1));

            if (CheckIfSquareExistingAndNotOccupiedByPlayer(location.Row + 2, location.Col + 1, board))
                movesList.Add(Square.At(location.Row + 2, location.Col + 1));

            return movesList;
        }

        public bool CheckIfSquareExistingAndNotOccupiedByPlayer( int attemptedRow, int attemptedCol, Board board)
        {
            var location = Square.At(attemptedRow, attemptedCol);
            if (attemptedCol < 8 && attemptedCol >= 0 && attemptedRow < 8 && attemptedRow >= 0 && CheckIfSquareOccupied(attemptedRow,attemptedCol,board))
                return true;
            return false;
        }

        public bool CheckIfSquareOccupied(int attemptedRow, int attemptedCol, Board board)
        {
            var location = Square.At(attemptedRow, attemptedCol);
            if (board.GetPiece(location) == null)
            {
                return true;
            }
            if (board.GetPiece(location).Player != board.CurrentPlayer)
                return true;
            return false;
        }
    }
}