using System.Linq;
using UnityEngine;

namespace johnny.HexProject.Logic
{
    public class RectangularBoard : IBoard
    {
        private readonly Tile[,] _tiles;
        public Tile[] Tiles => _tiles.Cast<Tile>().ToArray();
        public RectangularBoard(int width, int height)
        {
            Width = width;
            Height = height;
            _tiles = new Tile[width, height];
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _tiles[i, j] = new Tile(PositionFactory.Create(new Index(i, j)), this);
                }
            }
        }
        public int Width { get; }
        public int Height { get; }
        
        public Tile GetTile(Index index)
        {
            if(index.I < 0 || index.I >= Width || index.J < 0 || index.J >= Height)
                return null;
            return _tiles[index.I, index.J];
        }

        public Tile GetRandomTile()
        {
            return _tiles[Random.Range(0, Width), Random.Range(0, Height)];
        }
    }
}