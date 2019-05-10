using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Vector2 paddleToBallOffset = new Vector2();

    [SerializeField]
    PaddleBehaviour paddle = null;

    private bool gameStarted = false;

    private float startingYVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallOffset = transform.position - paddle.transform.position;    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            SnapBallToPaddle();
        }

        if (!gameStarted && Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameStarted = true;
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
