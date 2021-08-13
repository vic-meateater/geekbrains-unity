using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, ITakeDamage
{
    //VARIABLES
    //[SerializeField] GameObject _player;
    [SerializeField] private int _maxHP = 250;
    [SerializeField] private int _maxAmmo = 100;
    [SerializeField] private int _hp;
    [SerializeField] private int _ammo;
    [SerializeField] private TextMeshProUGUI _ammoCounter;
    [SerializeField] private TextMeshProUGUI _playerStatus;
    [SerializeField] private GameObject _playerStatusMenu;


    //REFERENCES
    public HealthBar _healthBar;
    
    private void Awake()
    {
        _hp = _maxHP;
        _ammo = _maxAmmo;
        _healthBar.SetMaxHealth(_hp);
        _ammoCounter.text = _ammo.ToString();

    }

    public void HealBoxPickUp(int _heal)
    {
        _hp += _heal;
        if(_hp >= _maxHP)
        {
            _hp = _maxHP;
        }
        _healthBar.SetHealth(_hp);
    }

    public void AmmoBoxPickUp(int _pickedAmmo)
    {
        _ammo += _pickedAmmo;
        _ammoCounter.text = _ammo.ToString();
    }

    public void TakeDamage(int _damage)
    {
        Debug.Log("Player take damage");
        _hp -= _damage;
        _healthBar.SetHealth(_hp);
        if (_hp <= 0)
        {
            StatusMenu();
        }
    }

    public void UpdateAmmo(int value)
    {
        _ammo -= value;
        _ammoCounter.text = _ammo.ToString();
    }

    private void StatusMenu()
    {
        Time.timeScale = 0f;
        _playerStatusMenu.SetActive(true);
        _playerStatus.text = "You DIE!!";
        Cursor.lockState = CursorLockMode.Confined;
    }
}
