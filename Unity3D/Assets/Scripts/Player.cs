using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage
{
    //VARIABLES
    [SerializeField] private Texture2D _healthBar;
    [SerializeField] private Texture2D _healthBarFill;
    [SerializeField] private Sprite _healthBarFillSprite;
    [SerializeField] private float _health;
    [SerializeField] Color _myColor;
    

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(20, 10, 100, 20), _healthBar);
        GUI.DrawTexture(new Rect(20, 10, _health, 20), _healthBarFill);
        _myColor = RGBSlider(new Rect(10, 10, 200, 20), _myColor);


    }
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        screenRect.y += 50;
        rgb.r = LabelSlider(screenRect, rgb.r, 0f, 1.0f, "Red");
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 0f, 1.0f, "Green");
        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 0f, 1.0f, "Blue");
        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 0f, 1.0f, "Alpha");
        return rgb;
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, sliderMinValue, sliderMaxValue);
        return sliderValue;
    }

    public void TakeDamage(int _damage)
    {
        Debug.Log("Player take damage");
        _health -= _damage;
    }
}
