using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage = 25f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamagable damageable = other.GetComponent<IDamagable>();
        Debug.Log(damageable);
        if (damageable != null )
        {
            damageable.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
