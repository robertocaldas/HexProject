using System;

namespace rob.HexProject.Logic
{
    /// <summary>
    /// Basic struct that represents the identifier for a position in a grid.
    /// </summary>
    public struct Index : IEquatable<Index>
    {
        public Index(int i, int j)
        {
            I = i;
            J = j;
        }
        public int I { get; }
        public int J { get; }
        
        public bool Equals(Index other)
        {
            return I == other.I && J == other.J;
        }
        
        public override string ToString()
        {
            return $"[{I}, {J}]";
        }
    }
}