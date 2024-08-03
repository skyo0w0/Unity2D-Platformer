using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimplePenguinEnemyLogic : MonoBehaviour
{
    
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float damage = 25f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 velocityVector;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        velocityVector = new Vector2(speed, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        rb.velocity = velocityVector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ReverseEnemy"))
        {
            Reverse();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damageable = collision.gameObject.GetComponent<IDamagable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }

    }

    private void Reverse()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        speed *= -1;
        velocityVector = new Vector2(speed, rb.velocity.y);
    }
}
