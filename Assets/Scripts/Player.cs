using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        float moveInput = 0f;

        if (Input.GetKey("a")) 
        {
            moveInput = -1f;
        }
        else if (Input.GetKey("d")) 
        {
            moveInput = 1f;
        }

        // Move the player
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, 0);
        transform.position += (Vector3)moveVelocity * Time.deltaTime;




    }



}

