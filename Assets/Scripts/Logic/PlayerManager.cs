using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;
namespace johnny.HexProject.Logic
{
    /// <summary>
    /// Creates and provides access to players.
    /// </summary>
    public class PlayerManager
    {
        public static PlayerManager Instance { get; private set; }
        private PlayerManager() { }
        static PlayerManager()
        {
            Instance = new PlayerManager();
        }
        
        public List<IPlayer> Players { get; } = new();

 
        public void Initialize(int numberOfPlayers, IBoard board)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Tile tile;
                do
                {
                    tile = board.GetRandomTile();
                } while (tile.IsOccupied);
                
                int movementsPerStep = 1;
                int stepsPerAttack = 2;
                int attackRange = 3;
                int health = Random.Range(2, 6);
                
                var player = PlayerFactory.CreateAIPlayer(movementsPerStep, 
                    stepsPerAttack, attackRange, health, tile, board);

                Players.Add(player);
            }
        }
        
        public IPlayer GetOpponent(IPlayer player)
        {
            // odd vs even:
            return Players
                .Where(p => p.Id % 2 != player.Id % 2)
                .OrderBy(p => player.Tile.Position.GetDistance(p.Tile.Position))
                .FirstOrDefault();
        }
    }
}