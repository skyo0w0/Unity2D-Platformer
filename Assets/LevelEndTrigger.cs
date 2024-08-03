using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndTrigger : MonoBehaviour
{
    [SerializeField] PlayerScore score;
    [SerializeField] int MaxScore = 300;
    [SerializeField] GameObject LevelEndUI;
    [SerializeField] TextMeshProUGUI scoreValueText;
    [SerializeField] Image FirstHeart;
    [SerializeField] Image SecondHeart;
    [SerializeField] Image ThirdHeart;
    [SerializeField] Sprite FullHeartImage;
    [SerializeField] GameObject PauseButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<PlayerMovement>() != null)
        {
            Debug.Log("true");
            Time.timeScale = 0;
            CalculateFullHearts();
            PauseButton.SetActive(false);
            LevelEndUI.SetActive(true);
        }
    }

    private void CalculateFullHearts()
    {
        scoreValueText.text = score.currentScore.ToString();
        if (score.currentScore >= MaxScore * 1/3)
        {
            FirstHeart.sprite = FullHeartImage;
        }
        if (score.currentScore >= MaxScore * 2 / 3)
        {
            SecondHeart.sprite = FullHeartImage;
        }
        if (score.currentScore >= MaxScore)
        {
            ThirdHeart.sprite = FullHeartImage;
        }
    }

}
