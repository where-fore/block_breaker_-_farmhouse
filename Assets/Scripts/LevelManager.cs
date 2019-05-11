using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public bool levelStarted = false;

    private int blocksTracked = 0;

    private int ballsTracked = 0;

    private SceneLoader sceneLoaderManager = null;

    private void Start()
    {
        sceneLoaderManager = FindObjectOfType<SceneLoader>();
    }

    private void Update()
    {
        if (blocksTracked == 0 && levelStarted)
        {   
            WinLevel();
        }
    }

    public void StartLevel()
    {
        levelStarted = true;
    }

    public void AddTrackedBlock()
    {
        blocksTracked ++;
    }

    public void RemoveTrackedBlock()
    {
        blocksTracked --;
    }

    public void AddTrackedBall()
    {
        ballsTracked ++;
    }

    public void RemoveTrackedBall()
    {
        ballsTracked --;
    }

    public bool CheckIfZeroBalls()
    {
        bool answer = (ballsTracked == 0);
        return answer;
    }


    public void WinLevel()
    {
        sceneLoaderManager.LoadNextScene();
        levelStarted = false;
    }

    public void LoseLevel()
    {
        sceneLoaderManager.LoadGameOver();
        levelStarted = false;
    }
}
