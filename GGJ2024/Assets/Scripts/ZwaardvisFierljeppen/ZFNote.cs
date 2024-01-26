using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZFNote : MonoBehaviour
{
    KeyCode key;
    public TextMeshProUGUI keyText;

    bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        key = Fierljeppen.Instance.GetRandomKey();
        keyText.text = key.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.anyKeyDown)
        {
            float acc = 0.0f;
            if (Input.GetKeyDown(key))
            {
                acc = Fierljeppen.Instance.CalculateNoteScore(this);
            }

            Fierljeppen.Instance.IncreasePlayerSpeed(acc);
            Destroy(transform.parent.gameObject);
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
