using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    // Configuration initialization
    [SerializeField]
    private float startingYVelocity = 13f;
    [SerializeField]
    private float startingXVelocity = 10f;
    [SerializeField]
    private float startingRandomTweakSize = 5f;

    [SerializeField]
    private float velocityRandomTweakSize = 0.35f;

    private bool launched = false;


    // Object reference initialization
    private LevelManager levelManager = null;
    private Rigidbody2D rigidBody2DComponent = null;


    void Start()
    {
        InitializeComponents();

        levelManager.AddTrackedBall();

        launched = false;

    /* Use me if you want the ball to launch instantly after spawning
        if (levelManager.levelStarted)
        {
            RandomlyLaunchBall();
        }
    */
    }

    void Update()
    {

    }

    void OnDestroy()
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
        launched = true;
        rigidBody2DComponent.velocity = new Vector2 (0, startingYVelocity);
    }

    public void RandomlyLaunchBall()
    {
        float randomLaunchXVelocity = Random.Range(startingXVelocity - startingRandomTweakSize, startingXVelocity + startingRandomTweakSize);
        float randomLaunchYVelocity = Random.Range(startingYVelocity - startingRandomTweakSize, startingYVelocity + startingRandomTweakSize);

        launched = true;
        rigidBody2DComponent.velocity = new Vector2 (randomLaunchXVelocity, randomLaunchYVelocity);
    }

    private void InitializeComponents()
    {
        levelManager = FindObjectOfType<LevelManager>();
        rigidBody2DComponent = GetComponent<Rigidbody2D>();
    }

    public bool isLaunched()
    {
        return launched;
    }
}
