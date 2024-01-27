using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class FishBall : MonoBehaviour
{
    public GameObject anglePanel, powerPanel;
    public Image anglePointer, powerPointer;

    Rigidbody rb;
    bool hasBeenThrown = false;
    // Start is called before the first frame update
    void Start()
    {
        //Debug
        rb = GetComponent<Rigidbody>();

        StartCoroutine(StartSequenceC());
    }

    // Update is called once per frame
    void Update()
    {
        if(hasBeenThrown && rb.velocity.magnitude < 0.1f) { Score(); }
        if(transform.position.y < -10) { Score(); }
    }

    IEnumerator StartSequenceC()
    {
        rb.useGravity = false;
        bool done = false;
        float angle = 0.0f;
        anglePanel.SetActive(true);

        while (!done)
        {            
            while(angle < 1.0f && !done)
            {
                anglePointer.transform.localRotation = Quaternion.Euler(0, 0, angle * -45.0f);
                done = Input.GetKeyDown(KeyCode.Space) || done;
                yield return null;
                angle += Time.deltaTime * 2.5f;                
            }
            while(angle > -1.0f && !done)
            {
                anglePointer.transform.localRotation = Quaternion.Euler(0, 0, angle * -45.0f);
                done = Input.GetKeyDown(KeyCode.Space) || done;
                yield return null;
                angle -= Time.deltaTime * 2.5f;
            }
        }

        anglePanel.SetActive(false);

        done = false;
        yield return null;
        yield return new WaitForSeconds(0.5f);

        float power = 5.0f;
        powerPanel.SetActive(true);

        while(!done)
        {
            while(power < 10.0f && !done)
            {
                powerPointer.transform.localScale = new Vector3(powerPointer.transform.localScale.x, 
                    Mathf.InverseLerp(3.0f, 10.0f, power), powerPointer.transform.localScale.z);
                done = Input.GetKeyDown(KeyCode.Space) || done;
                yield return null;
                power += Time.deltaTime * 4.0f;
            }
            while(power > 3.0f && !done)
            {
                powerPointer.transform.localScale = new Vector3(powerPointer.transform.localScale.x,
                    Mathf.InverseLerp(3.0f, 10.0f, power), powerPointer.transform.localScale.z);
                done = Input.GetKeyDown (KeyCode.Space) || done;
                yield return null;
                power -= Time.deltaTime * 4.0f;
            }
        }

        powerPanel.SetActive(false);
        AddForce(new Vector3(angle, 0, 1.0f).normalized, power);
        rb.useGravity = true;

        yield return null;
        hasBeenThrown = true;
    }

    public void AddForce(Vector3 force, float power)
    {
        rb.AddForce(force * power, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Score"))
        {
            Score();
            gameObject.SetActive(false);
        }
    }

    void Score()
    {
        FishBowling.Instance.CalculateScore();
    }
}
