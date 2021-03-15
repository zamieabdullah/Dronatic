using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 20;

    void Update() 
    {
        transform.Translate((transform.forward * speed * Time.deltaTime));
    }
}
