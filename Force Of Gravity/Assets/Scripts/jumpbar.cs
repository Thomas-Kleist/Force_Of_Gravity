using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpbar : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        transform.localScale = new Vector3((player.GetComponent<Player>().jumpSpeed - 4) / 16, 1, 1);
    }
}
