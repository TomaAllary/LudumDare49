using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOnWalk : MonoBehaviour
{
    public AudioSource walkywalky;
    public AudioClip clip;
    private float steptick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        if (steptick <= 0 && Input.GetAxisRaw("Horizontal") != 0)
        {
            walkywalky.PlayOneShot(clip);
            steptick = .4f;
        }

        if (steptick > 0)
            steptick -= Time.deltaTime;
    }
}
