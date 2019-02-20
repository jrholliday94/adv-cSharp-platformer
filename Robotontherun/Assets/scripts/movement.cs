using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;   //access rigid body
    public float Speed;     //speed of robot
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * Speed);
    }

    
}










