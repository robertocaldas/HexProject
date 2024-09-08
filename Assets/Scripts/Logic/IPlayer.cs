using System;
using System.Collections.Generic;

namespace rob.HexProject.Logic
{
    public interface IPlayer
    {
        int Id { get; }
        // TODO public setter for Tile?
        Tile Tile { get; }
        int Health { get; }
        void TakeDamage(int damage);
        IReadOnlyList<ICommand> Step();
        bool IsAlive { get; }
        event Action PlayerDied;
    }
}