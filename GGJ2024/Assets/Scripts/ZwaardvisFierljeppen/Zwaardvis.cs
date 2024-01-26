using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Zwaardvis : MonoBehaviour
{
    public float startSpeed = 0.5f;
    public float speedIncreaseMod = 0.5f;
    public Collider2D ground; //YUCK
    public Transform measurePoint;
    public ZFCamera zfcam;
    public GameObject rhythmControl;

    float currentSpeed;
    Animator animator;
    Rigidbody2D rb;
    Vector3 origPos;

    bool isFlipping = false;
    bool hasFlipped = false;
    bool onGround = true;
    bool hasScored = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        origPos = transform.position;

        //Debug
        Init();
    }

    public void Init()
    {
        transform.position = origPos;
        currentSpeed = startSpeed;
        hasFlipped = false;
        rb.gravityScale = 1.0f;
        onGround = true;
    }

    private void Update()
    {
        if(!hasFlipped && !isFlipping)
        {
            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                animator.SetTrigger("Flip"); isFlipping = true;
                rb.gravityScale = 0.0f;
                rhythmControl.SetActive(false);
            }

            //Debug

            rb.velocity = new Vector3(currentSpeed, rb.velocity.y);
        }

        if(hasFlipped && rb.velocity.magnitude < 0.01f) { Score(); } //Prevent flipping really early from locking the game
    }

    public void Flip()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.x);
        hasFlipped = true;
        rb.gravityScale = 1.0f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider == ground) { onGround = false; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Score"))
        {
            Score();
        }
    }

    void Score()
    {
        if (hasScored) { return; }
        hasScored = true;
        zfcam.enabled = false;
        int score = Mathf.Max(0, (int)(transform.position.x - measurePoint.position.x));
        GameManager.Instance.IncreaseScore(score);
        Debug.Log(score);
    }

    public void IncreaseSpeed(float acc)
    {
        if(hasFlipped || isFlipping) { return; }

        currentSpeed += (Mathf.Max(speedIncreaseMod * acc,0));
    }
}
