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

    public bool Paused = false;
    public GameObject PauseMenu;
    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        Paused = true;
    }
}
