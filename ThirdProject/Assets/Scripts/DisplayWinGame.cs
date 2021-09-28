using System;
using UnityEngine;
using UnityEngine.UI;

namespace BananaMan
{
    public sealed class DisplayWinGame
    {
        private Text _winGameText;

        public DisplayWinGame(GameObject winGame)
        {
            _winGameText = winGame.GetComponentInChildren<Text>();
            _winGameText.text = String.Empty;
        }

        public void WinGame()
        {
            _winGameText.text = $"Вы выиграли!";
        }
    }
}