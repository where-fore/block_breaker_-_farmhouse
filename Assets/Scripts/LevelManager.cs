using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    public GameObject startingBall = null;

    private float startingBallVerticalOffset = 0f;

    [SerializeField]
    public bool loseGameIfLastBallCollides = true;

    public bool levelStarted = false;

    public int blocksTracked = 0;

    public int ballsTracked = 0;

    public int maxBalls = 5;

    private SceneLoader sceneLoaderManager = null;

    private PaddleBehaviour paddle = null;
    
    public List<BallBehaviour> allBalls = null;

    private void Start()
    {
        sceneLoaderManager = FindObjectOfType<SceneLoader>();
        startingBallVerticalOffset = startingBall.transform.position.y;
        paddle = FindObjectOfType<PaddleBehaviour>();

        allBalls = new List<BallBehaviour>();
        foreach (BallBehaviour ball in FindObjectsOfType<BallBehaviour>())
        {
            allBalls.Add(ball);
        }
    }

    private void Update()
    {
        if (blocksTracked == 0 && levelStarted)
        {   
            WinLevel();
        }

        if (ballsTracked == 0 && !loseGameIfLastBallCollides)
        {
            RespawnBall();
        }
    }

    public void RespawnBall()
    {
        Vector2 paddlePos = paddle.transform.position;
        Vector2 targetPos = new Vector2(paddlePos.x, paddlePos.y + startingBallVerticalOffset);

        GameObject newBall = Instantiate(startingBall, targetPos, startingBall.transform.rotation);
        allBalls.Add(newBall.GetComponent<BallBehaviour>());
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

    public void RemoveTrackedBall(BallBehaviour ballToRemove)
    {
        ballsTracked --;
        allBalls.Remove(ballToRemove);
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
