using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPushDown : MonoBehaviour
{
    public IEnumerator PushDown(float speed)
    {
        while (speed > 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (speed) * Time.deltaTime/3);
            speed -= 0.1f;
            yield return null;
        }
    }

}
