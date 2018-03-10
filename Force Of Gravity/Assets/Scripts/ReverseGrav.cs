using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReverseGrav : MonoBehaviour {
    public GameObject player;
    public GameObject text;

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 1.5)
        {
            text.GetComponent<Text>().text = "Press E to reverse gravity";
            if (Input.GetButtonDown("Select"))
            {
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
                text.GetComponent<Text>().text = "";
                Destroy(gameObject);
            }
        }
        else
        {
            text.GetComponent<Text>().text = "";
        }
    }
}
