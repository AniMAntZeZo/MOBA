using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{

    private Camera cam;
    private float camFOV;
    public float zoomSpeed;

    private float mouseScrollInput;

    void Start()
    {
        cam = Camera.main;
        camFOV = cam.fieldOfView;
    }


    void Update()
    {
        mouseScrollInput = Input.GetAxis("Mouse ScrollWheel");

        camFOV -= mouseScrollInput * zoomSpeed;
        camFOV = Mathf.Clamp(camFOV, 30, 80);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, camFOV, zoomSpeed);

    }
}
