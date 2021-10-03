using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class flashingText : MonoBehaviour
{
    public GameObject[] texts;
    public int current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            current--;
            if (current < 0)
            {
                current = 3;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            current++;
            if (current == 4)
            {
                current = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(waiter());
            
        }
    }
    IEnumerator waiter()
    {
        texts[current].SetActive(true);  
        yield return new WaitForSecondsRealtime(0.1f);
        texts[current].SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        texts[current].SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        texts[current].SetActive(false);
    }
}
