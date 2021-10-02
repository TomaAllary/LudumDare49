using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    private Animator animator;

    private float timer = 0;
    private float maxTimer = 4;
    private float minTimer = 2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0) {
            int randomAnim = Random.Range(1, 3);

            animator.SetInteger("idle_state", randomAnim);
            animator.SetTrigger("play_anim");

            timer = Random.Range(minTimer, maxTimer);
        }
        else {
            timer -= Time.deltaTime;
        }
    }
}
