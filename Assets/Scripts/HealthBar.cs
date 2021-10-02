using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(0, 1, 1);
    }

    public void setHealth (float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void addHealth(float amountNormalized)
    {
        Vector3 modVector = new Vector3(amountNormalized, 0, 0);
        bar.localScale += modVector;
    }
}
