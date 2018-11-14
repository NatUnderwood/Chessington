namespace Chessington.GameEngine.Pieces
{
    public static class OnlyTargetSquarePieceChecker
    {
        public static bool CheckIfAllowedMove(int attemptedRow, int attemptedCol, Board board)
        {
            return attemptedCol < 8 && attemptedCol >= 0 && attemptedRow < 8 && attemptedRow >= 0 && CheckIfSquareOccupied(attemptedRow, attemptedCol, board);
        }

        public static bool CheckIfSquareOccupied(int attemptedRow, int attemptedCol, Board board)
        {
            var location = Square.At(attemptedRow, attemptedCol);
            if (board.GetPiece(location) == null)
            {
                return true;
            }
            return board.GetPiece(location).Player != board.CurrentPlayer;
        }
    }
}