using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingDeadAttack : MonoBehaviour
{
    [SerializeField] BoxCollider2D attackCollider;

    public int facingRight = -1;

    public void StartAttack() {
        attackCollider.enabled = true;
    }

    public void StopAttack() {
        attackCollider.enabled = false;
    }


    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Player") {
            Vector3 dir = ((Vector3.up * 5.7f) + (Vector3.right * facingRight * 4.0f)).normalized;

            //reset player jump
            //collision.gameObject.GetComponent<CharacterController2D>().ResetJump();

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Constants.walkindDeadPushForce * dir);
        }
    }

}
