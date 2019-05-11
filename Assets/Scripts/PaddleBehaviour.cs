using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    private float aspectRatio = (4f/3f);

    private float halfOfPaddleWidth = 2f/2f;

    private Vector2 paddleStartingPosition = new Vector2(0,0);

    private LevelManager levelManager = null;
    private BallBehaviour[] startingBalls = null;

    // Start is called before the first frame update
    void Start()
    {
        InitializeComponents();
        paddleStartingPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        SnapPaddleToMouse();


        if (!levelManager.levelStarted)
        {
            foreach (BallBehaviour ball in startingBalls)
            {
                SnapBallToPaddle(ball, ball.startingPosition);
            }
        }

        if (!levelManager.levelStarted && Input.GetKeyDown(KeyCode.Mouse0))
        {
            levelManager.StartLevel();
            foreach (BallBehaviour ball in startingBalls)
            {
                ball.LauchBall();
            }
        }
    }

    private void SnapBallToPaddle(BallBehaviour ball, Vector2 ballStartingPosition)
    {
        Vector2 ballStartingVector = new Vector2(ballStartingPosition.x - paddleStartingPosition.x, ballStartingPosition.y - paddleStartingPosition.y);

        float paddleXposition = transform.position.x;
        float paddleYposition = transform.position.y;

        Vector2 positionToSnapTo = new Vector2(paddleXposition + ballStartingVector.x, paddleYposition + ballStartingVector.y);

        ball.transform.position = positionToSnapTo;
    }

    private void SnapPaddleToMouse()
    {
        float screenHeightInUnits = Camera.main.orthographicSize * 2;
        float screenWidthInUnits = screenHeightInUnits * aspectRatio;

        float mouseXCoordinate = Input.mousePosition.x / (Screen.width / screenWidthInUnits);

        float screenMinX = 0f + halfOfPaddleWidth;
        float screenMaxX = screenWidthInUnits - halfOfPaddleWidth;
        float mouseXCoordinateInScreenBounds = Mathf.Clamp(mouseXCoordinate, screenMinX, screenMaxX);
        

        transform.position = new Vector2 (mouseXCoordinateInScreenBounds, transform.position.y);
    }

    private void InitializeComponents()
    {
        startingBalls = FindObjectsOfType<BallBehaviour>();
        levelManager = FindObjectOfType<LevelManager>();
    }
}
