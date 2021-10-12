using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwichManager : MonoBehaviour
{
    public CameraMove cameraMoveScript;
    public CameraRoam cameraRoamScript;

    bool camViewChenged = true;

    void Start()
    {
        cameraRoamScript.enabled = false;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!camViewChenged)
            {
                camViewChenged = true;

                cameraRoamScript.enabled = false;
                cameraMoveScript.enabled = true;
            }
            else if (camViewChenged)
            {
                camViewChenged = false;

                cameraMoveScript.enabled = false;
                cameraRoamScript.enabled = true;
            }
        }

    }
}
