using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Vector3 position;

    // Update is called once per frame
    void Update()
    {
        position.Set(Player.transform.position.x, this.transform.position.y, this.transform.position.z);
        this.transform.position = position;
    }
}
