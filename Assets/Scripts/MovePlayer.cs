using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public Transform pos;
    public float speed;
    bool touchedLastFrame = false;


    void Start()
    {
        rb.velocity = new Vector3(speed * Time.fixedDeltaTime, 0f, 0f);
    }

    void FixedUpdate()
    {
        rb.AddForce(force * Time.deltaTime, 0, 0);
        if(touchedLastFrame && Input.touchCount == 0)
        {
            touchedLastFrame = false;
        }
        else if (!touchedLastFrame && Input.touchCount > 0)
        {
            touchedLastFrame = true;
            Touch touch = Input.GetTouch(0);

            if (touch.position.x > Screen.width/2 && pos.position.z > -8)
            {
                rb.MovePosition(pos.position - new Vector3(0, 0, 4f));
            }
            if (touch.position.x < Screen.width/2 && pos.position.z < 8)
            {
                rb.MovePosition(pos.position + new Vector3(0, 0, 4f));
            }
        }
    }
}
