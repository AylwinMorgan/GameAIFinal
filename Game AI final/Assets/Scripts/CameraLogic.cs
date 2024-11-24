using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
/*
    float mapX = 5f;
    float mapY = 5f;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    
    void Start()
    {
        float vertExtent = GetComponent<Camera>().orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        maxX = horzExtent - mapX / 2.0f;
        minX = mapX / 2.0f - horzExtent;
        maxY = vertExtent - mapY / 2.0f;
        minY = mapY / 2.0f - vertExtent;

        World.minX = minX;
        World.maxX = maxX;
        World.minY = minY;
        World.maxY = maxY;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
    */
}
