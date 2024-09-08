namespace rob.HexProject.Logic
{
    public static class PositionFactory
    {
        public static IPosition Create(Index index)
        {
            return new OddRHexPosition(index);
        }
    }
}