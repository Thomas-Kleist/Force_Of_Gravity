using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D box;
    public float speed = 100;
    public float rayDis = 0.2f;
    public float jumpSpeed = 300;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Movement();
    }
   private void Movement()
    {
        transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y);
        RaycastHit2D[] hit = new RaycastHit2D[10];
        int hits = box.Raycast(new Vector2(transform.position.x, transform.position.y+1), hit, rayDis);
        if (hits == 0) hits = box.Raycast(new Vector2(transform.position.x + 2, transform.position.y + 1), hit, rayDis*2f);
        if (hits == 0) hits = box.Raycast(new Vector2(transform.position.x - 2, transform.position.y + 1), hit, rayDis*2f);
        if (Input.GetButton("Jump") && hits != 0 && rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            hit[0].transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -jumpSpeed));
        }
    }
}
