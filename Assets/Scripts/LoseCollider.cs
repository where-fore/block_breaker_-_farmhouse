using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private SceneLoader sceneLoaderScript = null;

    void Awake()
    {
        sceneLoaderScript = GameObject.FindGameObjectWithTag("Scene Loader").GetComponent<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player collided at: " + collider.transform.position);
            sceneLoaderScript.LoadGameOver();
        }

    }
}
