using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtapeS : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] GameObject NextDoor;
    [SerializeField] GameObject NextEtape;

    public void Start()
    {
       /* Door.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        NextDoor.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.white);*/
    }
    private void OnTriggerEnter(Collider other)
    {
        // change la couleur des portes
        Door.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        NextDoor.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        // (des)active les etapes
        this.gameObject.SetActive(false);
        NextEtape.SetActive(true);
    }
}
