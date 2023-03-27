using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] Gradient _gradient;
    [SerializeField] private Image _fill;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetMaxHealth(float health)
    {
        _slider.maxValue = health;
        _slider.value = _slider.maxValue;
    }

    public void SetCurrentHealth(float health)
    {
        _slider.value = health;
    }

    private void Update()
    {
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
