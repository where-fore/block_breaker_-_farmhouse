using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private SceneLoader sceneLoaderScript = null;

    private LevelManager levelManager = null;

    private void Start()
    {
        InitializeComponents();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            levelManager.RemoveTrackedBall();

            if (levelManager.CheckIfZeroBalls())
            {
                levelManager.LoseLevel();
            }

            Destroy(collider.gameObject, 1f);
        }
    }


    private void InitializeComponents()
    {
        levelManager = FindObjectOfType<LevelManager>();
        sceneLoaderScript = GameObject.FindGameObjectWithTag("Scene Loader").GetComponent<SceneLoader>();
    }

}
