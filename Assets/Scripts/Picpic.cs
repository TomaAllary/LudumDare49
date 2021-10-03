using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picpic : MonoBehaviour
{
    private bool isDown = false;
    public groundCheck gc;
    public WallCheck wc;
    public GameObject picpicSurroundings;
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
        if (!isDown)
        {
            if (!isGrounded() || isWalled())
            {
                Vector3 current = gameObject.transform.eulerAngles;
                current.y += 180;
                gameObject.transform.eulerAngles = current;
            }
            transform.position = (transform.position + -transform.right * Time.fixedDeltaTime * Constants.picpicSpeed);
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