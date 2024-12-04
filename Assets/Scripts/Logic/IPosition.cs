namespace johnny.HexProject.Logic
{
    /// <summary>
    /// Interface for a position in a grid.
    /// Has the basic "mathematical" operations for positions.
    /// Positions are limitless (can be negative, etc.).
    /// </summary>
    public interface IPosition
    {
        Index Index { get; }
        
        /// <summary>
        /// Distance in units
        /// </summary>
        int GetDistance(IPosition position);
        bool IsOccupied { get; set; }
        Index[] GetNeighbours();
        (float, float, float) To3D();
    }
}

