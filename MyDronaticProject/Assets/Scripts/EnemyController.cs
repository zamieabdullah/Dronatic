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
    private bool coin_spawn = false;
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        movement.x = (float)Math.Cos(transform.rotation.eulerAngles.z);
        movement.y = (float)Math.Sin(transform.rotation.eulerAngles.z);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        if (coin_spawn) {
            coin_spawn = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "missle(Clone)") {
            if (!coin_spawn) {
                Instantiate (coin, transform.position, Quaternion.identity);
                coin_spawn = true;
            }
            
            transform.position = new Vector2(x_val, y_val);
            transform.rotation = Quaternion.Euler(0, 0, rot_val);
            
        } else if (col.gameObject.name != "Coin(Clone)") {
            Vector2 collisionSurfaceNormal = col.GetContact(0).normal;
            if (Math.Abs(Vector2.Dot(collisionSurfaceNormal, new Vector2(0,1))) > 0.1) {
                movement.y = movement.y * (-1);
            } else if (Math.Abs(Vector2.Dot(collisionSurfaceNormal, new Vector2(1,0))) > 0.1) {
                movement.x = movement.x * (-1);
            }
        }
    }

}
