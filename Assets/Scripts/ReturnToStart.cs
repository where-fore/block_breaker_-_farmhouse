using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToStart : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            FindObjectOfType<SceneLoader>().LoadStartScene();
        }
    }
}
