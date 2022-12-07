using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etape : MonoBehaviour
{
    [SerializeField] GameObject EndOfLevel;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        EndOfLevel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
