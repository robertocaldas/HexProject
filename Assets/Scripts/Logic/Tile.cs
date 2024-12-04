using System.Linq;

namespace johnny.HexProject.Logic
{
    /// <summary>
    /// Tile holds a position and what is on it.
    /// Contrary to a Position, a Tile is limited by the boundaries of a Board.
    /// </summary>
    public class Tile
    {
        private readonly IBoard _board;
        public IPosition Position { get; }

        public Tile(IPosition position, IBoard board)
        {
            Position = position;
            _board = board;
        }
        
        public bool IsOccupied
        {
            get => Position.IsOccupied;
            set => Position.IsOccupied = value;
        }
        
        public Tile GetTileTowards(IPosition target)
        {
            var neighbors = Position.GetNeighbours();
            return neighbors
                .Select(index => _board.GetTile(index))
                .Where(tile => tile is { Position: { IsOccupied: false } })
                .OrderBy(tile => tile.Position.GetDistance(target))
                .FirstOrDefault();
        }
    }
}