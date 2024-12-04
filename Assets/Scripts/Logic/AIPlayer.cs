using System;
using System.Collections.Generic;
using UnityEngine;

namespace johnny.HexProject.Logic
{
    public class AIPlayer : IPlayer
    {
        private static int _nextId = 0;
        private readonly int _id;
        private readonly int _movementsPerStep;
        private readonly int _stepsPerAttack;
        private readonly int _attackRange;
        private readonly IBoard _board;
        private Tile _tile;
        
        public event Action PlayerDied;
        public bool IsAlive => Health > 0;

        public Tile Tile 
        {
            get => _tile;
            private set
            {
                if (_tile != null)
                {
                    _tile.IsOccupied = false;
                }
                _tile = value;
                _tile.IsOccupied = true;
            }
        }
        
        private int _stepsCount;
        private int _lastAttackStep;
        private int _stepsInCurrentAttack;
        public int Id => _id;
        public int Health { get; private set; }

        private AIPlayer() { }
        public AIPlayer(int movementsPerStep, int stepsPerAttack,
            int attackRange, int health, Tile startingTile, IBoard board)
        {
            _id = _nextId++;
            _movementsPerStep = movementsPerStep;
            _stepsPerAttack = stepsPerAttack;
            _attackRange = attackRange;
            Health = health;
            Tile = startingTile;
            _board = board;
            
            PlayerDied += () => Debug.Log($"Player {Id} died");
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive)
                return;
            Health -= damage;
            if(!IsAlive)
                PlayerDied?.Invoke();
        }

        public IReadOnlyList<ICommand> Step()
        {
            var commands = new List<ICommand>();
            
            if (!IsAlive)
                return commands;
            
            _stepsCount++;
            var opponent = PlayerManager.Instance.GetOpponent(this);
            var distance = Tile.Position.GetDistance(opponent.Tile.Position);
            
            for(int i = 0; i < _movementsPerStep; i++)
            {
                if (distance <= _attackRange)
                {
                    commands.Add(Attack(opponent));
                    return commands;
                }
                
                commands.Add(MoveTowards(opponent));
            }

            return commands;
        }

        private AttackCommand Attack(IPlayer opponent)
        {
            Debug.Log($"Player {ToString()} " +
                      $"attacks Player {opponent}. " +
                      $"Distance is {Tile.Position.GetDistance(opponent.Tile.Position)}");
            
            // Attacks need to be consecutive, otherwise it needs to be restarted
            if (_stepsCount - _lastAttackStep != 1)
            {
                _stepsInCurrentAttack = 0;
            }
            
            _stepsInCurrentAttack++;
            
            if (_stepsInCurrentAttack == _stepsPerAttack)
            {
                _stepsInCurrentAttack = 0;
                opponent.TakeDamage(1);
            }
            
            _lastAttackStep = _stepsCount;
            return new AttackCommand();
        }

        private MoveCommand MoveTowards(IPlayer opponent)
        {
            var position = opponent.Tile.Position;
            var nextTile = Tile.GetTileTowards(position);
            Debug.Log($"Player {ToString()} moves to {nextTile.Position.Index} " +
                      $"towards Player {opponent} " +     
                      $"New distance is {nextTile.Position.GetDistance(position)}");
            Tile = nextTile;
            return new MoveCommand();
        }

        public override string ToString()
        {
            return $"{Id} (pos:{Tile.Position.Index}, health:{Health})";
        }
    }
}