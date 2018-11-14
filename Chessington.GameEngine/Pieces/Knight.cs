using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            int[,] potentialMovesArray = {{1, 2}, {-1, 2}, {-1, -2},{ 1,-2},{-2, 1},{-2, -1},{2, -1},{2, 1}};
            var movesList = new List<Square>();
            var location = board.FindPiece(this);
            for (var line = 0; line <8; line++)
            {
                if(OnlyTargetSquarePieceChecker.CheckIfAllowedMove(location.Row + potentialMovesArray[line,0], location.Col + potentialMovesArray[line, 1], board))
                movesList.Add(Square.At(location.Row + potentialMovesArray[line, 0], location.Col + potentialMovesArray[line, 1]));
            }
            return movesList;
        }
    }
}