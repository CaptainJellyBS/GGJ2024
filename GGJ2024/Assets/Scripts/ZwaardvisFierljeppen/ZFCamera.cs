using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZFCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0,1,-10);

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            player.position.x + offset.x,
            transform.position.y,
            player.position.z + offset.z
            );
    }
}
