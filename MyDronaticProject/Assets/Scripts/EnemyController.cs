using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public GameObject coin;
    public float x_val;
    public float y_val;
    public float rot_val;
    Vector2 movement;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // rb.freezeRotation = true;
        movement.x = (float)Math.Cos(transform.rotation.eulerAngles.z);
        movement.y = (float)Math.Sin(transform.rotation.eulerAngles.z);
    }
    
    void Update()
    {    
        // movement.x = (float)Math.Cos(transform.rotation.eulerAngles.z);
        // movement.y = (float)Math.Sin(transform.rotation.eulerAngles.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "missle(Clone)") {
            Instantiate (coin, transform.position, Quaternion.identity);
            transform.position = new Vector2(x_val, y_val);
            transform.rotation = Quaternion.Euler(0, 0, rot_val);
        } else if (col.gameObject.name != "Coin(Clone)") {
            Vector2 collisionSurfaceNormal = col.GetContact(0).normal;
            rb.velocity = Vector2.Reflect(rb.velocity, collisionSurfaceNormal);
            movement = Vector2.Reflect(rb.velocity, collisionSurfaceNormal);
            // transform.Rotate(new Vector3(0, 0, (float)Math.Tan(movement.x/movement.y)), Space.World);
            // movement.x = (float)Math.Cos(transform.rotation.eulerAngles.z);
            // movement.y = (float)Math.Sin(transform.rotation.eulerAngles.z);
        }
    }

}
