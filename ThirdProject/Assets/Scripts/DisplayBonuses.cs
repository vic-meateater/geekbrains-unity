using UnityEngine;
using UnityEngine.UI;
namespace BananaMan
{
    public sealed class DisplayBonuses: IView
    {
        private Text _text;
        private int _point;

        public DisplayBonuses()
        {
            //
        }

        public void Display(int value)
        {
            _point += value;
            _text.text = $"Вы набрали {_point} бонусов.";
        }
    }
}