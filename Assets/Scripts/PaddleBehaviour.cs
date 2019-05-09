using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    private float aspectRatio = (4f/3f);

    private float halfOfPaddleWidth = 2f/2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float screenHeightInUnits = Camera.main.orthographicSize * 2;
        float screenWidthInUnits = screenHeightInUnits * aspectRatio;

        float mouseXCoordinate = Input.mousePosition.x / (Screen.width / screenWidthInUnits);

        float screenMinX = 0f + halfOfPaddleWidth;
        float screenMaxX = screenWidthInUnits - halfOfPaddleWidth;
        float mouseXCoordinateInScreenBounds = Mathf.Clamp(mouseXCoordinate, screenMinX, screenMaxX);

        transform.position = new Vector2 (mouseXCoordinateInScreenBounds, transform.position.y);
    }
}
