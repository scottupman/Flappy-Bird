using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    Rigidbody2D scrollingRB2D;
    public float scrollSpeed = -1.5f;

    void Start()
    {
        scrollingRB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        scrollingRB2D.velocity = new Vector2(scrollSpeed, 0f);

        if (GameControl.instance.gameOver)
        {
            scrollingRB2D.velocity = Vector2.zero;
        }
    }
}
