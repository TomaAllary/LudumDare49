using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(bulletSpeed * Time.deltaTime, 0, 0);
    }

    public void setDirection(bool left) {
        if (left)
            bulletSpeed *= -1;
    }
}
