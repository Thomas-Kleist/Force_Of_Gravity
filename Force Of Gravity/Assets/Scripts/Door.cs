using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject Player;
    public int index;
    public GameObject text;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < 2)
        {
            if (Player.GetComponent<Player>().keys[index] == true) text.GetComponent<Text>().text = "Press E to open door"; else text.GetComponent<Text>().text = "Requires key " + index.ToString() + " to open door";
            if (Input.GetButtonDown("Select") && Player.GetComponent<Player>().keys[index] == true)
            {
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
