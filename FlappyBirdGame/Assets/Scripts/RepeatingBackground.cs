using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Repeat the background when the first one goes out of view
public class RepeatingBackground : MonoBehaviour
{ 
    BoxCollider2D backgroundCollider; 
    void Start()
    {
        backgroundCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -backgroundCollider.size.x)
        {
            transform.position = (Vector2)transform.position + new Vector2(backgroundCollider.size.x * 2f, 0f);
        }
    }
}
