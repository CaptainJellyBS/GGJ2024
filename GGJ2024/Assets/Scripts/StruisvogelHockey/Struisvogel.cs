using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Struisvogel : MonoBehaviour
{
    public Transform neckPivot;
    public float rotSpeed = 360;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            neckPivot.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            neckPivot.Rotate(new Vector3(0, 0, -rotSpeed * Time.deltaTime));
        }
    }
}
