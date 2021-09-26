using System;
using UnityEngine;
using UnityEngine.UI;
namespace BananaMan
{
    public sealed class DisplayBonuses
    {
        private Text _goodBonusesText;
        private int _point;

        public DisplayBonuses(GameObject goodBonus)
        {
            _goodBonusesText = goodBonus.GetComponentInChildren<Text>();
            _goodBonusesText.text = String.Empty;
        }

        public void Display(int value)
        {
            _point += value;
            _goodBonusesText.text = $"Вы набрали {_point} бонусов.";
        }
    }
}