using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            DestroyGameManager();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DestroyGameManager()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
