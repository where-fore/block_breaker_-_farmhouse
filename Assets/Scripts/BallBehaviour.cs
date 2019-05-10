using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Vector2 paddleToBallOffset = new Vector2();

    [SerializeField]
    PaddleBehaviour paddle = null;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallOffset = transform.position - paddle.transform.position;    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallOffset;
    }
}
