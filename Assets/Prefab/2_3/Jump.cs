using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody m_playerRig;
    public GameObject Gyroscope;
    private Collider m_Collider;
    //parametres
    private float distToGround;
    [Range(100,1000)]
    public float jumpForce;



    // Start is called before the first frame update
    void Start()
    {
        m_playerRig = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();
        distToGround = 0.51f; //boule de rayon 0.5
        print("distToGround");
        print(distToGround);
    }

    //Fonction pour savoir si l'on touche le sol
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
    }

    // Update is called once per frame
    void Update()
    {
        // Saut
        if (Input.touchCount == 1 && IsGrounded())
        {
            m_playerRig.AddForce(Gyroscope.transform.up * jumpForce);
        }
    }
}
