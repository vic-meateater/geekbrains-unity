using System;
using UnityEngine;
using UnityEngine.UI;

namespace BananaMan
{
    public sealed class DisplayEndGame
    {
        private Text _endGameText;

        public DisplayEndGame(GameObject endGame)
        {
            _endGameText = endGame.GetComponentInChildren<Text>();
            _endGameText.text = String.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _endGameText.text = $"Вы проиграли.";
        }

    }
}