using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage
{
    //VARIABLES
    [SerializeField] private Texture2D _healthBar;
    [SerializeField] private Texture2D _healthBarFill;
    [SerializeField] private float _health;

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(20, 10, 100, 20), _healthBar);
        GUI.DrawTexture(new Rect(20, 10, _health, 20), _healthBarFill);
    }

    public void TakeDamage(int _damage)
    {
        Debug.Log("Player take damage");
        _health -= _damage;
    }
}
