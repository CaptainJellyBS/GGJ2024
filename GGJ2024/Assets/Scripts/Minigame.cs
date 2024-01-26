using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    public bool isPlaying = false;

    public virtual void Init()
    {
        isPlaying = true;
    }
        
}
