namespace johnny.HexProject.Logic
{
    /// <summary>
    /// A board shapes the game world, offering boundaries to the tiles.
    /// </summary>
    public interface IBoard
    {
        Tile[] Tiles { get; }
        Tile GetTile(Index index);
        Tile GetRandomTile();
    }
}