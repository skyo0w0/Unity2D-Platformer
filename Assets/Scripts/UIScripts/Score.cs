using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject scoreUI;
    private PlayerScore score;
    private TextMeshProUGUI scoreValueText;

    private void Awake()
    {
        score = player.GetComponent<PlayerScore>();
        scoreValueText = scoreUI.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        score.ScoreChanged += ChangeScore;
    }
    private void OnDisable()
    {
        score.ScoreChanged -= ChangeScore;
    }

    private void ChangeScore(int currentScore)
    {
        scoreValueText.text = currentScore.ToString();
    }
}
