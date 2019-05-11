using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    // Configuration initialization
    [SerializeField]
    private float startingYVelocity = 10f;
    [SerializeField]
    private float startingXVelocity = 10f;
    [SerializeField]
    private float startingRandomTweakSize = 5f;

    [SerializeField]
    private float velocityRandomTweakSize = 0.3f;

    // Config
    public Vector2 startingPosition = new Vector2(0, 0);


    // Object reference initialization
    private LevelManager levelManager = null;
    private Rigidbody2D rigidBody2DComponent = null;


    void Start()
    {
        InitializeComponents();
        startingPosition = new Vector2(transform.position.x, transform.position.y);

        levelManager.AddTrackedBall();

        rigidBody2DComponent.bodyType = RigidbodyType2D.Kinematic;

        if (levelManager.levelStarted)
        {
            RandomlyLaunchBall();
        }
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TweakVelocity();
    }

    private void TweakVelocity()
    {
        float randomXVelocity = Random.Range(-velocityRandomTweakSize, velocityRandomTweakSize);
        float randomYVelocity = Random.Range(-velocityRandomTweakSize, velocityRandomTweakSize);

        Vector2 velocityTweak = new Vector2(randomXVelocity, randomYVelocity);
        rigidBody2DComponent.velocity = rigidBody2DComponent.velocity + velocityTweak;
    }

    public void LauchBall()
    {
        Debug.Log("Ball Launched");
        rigidBody2DComponent.bodyType = RigidbodyType2D.Dynamic;
        rigidBody2DComponent.velocity = new Vector2 (0, startingYVelocity);
    }

    public void RandomlyLaunchBall()
    {
        Debug.Log("Ball Randomly Launched");
        rigidBody2DComponent.bodyType = RigidbodyType2D.Dynamic;
        float randomLaunchXVelocity = Random.Range(startingXVelocity - startingRandomTweakSize, startingXVelocity + startingRandomTweakSize);
        float randomLaunchYVelocity = Random.Range(startingYVelocity - startingRandomTweakSize, startingYVelocity + startingRandomTweakSize);

        rigidBody2DComponent.velocity = new Vector2 (randomLaunchXVelocity, randomLaunchYVelocity);
    }

    private void InitializeComponents()
    {
        levelManager = FindObjectOfType<LevelManager>();
        rigidBody2DComponent = GetComponent<Rigidbody2D>();
    }
}
