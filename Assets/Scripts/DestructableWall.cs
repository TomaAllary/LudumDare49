using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWall : MonoBehaviour
{

    public Animator upperWall;
    public Animator lowerWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            //check if in rage mode and if hitting

            //Destroy wall
            upperWall.SetTrigger("destroy");
            lowerWall.SetTrigger("destroy");

            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    IEnumerator destroyItself() {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
