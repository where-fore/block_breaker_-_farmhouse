using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    // Configuration initialization
    private float startingYVelocity = 10f;


    // Variable initialization
    private Vector2 paddleToBallOffset = new Vector2();


    // Object reference initialization
    private LevelManager levelManager = null;
    
    PaddleBehaviour paddle = null;

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<PaddleBehaviour>();
        paddleToBallOffset = transform.position - paddle.transform.position;
        levelManager = FindObjectOfType<LevelManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!levelManager.levelStarted)
        {
            SnapBallToPaddle();
        }

        if (!levelManager.levelStarted && Input.GetKeyDown(KeyCode.Mouse0))
        {
            levelManager.StartLevel();
            LauchBall();
        }
    }

    private void LauchBall()
    {
        float launchYVelocity = startingYVelocity;
        float launchXVelocity = paddle.GetComponent<Rigidbody2D>().velocity.x;

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (launchXVelocity, launchYVelocity);
    }

    private void SnapBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallOffset;
    }
}
