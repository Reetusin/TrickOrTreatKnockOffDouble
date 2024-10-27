using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 2;

    private void Start()
    {
        var pos = transform.position;
        pos.x += UnityEngine.Random.Range(-10f, 10f);
        transform.position = pos;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}