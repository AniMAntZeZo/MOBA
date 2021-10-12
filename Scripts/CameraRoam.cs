using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoam : MonoBehaviour
{
    private float camSpeed = 20;
    private float screenSizeThickeness = 10;


    void Update()
    {
        Vector3 pos = transform.position;

        //Up
        if (Input.mousePosition.y >= Screen.height - screenSizeThickeness)
        {
            pos.z += camSpeed * Time.deltaTime;
        }
        
        //Down
        if (Input.mousePosition.y <= screenSizeThickeness)
        {
            pos.z -= camSpeed * Time.deltaTime;
        }
                
        //Right
        if (Input.mousePosition.x >= Screen.width - screenSizeThickeness)
        {
            pos.x += camSpeed * Time.deltaTime;
        }
                        
        //Left
        if (Input.mousePosition.x <= screenSizeThickeness)
        {
            pos.x -= camSpeed * Time.deltaTime;
        }

        transform.position = pos;

    }
}
