using System;
using System.Collections;
using System.Collections.Generic;
using johnny.HexProject.Logic;
using UnityEngine;
using UnityEngine.Assertions;

namespace johnny.HexProject.Visuals
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
    
        private IPlayer _player;

        public void Initialize(IPlayer player)
        {
            Assert.IsNull(_player);
            Assert.IsNotNull(player);
        
            _player = player;
            _player.PlayerDied += OnPlayerDied;
        
            _meshRenderer.material.color = player.Id % 2 == 0 ? Color.red : Color.blue;
        }

        public void Step()
        {
            var commands = _player.Step();
        }

        private void Update()
        {
            if (_player == null) return;
        
            var (x, y, z) = _player.Tile.Position.To3D();
            transform.position = new Vector3(x, y, z);
        }

        private void OnPlayerDied()
        {
            Destroy(gameObject);
        }
    }
}