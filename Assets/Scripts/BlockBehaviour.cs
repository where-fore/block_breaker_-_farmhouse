using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField]
    private int scoreWorth = 50;

    private LevelManager levelManager = null;

    private GameStatus gameStatusManager = null;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        gameStatusManager = FindObjectOfType<GameStatus>();

        levelManager.AddTrackedBlock();
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        gameStatusManager.AddScore(scoreWorth);
        levelManager.RemoveTrackedBlock();
        Destroy(gameObject);
    }
}
