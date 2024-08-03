using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private ShootProperties bulletProperties;
    [SerializeField] private Transform firePoint;

    public void Shoot(float direction)
    {
        Debug.Log(direction);
        int directionInt = direction >= 0 ? 1 : -1;
        ShootProperties currentBullet = Instantiate(bulletProperties, new Vector2(firePoint.parent.position.x + (0.15f * directionInt) ,firePoint.parent.position.y + 0.07f), Quaternion.identity);
        currentBullet.ShootBullet(directionInt);
    }
}
