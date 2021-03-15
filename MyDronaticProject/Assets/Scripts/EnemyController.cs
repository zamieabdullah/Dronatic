using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    
    Vector2 movement;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }
    
    void Update()
    {    
        movement.x = (float)Math.Cos(transform.rotation.eulerAngles.z);
        movement.y = (float)Math.Sin(transform.rotation.eulerAngles.z);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        transform.Rotate(new Vector3(0, 0, (transform.rotation.eulerAngles.z + 170) % 360));
        Debug.Log(transform.rotation.eulerAngles.z);
    }

}
