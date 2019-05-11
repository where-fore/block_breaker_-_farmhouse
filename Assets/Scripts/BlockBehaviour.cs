using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    // Serialized Fields
    [SerializeField]
    private int scoreWorth = 50;

    int maxHits = 0;

    // Config Fields
    [SerializeField]
    private Sprite[] damageLevelSprites = null;

    [SerializeField]
    private GameObject blockDestructionParticleEffect = null;

    // Initialization parameters
    int timesHit = 0;
    private string playerTag = "Player";
    private string unbreakableBlockTag = "Unbreakable";
    private LevelManager levelManager = null;
    private GameStatus gameStatusManager = null;
    private SpriteRenderer damageSpriteRenderer = null;
    private string nameOfDamageObject = "Cracks";

    private void Start()
    {
        gameStatusManager = FindObjectOfType<GameStatus>();
        FindDamageSpriteRenderer();

        CheckToTrackBlock();

        maxHits = damageLevelSprites.Length + 1;
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
        else
        {
            DamageBlock();
        }
    }

    private void DamageBlock()
    {
        int damageSpriteArrayIndex = Mathf.Clamp(timesHit - 1, 0, damageLevelSprites.Length);
        Sprite nextSprite = damageLevelSprites[damageSpriteArrayIndex];
        damageSpriteRenderer.sprite = nextSprite;
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

    private void FindDamageSpriteRenderer()
    {
        Transform childTransform = gameObject.transform.Find(nameOfDamageObject);

        damageSpriteRenderer = childTransform.gameObject.GetComponent<SpriteRenderer>();
    }

}
