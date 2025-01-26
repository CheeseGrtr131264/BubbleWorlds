using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event EventHandler OnDied;
    public event EventHandler <Health>OnHealthChanged;

    [SerializeField] private float _maxHealth = 20.0f;
    [SerializeField] private float _healthDecay = 1.0f;

    public float _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void LightDetector_OnLightChecked(object sender, bool isInLightSource)
    {
        if (isInLightSource)
        {
            Heal();
        }
        else
        {
            TakeDamage();
        }
    }

    public void IncreaseMaxHealth(float amount)
    {
        float beforeHealthPercentage = _health / _maxHealth;
        _maxHealth += amount;
        _health = _health + 1 * beforeHealthPercentage;
        OnHealthChanged?.Invoke(this, this);
    }

    private void TakeDamage()
    {
        _health -= _healthDecay * Time.deltaTime;
        OnHealthChanged?.Invoke(this, this);
        if (_health <= 0.0f)
        {
            OnDied?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Heal()
    {
        _health += Time.deltaTime * _maxHealth;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        OnHealthChanged?.Invoke(this, this);
    }
}
