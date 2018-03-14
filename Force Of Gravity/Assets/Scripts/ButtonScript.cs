using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject text;
    public GameObject Door;
    public GameObject CameraFollower;
    public Vector2 force;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < 2)
        {
            text.GetComponent<Text>().text = "Press E to open door";
            if (Input.GetButtonDown("Select"))
            {
                text.GetComponent<Text>().text = "";
                CameraFollower.GetComponent<CameraFollowerController>().StartMoveToPoint(Door.transform.position, 1.5f);
                Door.GetComponent<BlockPushDown>().StartExplosion(0.3f, 3233, force);
                Destroy(gameObject);
            }
        }
        else
        {
            text.GetComponent<Text>().text = "";
        }
    }
}
