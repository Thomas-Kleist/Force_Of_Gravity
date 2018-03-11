using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public new GameObject camera;
    public void EasyZoom()
    {
        camera.GetComponent<Camera>().orthographicSize = 12;
    }
    public void MidZoom()
    {
        camera.GetComponent<Camera>().orthographicSize = 8;
    }
    public void HardZoom()
    {
        camera.GetComponent<Camera>().orthographicSize = 4;
    }
}
