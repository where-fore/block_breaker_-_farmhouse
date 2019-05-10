using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public int currentScore = 0;

    [SerializeField] [Range(0, 5)]
    private float gameSpeed = 1f;
    
    private ScoreTextManager scoreTextManager = null;

    private void Start()
    {
        scoreTextManager = FindObjectOfType<ScoreTextManager>();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void ChangeSpeed(float targetSpeed)
    {
        gameSpeed = targetSpeed;
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore = currentScore + scoreToAdd;
        scoreTextManager.UpdateScoreTo(currentScore);
    }
}
