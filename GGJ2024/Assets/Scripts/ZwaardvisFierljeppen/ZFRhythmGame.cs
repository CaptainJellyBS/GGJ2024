using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZFRhythmGame : MonoBehaviour
{
    public Transform player;
    
    // Sart is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);    
    }
}
