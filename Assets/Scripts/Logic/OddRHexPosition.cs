namespace rob.HexProject.Logic
{
    /// <summary>
    /// Odd-R Hexagon implementation of IPosition
    /// Based on https://www.redblobgames.com/grids/hexagons/
    /// </summary>
    public class OddRHexPosition : IPosition
    {
        private readonly float _dx = (float)System.Math.Sqrt(3) / 2f;
        private readonly Index[]  _neighbours;
        private int Shift => Index.J % 2;
        public OddRHexPosition(Index index)
        {
            Index = index;
            _neighbours =     new[]    {
                Add(-1, +0), // east
                Add(Shift - 1, +1), // north-east
                Add(Shift + 0,+1), // north-west
                Add(+1, +0), // west
                Add(Shift + 0, -1), // south-west
                Add(Shift - 1, -1) // south-east
            }; 
        }
        public Index Index { get; }
        public bool IsOccupied { get; set; }
        private Index Add(int i, int j)
        {
            return new Index(Index.I + i, Index.J + j);
        }
        
        private (int, int, int) OddRToCube(Index i)
        {
            var q = i.I - (i.J - (i.J & 1)) / 2;
            var r = i.J;
            return (q, r, -q - r);
        }
        
        // TODO consider occupied positions
        public int GetDistance(IPosition position)
        {
            var (q1, r1, s1) = OddRToCube(Index);
            var (q2, r2, s2) = OddRToCube(position.Index);
            return (System.Math.Abs(q1 - q2) + System.Math.Abs(r1 - r2) + System.Math.Abs(s1 - s2)) / 2;
        }
        public Index[] GetNeighbours()
        {
            return _neighbours;
        }

        public (float, float, float) To3D()
        {
            var x = _dx * Index.I * 2 + (Index.J % 2 == 0 ? 0 : _dx);
            var y = 1.5f * Index.J;
            return (x, y, 0);
        }
    }
}