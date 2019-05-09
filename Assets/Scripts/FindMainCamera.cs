using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMainCamera : MonoBehaviour
{
    void Awake()
    {
        GetComponentInParent<Canvas>().worldCamera = Camera.main;
    }
}
