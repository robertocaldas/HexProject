namespace johnny.HexProject.Logic
{
    // TODO if we implement random and logger interfaces, we can remove Unity from the assembly
    // TODO if all boards can be stored in a rectangular grid, maybe this is too overkill
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