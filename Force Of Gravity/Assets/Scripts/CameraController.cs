using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject Player;
    Vector2 currentVel = Vector2.zero;
    private void Update()
    {
        if (transform.position.y > -20)
        {
            transform.position = Vector2.SmoothDamp(transform.position, Player.transform.position, ref currentVel, 0.1f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        else
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
        }
    }
}
