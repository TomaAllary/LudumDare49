using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Camera cam;
    public GameObject goatSurroundings;
    public float runspeed = 40f;
    public float rageMeter = 0f;
    public ParticleSystem goatSparkle;
    float horizontalMove = 0f;
    bool isJumping = false;
    private Animator myAnimator;
    public HealthBar rageBar;
    public bool inCriss;
   

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        inCriss = false;
        goatSparkle.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        if (horizontalMove != 0)
        {
            myAnimator.SetBool("isMoving", true);
        }
        else
        {
            myAnimator.SetBool("isMoving", false);
        }
        if(rageBar.getRageLevel() >= 1)
        {
            inCriss = true;
            goatSparkle.gameObject.SetActive(true);
            controller.m_JumpForce = Constants.goatRageJumpForce;
        }
        else if(rageBar.getRageLevel() <= 0)
        {
            inCriss = false;
            goatSparkle.gameObject.SetActive(false);
            controller.m_JumpForce = Constants.goatNormalJumpForce;
        }
        if(gameObject.GetComponent<CharacterController2D>().looseRage && !inCriss)
        {
            rageBar.setHealth(0);
        }
    }

    private void FixedUpdate()
    {

        cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z);

        goatSurroundings.transform.position = transform.position;

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "weapon")
        {
            rageBar.GetComponent<HealthBar>().addHealth(.2f);
        }

    }

}
