using System;
using UnityEngine;

namespace BananaMan
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private int _countBonuses;

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            _displayEndGame = new DisplayEndGame();
            _displayBonuses = new DisplayBonuses();
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
            }
        }
        private void CaughtPlayer(string value, Color args)
        {
            Time.timeScale = 0.0f;
        }

        private void AddBonus(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }
        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];
                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
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
            }
        }
    }
}