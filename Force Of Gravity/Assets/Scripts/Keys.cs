using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public int index = 0;
    public GameObject player;

    public GameObject text;

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 1)
        {
            text.GetComponent<Text>().text = "Press E pick up key " + index.ToString();
            if (Input.GetButtonDown("Select"))
            {
                text.GetComponent<Text>().text = "";
                player.GetComponent<Player>().keys[index] = true;
                Destroy(gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            text.GetComponent<Text>().text = "";
        }
    }
}
