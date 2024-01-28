using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HockeyBall : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    bool hasBeenScored = false;
    Transform targetPoint;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPoint = StruisvogelHockey.Instance.GetRandomTarget();

        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenScored)
        { transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score")) { Destroy(gameObject); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(Score());
        }
    }

    IEnumerator Score()
    {
        if (hasBeenScored) { yield break; }
        hasBeenScored = true;
        rb.useGravity = true;
        rb.velocity = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f),0).normalized * Random.Range(8.0f, 14.0f);
        StruisvogelHockey.Instance.ScoreBall();

        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }    

}
