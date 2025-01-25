using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event EventHandler OnDied;

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

    private void TakeDamage()
    {
        _health -= _healthDecay * Time.deltaTime;
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
    }
}
