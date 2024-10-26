using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Beggining : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject spawner;
    public AudioClip startSound;

    private int count = 3;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (count > 0)
        {
            text.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
            audioSource.PlayOneShot(startSound);
        }
        Destroy(text.gameObject);
        spawner.SetActive(true);
    }
}