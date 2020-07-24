using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip deathSound;
    bool played;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (GameControl.instance.gameOver && !played)
        {
            source.PlayOneShot(deathSound);
            played = true;
        }
    }
}
