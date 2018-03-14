using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPushDown : MonoBehaviour
{
    public bool moveable = true;
    public IEnumerator PushDown(float speed)
    {
        moveable = true;
        if (speed > 0) while (speed > 0)
        {
            if (!moveable) break;
            yield return null;
            transform.position = new Vector2(transform.position.x, transform.position.y - (speed) * Time.deltaTime/3);
            speed -= 0.1f; 
        }

        if (speed < 0) while (speed < 0)
            {
                if (!moveable) break;
                yield return null;
                transform.position = new Vector2(transform.position.x, transform.position.y - (speed) * Time.deltaTime / 3);
                speed += 0.1f;
            }
    }

    public void StartExplosion(float time, float torque, Vector2 force)
    {
        StartCoroutine(Expload(time, torque, force));
    }

    public IEnumerator Expload(float time, float torque, Vector2 force)
    {
        yield return new WaitForSeconds(time);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().AddTorque(torque);
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.transform.GetComponent<Stats>() != null) if (collision.collider.transform.GetComponent<Stats>().stopingJumpable == true) moveable = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.transform.GetComponent<Stats>() != null) if (collision.collider.transform.GetComponent<Stats>().stopingJumpable == true) moveable = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        moveable = true;
    }
}
