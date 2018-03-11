using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D box;
    public float speed = 100;
    public int rayDis = 1;
    public float jumpSpeed = 4;
    public Transform objectHit;

    public GameObject jumpbarBack;
    public GameObject jumpbarBackFront;
    public GameObject jumpbarFore;

    public bool modded = false;

    public bool[] keys;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        keys = new bool[10];
    }

    private void Update()
    {
        if (transform.position.y < -40 && rb.freezeRotation)
        {
            rb.freezeRotation = false;
            StartCoroutine(EaseIn());
        }
    }

    void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y);
        if (Input.GetButtonDown("Jump") && Input.GetButton("Mod"))
        {
            modded = true;
        }
        else if (Input.GetButtonDown("Jump") && !modded && objectHit != null)
        {
            rb.AddRelativeForce(new Vector2(0, 4 * rb.gravityScale), ForceMode2D.Impulse);
            if (objectHit.GetComponent<BlockPushDown>() != null) objectHit.GetComponent<BlockPushDown>().StartCoroutine("PushDown", 4 * rb.gravityScale);
        }
        if (Input.GetButtonUp("Jump") && modded && objectHit != null)
        {
            rb.AddRelativeForce(new Vector2(0, jumpSpeed * rb.gravityScale), ForceMode2D.Impulse);
            if (objectHit.GetComponent<BlockPushDown>() != null) objectHit.GetComponent<BlockPushDown>().StartCoroutine("PushDown", jumpSpeed * rb.gravityScale);
            jumpSpeed = 4;
            jumpbarBack.GetComponent<Image>().enabled = false;
            jumpbarBackFront.GetComponent<Image>().enabled = false;
            jumpbarFore.GetComponent<Image>().enabled = false;
            modded = false;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jumpSpeed = 4;
        }
        else if (Input.GetButton("Jump") && modded)
        {
            jumpSpeed = Mathf.Clamp(jumpSpeed + 10 * Time.deltaTime, 0, 20);
            jumpbarBack.GetComponent<Image>().enabled = true;
            jumpbarBackFront.GetComponent<Image>().enabled = true;
            jumpbarFore.GetComponent<Image>().enabled = true;
        }
        else if (!Input.GetButton("Jump"))
        {
            jumpbarBack.GetComponent<Image>().enabled = false;
            jumpbarBackFront.GetComponent<Image>().enabled = false;
            jumpbarFore.GetComponent<Image>().enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (objectHit == null || objectHit.GetComponent<Stats>().selectPriority < collision.collider.transform.GetComponent<Stats>().selectPriority) objectHit = collision.collider.transform;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (objectHit == null || objectHit.GetComponent<Stats>().selectPriority < collision.collider.transform.GetComponent<Stats>().selectPriority) objectHit = collision.collider.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        objectHit = null;
    }
    private IEnumerator EaseIn()
    {
        for (int i = 0; i < 50; i++)
        {
            rb.AddTorque(i / 10);
            yield return null;
        }
    }
}
