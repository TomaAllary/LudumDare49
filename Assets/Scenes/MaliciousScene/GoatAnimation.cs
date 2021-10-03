using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoatAnimation : MonoBehaviour
{

    public Animator anim;

    public GameObject droppingTitle;

    public Animator EndingAnim;

    private float dropTimer = 16;

    public float speed = 6;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("isWalking", true);   
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + (Time.deltaTime * speed * Vector3.right));

        if (dropTimer < 0) {
            droppingTitle.SetActive(true);
        }

        dropTimer -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        collision.gameObject.GetComponent<Rigidbody2D>().constraints = 0;

        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
    }

    private IEnumerator end() {
        yield return new WaitForSeconds(3);

        EndingAnim.SetTrigger("play");

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("Menu");
    }
}
