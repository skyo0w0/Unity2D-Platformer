using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathResponce : MonoBehaviour, IDeathResponce
{
    public void OnDeath()
    {
        Destroy(gameObject);
    }

}
