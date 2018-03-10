using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject Player;
    Vector2 currentVel = Vector2.zero;
    private void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, Player.transform.position, ref currentVel, 0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
