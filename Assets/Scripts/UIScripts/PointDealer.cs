using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDealer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int points = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IScore score = other.GetComponentInParent<IScore>();
        Debug.Log(other.GetComponentInParent<IScore>());
        Debug.Log(score);
        if (score != null)
        {
            score.AddScore(points);
            Destroy(gameObject);
        }
    }
}
