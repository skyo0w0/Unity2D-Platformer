using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour, IScore
{
    public event Action<int> ScoreChanged;

    [SerializeField] private int _score;
    [SerializeField] public int currentScore 
    { get => _score; 
      set 
        {
            if (_score != value)
            {
                _score = value;
                ScoreChanged?.Invoke(_score);
            }
        } 
    }

    private void Awake()
    {
        currentScore = 0;
    }
    public void AddScore(int score)
    {
        currentScore += score;
    }
}
