using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public GameObject OtherPortal;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.transform.gameObject == player) player.transform.position = OtherPortal.transform.position  - new Vector3(0, 3f, 0);
    }
}
