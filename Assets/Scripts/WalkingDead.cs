using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingDead : MonoBehaviour
{
    public groundCheck gc;
    public WallCheck wc;
    public GameObject walkingDeadSurroundings;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        {
            if (!isGrounded() || isWalled())
            {
                Vector3 current = gameObject.transform.eulerAngles;
                current.y += 180;
                gameObject.transform.eulerAngles = current;
            }
            transform.position = (transform.position + -transform.right * Time.fixedDeltaTime * Constants.walkingDeadSpeed);
        }
    }

    private bool isGrounded()
    {
        return gc.GetComponent<groundCheck>().isGrounded;
    }
    private bool isWalled()
    {
        return wc.GetComponent<WallCheck>().isWalled;
    }
}
