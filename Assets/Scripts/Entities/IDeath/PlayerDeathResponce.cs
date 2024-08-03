using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathResponce : MonoBehaviour, IDeathResponce
{
    [SerializeField] GameObject deathMessagePanel;
    [SerializeField] GameObject pauseButton;

    public void OnDeath()
    {
        pauseButton.SetActive(false);
        GetComponent<Animator>().SetBool("isKnocked", true);
    }

    public void OnKnockedAnimationEnds()
    {
        Time.timeScale = 0;
        deathMessagePanel.SetActive(true);
    }
}
