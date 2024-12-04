namespace johnny.HexProject.Logic
{
    public static class PlayerFactory
    {
        public static IPlayer CreateAIPlayer(int movementsPerStep, int stepsPerAttack,
            int attackRange, int health, Tile startingTile, IBoard board)
        {
            return new AIPlayer(movementsPerStep, stepsPerAttack, attackRange, health, startingTile, board);
        }
    }
}