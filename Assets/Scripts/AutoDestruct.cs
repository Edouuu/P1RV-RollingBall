using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    private float temps;
    void Start()
    {
        temps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        temps += Time.deltaTime;
        if (temps >= 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
