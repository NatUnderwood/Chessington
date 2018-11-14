using System.Collections.Generic;
using System.Linq;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public static class CheckChecker
    {
        public static bool CheckIfBoardInCheck(Board board)
        {
            var boardstate = board.FindBoardState();
            var ownKingLocation = findOwnKingLocation(board, boardstate);


            for (var row = 0; row < GameSettings.BoardSize; row++)
            {
                for (var col = 0; col < GameSettings.BoardSize; col++)
                {
                    if (boardstate[row, col].GetAvailableMoves(board).Contains(ownKingLocation))
                        return true;
                }
            }

            return false;
        }

        private static Square findOwnKingLocation(Board board, Piece[,] boardstate)
        {
            var kingSquare = new Square();
            for (var row = 0; row < GameSettings.BoardSize; row++)
            {
                for (var col = 0; col < GameSettings.BoardSize; col++)
                {
                    if (boardstate[row, col] is King && boardstate[row, col].Player == board.CurrentPlayer)
                        kingSquare = Square.At(row, col);
                }
            }

            return kingSquare;
        }
    }
}