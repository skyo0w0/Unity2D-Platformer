using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProperties : MonoBehaviour
{
    [SerializeField] private float fireSpeed = 2f;
    private Rigidbody2D booletRb;

    void Awake()
    {
        booletRb = GetComponent<Rigidbody2D>();
    }

    public void ShootBullet(int directionInt)
    {
        booletRb.velocity = new Vector2(fireSpeed * directionInt, booletRb.velocity.y);
        GetComponent<SpriteRenderer>().flipX = directionInt < 0;
        Destroy(gameObject, 2);
    }
}
