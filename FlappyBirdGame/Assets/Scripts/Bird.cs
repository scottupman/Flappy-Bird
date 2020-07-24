using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 200f;
    public bool isDead;
    float maxHeight = 4.5f;
    
    public Transform birdPosition;
    Rigidbody2D birdRB2D;
    Animator birdAnimation;
    
    void Start()
    {
        birdRB2D = GetComponent<Rigidbody2D>();
        birdAnimation = GetComponent<Animator>();
    }

    // Since we're only adding a force once on one frame it's okay to put it in update
    void Update()
    {
        if (!isDead)
        {
            flapBird();
        }

        limitMaxHeight();
    }

    void flapBird()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            birdRB2D.velocity = Vector2.zero;
            birdRB2D.AddForce(new Vector2(0f, jumpForce));
            birdAnimation.SetTrigger("Flap");
        }
    }

    void OnCollisionEnter2D()
    {
        isDead = true;
        birdRB2D.velocity = Vector2.zero;
        birdAnimation.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }    

    void limitMaxHeight()
    {
        if (birdPosition.position.y > maxHeight)
        {
            // set the y position of the bird equal to the max height then let gravity take place
            birdPosition.position = new Vector2(transform.position.x, maxHeight);
        }
    }
}
