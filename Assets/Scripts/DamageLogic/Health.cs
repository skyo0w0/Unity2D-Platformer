using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour , IDamagable
{
    public event Action<float> HealthChanged;

    private List<IDeathResponce> deathResponses = new List<IDeathResponce>();
    [SerializeField] private float maxHealth = 100f ;
    private float _health;
    [SerializeField] public float currentHealth
    {
        get => _health;
        set
        {
            if (_health != value)
            {
                _health = value;
                HealthChanged?.Invoke(_health/maxHealth);
                if (_health <= 0 )
                {
                    NotifyDeath();
                }
            }
        }
    }
    private bool isAlive => currentHealth > 0;

    private void Awake()
    {
        currentHealth = maxHealth;
        deathResponses.AddRange(GetComponents<IDeathResponce>());
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    private void NotifyDeath()
    {
        foreach (var responder in deathResponses)
        {
            responder.OnDeath();
        }
    }
}
