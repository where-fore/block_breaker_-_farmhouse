using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public bool levelStarted = false;

    private int blocksTracked = 0;

    private SceneLoader sceneLoaderManager = null;

    private void Start()
    {
        sceneLoaderManager = FindObjectOfType<SceneLoader>();
    }

    public void StartLevel()
    {
        levelStarted = true;
    }

    public void AddTrackedBlock()
    {
        blocksTracked ++;
    }

    public void RemoveTrackedBlock()
    {
        blocksTracked --;
    }
    
    private void Update()
    {
        if (blocksTracked == 0 && levelStarted)
        {
            sceneLoaderManager.LoadNextScene();
            levelStarted = false;
        }
    }
}
