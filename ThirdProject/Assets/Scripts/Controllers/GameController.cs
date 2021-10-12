using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BananaMan
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private DisplayWinGame _displayWinGame;
        private CameraController _cameraController;
        private InputController _inputController;
        private Player _player;
        private List<int> _countBonuses = new List<int>();
        private int _maxBonuses = 4;
        private Reference _reference;
        private MiniMap _miniMap;
        
        
        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();

            _reference = new Reference();
            
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);
            _displayWinGame = new DisplayWinGame(_reference.WinGame);
            
            _cameraController = new CameraController(_reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _player = FindObjectOfType<Player>();
            _inputController = new InputController(_player, _interactiveObject);
            _interactiveObject.AddExecuteObject(_inputController);

            //_miniMap = new MiniMap(_player.transform);
            //_interactiveObject.AddExecuteObject(_miniMap);
            
            foreach (var interactiveObject in _interactiveObject)
            {
                if (interactiveObject is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }
                
                if (interactiveObject is WinBonus winBonus)
                {
                    winBonus.OnPointChanged += AddBonus;
                }

                if (interactiveObject is GoodBonus goodBonus)
                {
                    goodBonus.OnSpeedChanged += AddSpeed;
                }
            }
            
            _reference.RestartButton.onClick.AddListener(() => RestartGame());
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void AddSpeed(int value)
        {
            _player.SpeedUp(value);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0); 
            Time.timeScale = 1.0f;
        }

        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddBonus(int value)
        {
            _countBonuses.Add(value);
            _displayBonuses.Display(value);
            if (_countBonuses.Count >= _maxBonuses) WinGame();
        }

        private void WinGame()
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            _displayWinGame.WinGame();
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];
                interactiveObject?.Execute();
            }
        }
        
        public void Dispose()
        {
            foreach (var interactiveObject in _interactiveObject)
            {
                if (interactiveObject is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }
            
                if (interactiveObject is WinBonus winBonus)
                {
                    winBonus.OnPointChanged -= AddBonus;
                }
                
                if (interactiveObject is GoodBonus goodBonus)
                {
                    goodBonus.OnSpeedChanged-= AddSpeed;
                }
            }
        }
    }
}