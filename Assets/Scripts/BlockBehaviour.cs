using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject blockDestructionParticleEffect = null;

    [SerializeField]
    private int scoreWorth = 50;

    [SerializeField]
    int timesHit = 0;

    [SerializeField]
    int maxHits = 2;


    // Initialization parameters

    private string playerTag = "Player";

    private string unbreakableBlockTag = "Unbreakable";

    private LevelManager levelManager = null;

    private GameStatus gameStatusManager = null;

    private void Start()
    {
        gameStatusManager = FindObjectOfType<GameStatus>();

        CheckToTrackBlock();
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == playerTag && gameObject.tag != unbreakableBlockTag)
        {
            HitBlock();
        }
    }

    private void HitBlock()
    {
        timesHit ++;
        if (timesHit >= maxHits)
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

    private void CheckToTrackBlock()
    {
        levelManager = FindObjectOfType<LevelManager>();
        if (tag != unbreakableBlockTag)
        {
            levelManager.AddTrackedBlock();
        }
    }

}
