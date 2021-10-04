using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    public GameObject buttonOn;
    public GameObject buttonOff;
    private Killable[] npcs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        buttonOff.SetActive(false);
        buttonOn.SetActive(true);
        npcs = Object.FindObjectsOfType<Killable>();
        foreach (Killable k in npcs)
        {
            k.dieInMotion();
        }
    }
}
