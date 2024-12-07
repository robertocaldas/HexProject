using System;
using System.Collections.Generic;

namespace johnny.HexProject.Logic
{
    public interface IPlayer
    {
        int Id { get; }
        Tile Tile { get; }
        int Health { get; }
        void TakeDamage(int damage);
        IReadOnlyList<ICommand> Step();
        bool IsAlive { get; }
        event Action PlayerDied;
    }
}