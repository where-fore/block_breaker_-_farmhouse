using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject blockDestructionParticleEffect = null;

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
        TriggerParticlesVFX();

        Destroy(gameObject);
    }

    private void TriggerParticlesVFX()
    {
        GameObject blockDestructionParticles = Instantiate(blockDestructionParticleEffect, transform.position, transform.rotation);
        Destroy(blockDestructionParticles, 2);
    }
}
