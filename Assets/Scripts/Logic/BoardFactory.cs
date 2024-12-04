namespace johnny.HexProject.Logic
{
    public static class BoardFactory
    {
        public static IBoard Create(int width, int height)
        {
            return new RectangularBoard(width, height);
        }
    }
}