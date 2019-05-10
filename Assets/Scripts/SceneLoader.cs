using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int startingSceneIndex = 1;

    private string gameOverScreenStringIndex = "Game Over";
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(startingSceneIndex);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(gameOverScreenStringIndex);
    }
}
