using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    private LevelManager levelManager = null;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

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
        levelManager.RemoveTrackedBlock();
        Destroy(gameObject);
    }
}
