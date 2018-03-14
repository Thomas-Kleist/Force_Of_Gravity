using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowerController : MonoBehaviour {

    public bool followingPlayer = true;
    public GameObject player;
	void Update () {
		if (followingPlayer)
        {
            transform.position = player.transform.position;
        }
	}

    public void StartMoveToPoint(Vector2 position, float time)
    {
        StartCoroutine(MoveToPoint(position, time));
    }

    public IEnumerator MoveToPoint(Vector2 postion, float time)
    {
        Debug.Log("Started this thing");
        followingPlayer = false;
        transform.position = postion;
        yield return new WaitForSeconds(time);
        followingPlayer = true;
        Debug.Log("ended this Thing");
    }
}
