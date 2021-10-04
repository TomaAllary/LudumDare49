using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject menuPanel;
    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }
    }
}
