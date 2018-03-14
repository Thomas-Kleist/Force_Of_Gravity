using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingArrow : MonoBehaviour {
    GameObject player;
    bool running = false;
    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        GetComponent<Rigidbody2D>().gravityScale = player.GetComponent<Rigidbody2D>().gravityScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject == player)
        {
            player.GetComponent<Rigidbody2D>().gravityScale *= -1;
            Destroy(gameObject);
        } else
        {
            if (!running) StartCoroutine(WaitAndMove());
        }
    }

    private IEnumerator WaitAndMove()
    {
        running = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(10f);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().AddTorque(10);
        StartCoroutine(WaitAndDestroy());
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
