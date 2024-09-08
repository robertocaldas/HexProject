using System.Collections.Generic;
using UnityEngine;
using rob.HexProject.Logic;
using rob.HexProject.Visuals;

namespace rob.HexProject.Game
{
    public class GamePrototype : MonoBehaviour
    {
        [SerializeField] private int _randomSeed;
        [SerializeField] private int _numberOfPlayers;
        [SerializeField] private GameObject _tilePrefab;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private int _boardWidth;
        [SerializeField] private int _boardHeight;
        
        private bool _isGameOver;
        private List<PlayerBehaviour> _playerBehaviours = new();
        
        private void Awake()
        {
            Random.InitState(_randomSeed);
            
            var board = BoardFactory.Create(_boardWidth, _boardHeight);
            PlayerManager.Instance.Initialize(_numberOfPlayers, board);
            
            InstantiateTiles(board);
            InstantiatePlayers();
        }

        private void InstantiateTiles(IBoard board)
        {
            foreach (var tile in board.Tiles)
            {
                    var tileGameObject = Instantiate(_tilePrefab);
                    tileGameObject.name = tile.Position.Index.ToString();
                    tileGameObject.GetComponent<TileBehaviour>().SetPosition(tile.Position);
            }
        }

        private void InstantiatePlayers()
        {
            foreach (var player in PlayerManager.Instance.Players)
            {
                var playerGameObject = Instantiate(_playerPrefab);
                playerGameObject.name = $"Player {player.Id}";
                var playerBehaviour = playerGameObject.GetComponent<PlayerBehaviour>();
                playerBehaviour.Initialize(player);
                _playerBehaviours.Add(playerBehaviour);

                player.PlayerDied += GameOver;
            }
        }

        private void GameOver()
        {
            Debug.Log("Game Over");
            _isGameOver = true;
        }

        private void Update()
        {
            if (_isGameOver)
                return;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Stepping...");
                foreach (var playerBehaviour in _playerBehaviours)
                {
                    playerBehaviour.Step();
                }
            }
        }
    }
}