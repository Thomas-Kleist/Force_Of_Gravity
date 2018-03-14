using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravBug : MonoBehaviour
{
    GameObject player;
    public GameObject arrow;
    public GameObject exit;
    Vector2 curVel;
    bool followingPlayer = true;

    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
        if (followingPlayer) transform.position = Vector2.SmoothDamp(transform.position, player.transform.position + new Vector3(0, player.GetComponent<Rigidbody2D>().gravityScale * 4, 0), ref curVel, 1, 20);
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 1 && followingPlayer)
        {
            GameObject arrowGO = Instantiate(arrow);
            arrowGO.transform.position = transform.position - new Vector3(0, player.GetComponent<Rigidbody2D>().gravityScale, 0);
            if (player.GetComponent<Rigidbody2D>().gravityScale < 0) arrowGO.GetComponent<SpriteRenderer>().flipY = false;
            followingPlayer = false;
        }
        if (!followingPlayer) transform.position = Vector2.SmoothDamp(transform.position, exit.transform.position, ref curVel, 1, 20);
        if ((Mathf.Abs(transform.position.x - exit.transform.position.x) < 1 && !followingPlayer))
        {
            followingPlayer = true;
        }
    }
}
