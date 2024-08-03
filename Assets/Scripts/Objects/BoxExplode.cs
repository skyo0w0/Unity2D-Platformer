using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxExplode : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float explosionDuration = 0.5f;

    private void OnDestroyAnimationStart()
    {
        GameObject explotionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explotionEffect, explosionDuration);
        Destroy(gameObject,explosionDuration);
    }

}



