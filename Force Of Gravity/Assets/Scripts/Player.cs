using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D box;
    public float speed = 100;
    public int rayDis = 1;
    public float jumpSpeed = 4;
    public Transform objectHit;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y);
        if (Input.GetButtonUp("Jump") && objectHit != null)
        {
            rb.AddRelativeForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            if (objectHit.GetComponent<BlockPushDown>() != null) objectHit.GetComponent<BlockPushDown>().StartCoroutine("PushDown", jumpSpeed);
            jumpSpeed = 4;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jumpSpeed = 4;
        }
        else if (Input.GetButton("Jump"))
        {
            jumpSpeed += 0.1f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        objectHit = collision.collider.transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        objectHit = null;
    }
}
