using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;

    public void SetMaxHealth(int _health)
    {
        slider.maxValue = _health;
        slider.value = _health;
    }

    public void SetHealth(int _health)
    {
        slider.value = _health;
    }
}
