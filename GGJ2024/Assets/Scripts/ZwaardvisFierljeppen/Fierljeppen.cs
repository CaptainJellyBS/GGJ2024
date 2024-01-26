using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fierljeppen : MonoBehaviour
{
    public static Fierljeppen Instance { get; private set; }
    public List<KeyCode> noteKeys = new List<KeyCode>() { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    public Zwaardvis player;
    public Transform rhythmControl;

    private void Awake()
    {
        if (Instance != null) { Destroy(Instance); }
        Instance = this;
    }

    public float CalculateNoteScore(ZFNote note)
    {
        return 1.5f - Mathf.Abs(rhythmControl.position.x - note.transform.position.x);
    }

    public void IncreasePlayerSpeed(float acc)
    {
        Debug.Log(acc);
        player.IncreaseSpeed(acc);
    }

    public KeyCode GetRandomKey()
    {
        return Utility.Pick(noteKeys);
    }
}
