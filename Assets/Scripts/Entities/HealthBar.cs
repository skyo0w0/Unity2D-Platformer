using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject entity;
    private Image healthBarImage;
    private Health health;

    private void Awake()
    {
        health = entity.GetComponent<Health>();
        healthBarImage = healthBar.GetComponent<Image>();
    }

    private void OnEnable()
    {
        health.HealthChanged += ChangeHealthBarFill;
    }
    private void OnDisable()
    {
        health.HealthChanged -= ChangeHealthBarFill;
    }

    public void ChangeHealthBarFill(float healthPrecent)
    {
        healthBarImage.fillAmount = healthPrecent;
    }
}
