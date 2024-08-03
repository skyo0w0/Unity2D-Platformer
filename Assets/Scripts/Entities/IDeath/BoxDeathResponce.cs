using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDeathResponce :MonoBehaviour, IDeathResponce
{
    public void OnDeath()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Animator>().SetBool("isDamaged", true);
    }
}
