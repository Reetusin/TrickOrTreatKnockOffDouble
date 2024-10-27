using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public AudioClip hitSound;

    private AudioSource audioSource;

    private int score = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            score -= 10;
            audioSource.PlayOneShot(hitSound);
        }
        Destroy(other.gameObject);
    }
}