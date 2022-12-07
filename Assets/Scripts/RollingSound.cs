using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSound : MonoBehaviour
{
    private Rigidbody m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_rb.velocity.magnitude);
        if (m_rb.velocity.magnitude > 1f)
        {

        }
    }
}
