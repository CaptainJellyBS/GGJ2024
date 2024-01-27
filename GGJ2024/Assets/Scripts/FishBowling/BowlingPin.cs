using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BowlingPin : MonoBehaviour
{
    bool hasBeenScored = false;

    private void OnTriggerExit(Collider other)
    {
        Score();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score")) { gameObject.SetActive(false); }
    }

    void Score()
    {
        if (hasBeenScored) { return; }
        hasBeenScored = true;
        FishBowling.Instance.ScorePin();        
    }    
}
