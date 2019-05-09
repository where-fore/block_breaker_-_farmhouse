using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
    
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LoadStartScene();
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                LoadNextScene();
            }
        }
    }
}
