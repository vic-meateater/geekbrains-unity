using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage
{
    [SerializeField] private Texture2D _healthBar;
    [SerializeField] private Texture2D _healthBarFill;
    [SerializeField] private float _health;
    

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(20, 10, 100, 20), _healthBar);
        GUI.DrawTexture(new Rect(20, 10, _health, 20), _healthBarFill);
    }

    public void TakeDamage(int damage) => _health -= damage;

}
