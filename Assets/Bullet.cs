using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = Constants.bulletSpeed;

    private float lifetime = Constants.bulletLifetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(bulletSpeed * Time.deltaTime, 0, 0);

        lifetime -= Time.deltaTime;

        if (lifetime < 0)
            Destroy(gameObject);
    }

    public void setDirection(bool left) {
        if (left)
            bulletSpeed *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Vector3 dir;

            float yDiff = collision.gameObject.transform.position.y - transform.position.y;

            if (yDiff > 0.5)
                dir = Vector3.up;
            else
                dir = ((Vector3.up * 1.7f * Mathf.Abs(bulletSpeed)) + (Vector3.right * bulletSpeed)).normalized;

            //reset player jump
            collision.gameObject.GetComponent<CharacterController2D>().ResetJump();

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Constants.bulletPushForce * dir);

            Destroy(gameObject);
        }
    }
}
