using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject Player;
    private void Update()
    {
        transform.position = Player.transform.position - new Vector3(0,0,10);
    }
}
