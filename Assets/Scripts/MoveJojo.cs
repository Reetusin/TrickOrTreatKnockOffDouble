using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJojo : MonoBehaviour
{
    public float speed = 10;

    private void Start()
    {
        var poss = transform.position;
        poss.x += UnityEngine.Random.Range(-8f, 8f);
        transform.position = poss;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
}
